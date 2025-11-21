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
    internal class FootRuleConfiguration : IEntityTypeConfiguration<FootRule>
    {
        public void Configure(EntityTypeBuilder<FootRule> builder)
        {
            builder.ConfigureBaseModel();
            
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(e => e.Description)
                .IsRequired();
            builder.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(50);
            
            builder.HasIndex(e => e.Code)
                .IsUnique();
            builder.HasIndex(e => e.Name);
        }
    }
}
