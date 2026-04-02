using ClimbEdge.Domain.Entities.Training;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Training
{
    internal class TrainingProgressConfiguration : IEntityTypeConfiguration<TrainingProgress>
    {
        public void Configure(EntityTypeBuilder<TrainingProgress> builder)
        {
            builder.ConfigureBaseModel();
            builder.HasOne(e => e.TrainingPlan).WithMany(e => e.Progress).HasForeignKey(e => e.TrainingPlanId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
