using ClimbEdge.Domain.Entities.AI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.AI
{
    internal class AITrainingSessionConfiguration : IEntityTypeConfiguration<AITrainingSession>
    {
        public void Configure(EntityTypeBuilder<AITrainingSession> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.SessionName).IsRequired();
            builder.HasOne(e => e.AIModel).WithMany(e => e.TrainingSessions).HasForeignKey(e => e.AIModelId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
