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
    internal class BoardProblemItemTypeConfiguration : IEntityTypeConfiguration<BoardProblemItemType>
    {
        public void Configure(EntityTypeBuilder<BoardProblemItemType> builder)
        {
            builder.ConfigureBaseModel();

            builder.Property(e => e.Usage).IsRequired();
            builder.Property(e => e.IsStart).IsRequired();
            builder.Property(e => e.IsEnd).IsRequired();
            builder.Property(e => e.IsZone).IsRequired();
            builder.Property(e => e.IsMandatory).IsRequired();
            builder.Property(e => e.IsTouchOnly).IsRequired();
            builder.Property(e => e.Difficulty).IsRequired();

            builder.HasOne(e => e.Color).WithMany(e => e.boardProblemItemTypes).HasForeignKey(e => e.ColorId).IsRequired();
        }
    }
}
