using ClimbEdge.Domain.Entities.Training;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Training
{
    internal class TrainingWeekConfiguration : IEntityTypeConfiguration<TrainingWeek>
    {
        public void Configure(EntityTypeBuilder<TrainingWeek> builder)
        {
            builder.ConfigureBaseModel();
            builder.HasOne(e => e.TrainingPeriod).WithMany(e => e.Weeks).HasForeignKey(e => e.TrainingPeriodId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
