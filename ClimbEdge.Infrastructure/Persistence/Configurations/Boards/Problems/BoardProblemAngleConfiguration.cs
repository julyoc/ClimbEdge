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
    public class BoardProblemAngleConfiguration : IEntityTypeConfiguration<BoardProblemAngle>
    {
        public void Configure(EntityTypeBuilder<BoardProblemAngle> builder)
        {
            builder.ConfigureBaseModel();

            builder.Property(bpa => bpa.Rating);

            builder.HasIndex(bpa => new { bpa.BoardAngleId, bpa.BoardProblemId, bpa.DifficultyScaleId }).IsUnique();

            // Relationships
            builder.HasOne(b => b.BoardProblem)
                   .WithMany(bp => bp.BoardProblemAngles)
                   .HasForeignKey(b => b.BoardProblemId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(b => b.BoardAngle)
                   .WithMany(ba => ba.BoardProblemAngles)
                   .HasForeignKey(b => b.BoardAngleId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(b => b.DifficultyScale)
                   .WithMany(ds => ds.BoardProblemAngles)
                   .HasForeignKey(b => b.DifficultyScaleId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
