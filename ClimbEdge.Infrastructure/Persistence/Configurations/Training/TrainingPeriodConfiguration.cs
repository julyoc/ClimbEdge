using ClimbEdge.Domain.Entities.Training;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Training
{
    internal class TrainingPeriodConfiguration : IEntityTypeConfiguration<TrainingPeriod>
    {
        public void Configure(EntityTypeBuilder<TrainingPeriod> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.Name).IsRequired();
            builder.HasOne(e => e.TrainingPlan).WithMany(e => e.Periods).HasForeignKey(e => e.TrainingPlanId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
