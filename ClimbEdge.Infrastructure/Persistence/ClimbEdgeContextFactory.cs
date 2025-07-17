using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Persistence
{
    public class ClimbEdgeContextFactory : IDesignTimeDbContextFactory<ClimbEdgeContext>
    {
        public ClimbEdgeContext CreateDbContext(string[] args)
        {
            // Buscar el archivo de configuración en el proyecto API
            var apiProjectPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "ClimbEdge.API");

            // Si estamos ejecutando desde la raíz del proyecto
            if (!Directory.Exists(apiProjectPath))
            {
                apiProjectPath = Path.Combine(Directory.GetCurrentDirectory(), "ClimbEdge.API");
            }

            var configuration = new ConfigurationBuilder()
                .SetBasePath(apiProjectPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ClimbEdgeContext>();

            // Usar la misma configuración que en tu ServiceCollectionExtensions
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql(connectionString, npgsqlOptions =>
            {
                npgsqlOptions.MigrationsAssembly(typeof(ClimbEdgeContext).Assembly.FullName);
                npgsqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 3,
                    maxRetryDelay: TimeSpan.FromSeconds(5),
                    errorCodesToAdd: null);
            });

            // Configuraciones adicionales para desarrollo
            optionsBuilder.EnableSensitiveDataLogging(false);
            optionsBuilder.EnableDetailedErrors(false);

            return new ClimbEdgeContext(optionsBuilder.Options);
        }
    }
}
