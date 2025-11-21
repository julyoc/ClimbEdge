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
            builder.Property(b => b.IsFeatured).IsRequired();
            builder.Property(b => b.IsArchived).IsRequired();
            builder.Property(b => b.IsDryTooling).IsRequired();
            builder.Property(b => b.GeneratedByAI)
                   .IsRequired();
            builder.HasIndex(b => new { b.BoardConfigId, b.Name }).IsUnique();
            builder.HasIndex(b => b.Name);

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
            builder.HasMany(e => e.BoardProblemTags).WithMany(pt => pt.BoardProblems);
            builder.HasMany(e => e.FootRules).WithMany(fr => fr.BoardProblems);
        }
    }
}
