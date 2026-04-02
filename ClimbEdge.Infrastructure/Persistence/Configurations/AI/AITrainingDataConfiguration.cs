using ClimbEdge.Domain.Entities.AI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.AI
{
    internal class AITrainingDataConfiguration : IEntityTypeConfiguration<AITrainingData>
    {
        public void Configure(EntityTypeBuilder<AITrainingData> builder)
        {
            builder.ConfigureBaseModel();
            builder.HasOne(e => e.UsedByModel).WithMany().HasForeignKey(e => e.UsedByModelId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
