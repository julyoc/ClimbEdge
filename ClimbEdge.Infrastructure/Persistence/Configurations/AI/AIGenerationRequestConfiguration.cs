using ClimbEdge.Domain.Entities.AI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.AI
{
    internal class AIGenerationRequestConfiguration : IEntityTypeConfiguration<AIGenerationRequest>
    {
        public void Configure(EntityTypeBuilder<AIGenerationRequest> builder)
        {
            builder.ConfigureBaseModel();
            builder.HasOne(e => e.AIModel).WithMany(e => e.GenerationRequests).HasForeignKey(e => e.AIModelId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
