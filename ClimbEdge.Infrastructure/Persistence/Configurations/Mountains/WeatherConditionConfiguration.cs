using ClimbEdge.Domain.Entities.Mountains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Mountains
{
    internal class WeatherConditionConfiguration : IEntityTypeConfiguration<WeatherCondition>
    {
        public void Configure(EntityTypeBuilder<WeatherCondition> builder)
        {
            builder.ConfigureBaseModel();

            builder.Property(e => e.RecordedAt).IsRequired();

            builder.HasOne(e => e.Mountain).WithMany(e => e.WeatherConditions).HasForeignKey(e => e.MountainId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
