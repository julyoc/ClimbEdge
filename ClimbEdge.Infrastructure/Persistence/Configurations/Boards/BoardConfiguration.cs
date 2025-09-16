using ClimbEdge.Domain.Entities.Boards;
using ClimbEdge.Domain.Enums.Boards;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Boards
{
    internal class BoardConfiguration : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.ConfigureBaseModel();

            builder.Property(b => b.Name)
                   .IsRequired()
                   .HasMaxLength(200);
            builder.HasIndex(b => b.Name).IsUnique();
            builder.Property(b => b.Description)
                   .HasColumnType("TEXT");
            builder.Property(b => b.Visibility)
                   .IsRequired()
                   .HasDefaultValue(BoardVisibility.Private);

            // Relaciones
            builder.HasOne(b => b.BoardConfig)
                   .WithMany(b => b.Boards)
                   .HasForeignKey(b => b.BoardConfigId)
                   .IsRequired();
            builder.HasOne(b => b.Organization)
                   .WithMany(b => b.Boards)
                   .HasForeignKey(b => b.OrganizationId);
        }
    }
}
