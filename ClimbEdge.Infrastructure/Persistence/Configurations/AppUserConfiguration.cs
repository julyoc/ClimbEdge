using ClimbEdge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Persistence.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                   .ValueGeneratedOnAdd()
                   .IsRequired();
            builder.HasIndex(e => e.Slug)
                   .IsUnique();
            builder.Property(e => e.Slug)
                   .IsRequired()
                   .HasMaxLength(500);
            builder.Property(e => e.MetaData)
                    .HasColumnType("jsonb");
            builder.Property(e => e.RowVersion)
                   .IsRowVersion()
                   .IsConcurrencyToken();
            builder.Property(e => e.CreatedAt)
                   .IsRequired();
            builder.Ignore(e => e.IsDeleted);
            builder.Ignore(e => e.IsRestored);
            builder.Ignore(e => e.IsLocked);
            builder.Ignore(e => e.DaysSinceCreated);
            builder.Ignore(e => e.DaysSinceUpdated);
            builder.Ignore(e => e.DaysSinceDeleted);
            builder.Ignore(e => e.DaysSinceRestored);
            builder.Ignore(e => e.DaysSinceLocked);
            builder.Ignore(e => e.IsRecentlyCreated);
            builder.Ignore(e => e.IsRecentlyUpdated);
            builder.Ignore(e => e.IsRecentlyDeleted);
            builder.Ignore(e => e.IsRecentlyRestored);
            builder.Ignore(e => e.IsRecentlyLocked);
            builder.Ignore(e => e.DomainEvents);

            // Filtros de consulta para soft delete
            builder.HasQueryFilter(e => !e.DeletedAt.HasValue);
        }
    }
}
