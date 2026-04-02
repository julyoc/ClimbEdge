using ClimbEdge.Domain.Entities.Training;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Training
{
    internal class TrainingSessionConfiguration : IEntityTypeConfiguration<TrainingSession>
    {
        public void Configure(EntityTypeBuilder<TrainingSession> builder)
        {
            builder.ConfigureBaseModel();
            builder.HasOne(e => e.TrainingWeek).WithMany(e => e.Sessions).HasForeignKey(e => e.TrainingWeekId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
