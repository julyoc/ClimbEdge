using ClimbEdge.Domain.Entities.Training;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Training
{
    internal class TrainingSessionClimbingConfiguration : IEntityTypeConfiguration<TrainingSessionClimbing>
    {
        public void Configure(EntityTypeBuilder<TrainingSessionClimbing> builder)
        {
            builder.ConfigureBaseModel();
            builder.HasIndex(e => new { e.TrainingSessionId, e.UserSessionId }).IsUnique();
            builder.HasOne(e => e.TrainingSession).WithMany(e => e.ClimbingSessions).HasForeignKey(e => e.TrainingSessionId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
