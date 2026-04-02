using ClimbEdge.Domain.Entities.AI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.AI
{
    internal class AIModelVersionConfiguration : IEntityTypeConfiguration<AIModelVersion>
    {
        public void Configure(EntityTypeBuilder<AIModelVersion> builder)
        {
            builder.ConfigureBaseModel();
            builder.HasOne(e => e.AIModel).WithMany(e => e.Versions).HasForeignKey(e => e.AIModelId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
