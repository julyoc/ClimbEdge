using ClimbEdge.Domain.Entities.Boards;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Boards
{
    public class BoardItemTypeConfiguration : IEntityTypeConfiguration<BoardItemType>
    {
        public void Configure(EntityTypeBuilder<BoardItemType> builder)
        {
            builder.ConfigureBaseModel();

            builder.Property(b => b.Name)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.HasIndex(b => b.Name).IsUnique();
            builder.Property(b => b.Description)
                   .HasColumnType("TEXT");
            builder.Property(b => b.Difficulty)
                   .IsRequired();
            builder.Property(b => b.Icon)
                   .HasColumnType("TEXT");
        }
    }
}
