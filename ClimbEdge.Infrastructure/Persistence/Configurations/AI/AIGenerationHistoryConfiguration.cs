using ClimbEdge.Domain.Entities.AI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.AI
{
    internal class AIGenerationHistoryConfiguration : IEntityTypeConfiguration<AIGenerationHistory>
    {
        public void Configure(EntityTypeBuilder<AIGenerationHistory> builder)
        {
            builder.ConfigureBaseModel();
            builder.HasOne(e => e.AIGenerationRequest).WithMany(e => e.History).HasForeignKey(e => e.AIGenerationRequestId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
