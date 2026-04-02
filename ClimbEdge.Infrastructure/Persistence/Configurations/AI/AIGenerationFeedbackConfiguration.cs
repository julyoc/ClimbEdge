using ClimbEdge.Domain.Entities.AI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.AI
{
    internal class AIGenerationFeedbackConfiguration : IEntityTypeConfiguration<AIGenerationFeedback>
    {
        public void Configure(EntityTypeBuilder<AIGenerationFeedback> builder)
        {
            builder.ConfigureBaseModel();
            builder.HasOne(e => e.AIGenerationRequest).WithMany(e => e.Feedbacks).HasForeignKey(e => e.AIGenerationRequestId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
