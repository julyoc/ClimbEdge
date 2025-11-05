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
    internal class BoardProblemTagConfiguration : IEntityTypeConfiguration<BoardProblemTag>
    {
        public void Configure(EntityTypeBuilder<BoardProblemTag> builder)
        {
            builder.ConfigureBaseModel();

            builder.Property(bpt => bpt.Name).IsRequired().HasMaxLength(100);
            builder.Property(bpt => bpt.Description).HasMaxLength(500);
            builder.HasIndex(bpt => bpt.Name).IsUnique();
        }
    }
}
