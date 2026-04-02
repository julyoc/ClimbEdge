using ClimbEdge.Domain.Entities.Training;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Training
{
    internal class TrainingVolumeConfiguration : IEntityTypeConfiguration<TrainingVolume>
    {
        public void Configure(EntityTypeBuilder<TrainingVolume> builder)
        {
            builder.ConfigureBaseModel();
            builder.HasOne(e => e.TrainingWeek).WithOne(e => e.TrainingVolume).HasForeignKey<TrainingVolume>(e => e.TrainingWeekId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
