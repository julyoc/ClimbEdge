using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ClimbEdge.Domain.Entities;
using ClimbEdge.Infrastructure.Persistence;
using ClimbEdge.Infrastructure.Repositories;
using ClimbEdge.Domain.Repositories;
using ClimbEdge.Infrastructure.Caching;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ClimbEdge.Common.Constants;

namespace ClimbEdge.Infrastructure.DependencyInjection
{
    /// <summary>
    /// Configuración de servicios de infraestructura
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Agrega los servicios de infraestructura al contenedor de dependencias
        /// </summary>
        /// <param name="services">Colección de servicios</param>
        /// <param name="configuration">Configuración de la aplicación</param>
        /// <returns>Colección de servicios configurada</returns>
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration,
            bool isDev)
        {
            // Configurar Entity Framework con PostgreSQL
            services.AddDbContext<ClimbEdgeContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseNpgsql(connectionString, npgsqlOptions =>
                {
                    npgsqlOptions.MigrationsAssembly(typeof(ClimbEdgeContext).Assembly.FullName);
                    npgsqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 3,
                        maxRetryDelay: TimeSpan.FromSeconds(5),
                        errorCodesToAdd: null);
                });

                // Configuraciones adicionales para desarrollo
                options.EnableSensitiveDataLogging(false);
                options.EnableDetailedErrors(false);
            });

            // Configurar servicios de caché
            services.AddMemoryCache();
            services.AddStackExchangeRedisCache(o =>
            {
                o.Configuration = configuration.GetConnectionString("Caching");
                o.InstanceName = "ClimbEdge:";
            });
            if (isDev)
            {
                services.AddScoped<ICacheService, InMemoryCacheService>();
            }
            else
            {
                services.AddScoped<ICacheService, CacheService>();
            }

            //services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.Scan(scan => scan.FromAssemblyOf<UserProfileRepository>()
                    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Repository")))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

            // Configurar Identity
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                // Configuración de contraseñas
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 4;

                // Configuración de usuarios
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

                // Configuración de bloqueo de cuenta
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // Configuración de tokens
                options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
                options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;

                // Configuración de signIn
                options.SignIn.RequireConfirmedEmail = false; // Cambiar a true en producción
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedAccount = false; // Cambiar a true en producción
            })
            .AddEntityFrameworkStores<ClimbEdgeContext>()
            .AddDefaultTokenProviders();

            // Configurar JWT Authentication
            var jwtSettings = configuration.GetSection("JwtSettings");
            var key = Encoding.ASCII.GetBytes(jwtSettings["SecretKey"]!);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = !isDev;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ClockSkew = TimeSpan.Zero
                };
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    },
                    OnMessageReceived = context =>
                    {
                        // 1️⃣ Primero intenta extraer desde la cookie HttpOnly
                        if (context.Request.Cookies.ContainsKey("access_token"))
                        {
                            context.Token = context.Request.Cookies["access_token"];
                            return Task.CompletedTask;
                        }
                        // 2️⃣ Después intenta desde el Header Authorization estándar
                        if (context.Request.Headers.TryGetValue("Authorization", out var authHeader) &&
                            authHeader.ToString().StartsWith("Bearer "))
                        {
                            context.Token = authHeader.ToString().Substring("Bearer ".Length).Trim();
                            return Task.CompletedTask;
                        }
                        // 3️⃣ Si quieres, puedes aceptar también un header personalizado (opcional)
                        if (context.Request.Headers.TryGetValue("access_token", out var tokenHeader))
                        {
                            context.Token = tokenHeader.ToString().Replace("Bearer ", "").Trim();
                            return Task.CompletedTask;
                        }
                        return Task.CompletedTask;
                    }
                };
            });

            // Configurar autorización
            services.AddAuthorization();

            return services;
        }

        /// <summary>
        /// Configura la base de datos y ejecuta migraciones pendientes
        /// </summary>
        /// <param name="serviceProvider">Proveedor de servicios</param>
        /// <returns>Task</returns>
        public static async Task ConfigureDatabaseAsync(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ClimbEdgeContext>();

            // Ejecutar migraciones pendientes
            await context.Database.MigrateAsync();

            // Configurar roles y usuarios por defecto
            await SeedDataAsync(scope.ServiceProvider);
        }

        /// <summary>
        /// Crea datos iniciales en la base de datos
        /// </summary>
        /// <param name="serviceProvider">Proveedor de servicios</param>
        /// <returns>Task</returns>
        private static async Task SeedDataAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<AppRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

            // Crear roles por defecto
            
            foreach (var role in Roles.roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new AppRole(role));
                }
            }

            // Crear usuario administrador por defecto
            var adminEmail = "admin@climbedge.local";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new AppUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, "Admin123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}
