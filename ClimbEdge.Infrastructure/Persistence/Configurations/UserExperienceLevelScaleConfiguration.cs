using ClimbEdge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Persistence.Configurations
{
    internal class UserExperienceLevelScaleConfiguration : IEntityTypeConfiguration<UserExperienceLevelScale>
    {
        public void Configure(EntityTypeBuilder<UserExperienceLevelScale> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(ues => ues.Description).HasColumnType("text");

            builder.HasIndex(ues => new { ues.UserId, ues.DifficultyScaleId }).IsUnique();
            builder.HasOne(ues => ues.User).WithMany(up => up.ExperienceLevelScales).HasForeignKey(ues => ues.UserId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(ues => ues.DifficultyScale).WithMany(ds => ds.ExperienceLevelScales).HasForeignKey(ues => ues.DifficultyScaleId).IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
