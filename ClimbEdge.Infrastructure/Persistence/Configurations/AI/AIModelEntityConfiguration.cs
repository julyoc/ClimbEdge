using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.AI
{
    internal class AIModelEntityConfiguration : IEntityTypeConfiguration<global::ClimbEdge.Domain.Entities.AI.AIModelConfiguration>
    {
        public void Configure(EntityTypeBuilder<global::ClimbEdge.Domain.Entities.AI.AIModelConfiguration> builder)
        {
            builder.ConfigureBaseModel();
            builder.HasOne(e => e.AIModel).WithMany(e => e.Configurations).HasForeignKey(e => e.AIModelId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
