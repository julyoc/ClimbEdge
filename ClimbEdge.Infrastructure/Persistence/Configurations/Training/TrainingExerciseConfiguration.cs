using ClimbEdge.Domain.Entities.Training;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Training
{
    internal class TrainingExerciseConfiguration : IEntityTypeConfiguration<TrainingExercise>
    {
        public void Configure(EntityTypeBuilder<TrainingExercise> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.Name).IsRequired();
        }
    }
}
