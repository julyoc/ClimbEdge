using ClimbEdge.Domain.Entities.Training;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Training
{
    internal class SessionExerciseConfiguration : IEntityTypeConfiguration<SessionExercise>
    {
        public void Configure(EntityTypeBuilder<SessionExercise> builder)
        {
            builder.ConfigureBaseModel();
            builder.HasOne(e => e.TrainingSession).WithMany(e => e.Exercises).HasForeignKey(e => e.TrainingSessionId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.TrainingExercise).WithMany(e => e.SessionExercises).HasForeignKey(e => e.TrainingExerciseId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
