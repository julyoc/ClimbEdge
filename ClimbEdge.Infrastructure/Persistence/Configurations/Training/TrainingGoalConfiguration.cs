using ClimbEdge.Domain.Entities.Training;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Training
{
    internal class TrainingGoalConfiguration : IEntityTypeConfiguration<TrainingGoal>
    {
        public void Configure(EntityTypeBuilder<TrainingGoal> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.Title).IsRequired();
        }
    }
}
