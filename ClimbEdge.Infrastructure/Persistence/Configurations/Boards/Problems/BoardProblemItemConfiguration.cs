using ClimbEdge.Domain.Entities.Boards.Problems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Boards.Problems
{
    internal class BoardProblemItemConfiguration : IEntityTypeConfiguration<BoardProblemItem>
    {
        public void Configure(EntityTypeBuilder<BoardProblemItem> builder)
        {
            builder.ConfigureBaseModel();

            builder.Property(e => e.Sequence);

            builder.HasIndex(e => new { e.BoardProblemId, e.BoardItemId, e.BoardProblemItemTypeId }).IsUnique();

            // Relationships

            builder.HasOne(e => e.BoardProblem)
                   .WithMany(e => e.BoardProblemItems)
                   .HasForeignKey(e => e.BoardProblemId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.BoardItem)
                   .WithMany(e => e.BoardProblemItems)
                   .HasForeignKey(e => e.BoardItemId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.BoardProblemItemType)
                   .WithMany(e => e.BoardProblemItems)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
