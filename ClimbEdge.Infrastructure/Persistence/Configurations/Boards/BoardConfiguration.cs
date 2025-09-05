using ClimbEdge.Domain.Entities.Boards;
using ClimbEdge.Domain.Enums;
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
                   .HasColumnType("text");
            builder.Property(b => b.Visibility)
                   .IsRequired()
                   .HasDefaultValue(BoardVisibility.Private);
        }
    }
}
