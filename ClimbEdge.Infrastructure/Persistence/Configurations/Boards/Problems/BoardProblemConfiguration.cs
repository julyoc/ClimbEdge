using ClimbEdge.Domain.Entities.Boards;
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
    internal class BoardProblemConfiguration : IEntityTypeConfiguration<BoardProblem>
    {
        public void Configure(EntityTypeBuilder<BoardProblem> builder)
        {
            builder.ConfigureBaseModel();

            builder.Property(b => b.Name)
                   .IsRequired()
                   .HasMaxLength(200);
            builder.Property(b => b.Description)
                   .HasColumnType("TEXT");
            builder.Property(b => b.IsPublic)
                   .IsRequired();
            builder.Property(b => b.GeneratedByAI)
                   .IsRequired();
            builder.HasIndex(b => new { b.BoardConfigId, b.Name }).IsUnique();

            // Relationships
            builder.HasOne(b => b.BoardConfig)
                   .WithMany(bc => bc.BoardProblems)
                   .HasForeignKey(b => b.BoardConfigId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(b => b.CreatedByUser)
                   .WithMany(u => u.CreatedBoardProblems)
                   .HasForeignKey(b => b.CreatedByUserId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
