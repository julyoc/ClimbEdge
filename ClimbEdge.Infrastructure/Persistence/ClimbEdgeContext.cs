using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ClimbEdge.Domain.Entities;
using ClimbEdge.Domain.Shared;
using ClimbEdge.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using System.Numerics;

namespace ClimbEdge.Infrastructure.Persistence
{
    /// <summary>
    /// Contexto de base de datos principal que incluye Identity
    /// </summary>
    public class ClimbEdgeContext : IdentityDbContext<AppUser, AppRole, long>
    {
        public ClimbEdgeContext(DbContextOptions<ClimbEdgeContext> options) : base(options) { }

        private void RegisterEntities(ModelBuilder builder)
        {
            var entityTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(BaseModel)));

            foreach (var type in entityTypes)
            {
                builder.Entity(type).ToTable(type.Name);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Registrar entidades dinámicamente
            RegisterEntities(builder);

            // Aplicar configuraciones desde carpeta Configurations
            builder.ApplyConfigurationsFromAssembly(typeof(ClimbEdgeContext).Assembly);
        }

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Actualiza automáticamente las marcas de tiempo antes de guardar
        /// </summary>
        private void UpdateTimestamps()
        {
            var entries = ChangeTracker.Entries<BaseModel>();

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        entry.Entity.UpdatedAt = null;
                        entry.Entity.InitializeSlug();
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdateTimestamps();
                        break;
                }
            }

            // También actualizar entidades que implementan IBaseEntity
            var baseEntityEntries = ChangeTracker.Entries<IBaseEntity>();
            foreach (var entry in baseEntityEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        entry.Entity.UpdatedAt = null;
                        entry.Entity.InitializeSlug();
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdateTimestamps();
                        break;
                }
            }
        }
    }
}
