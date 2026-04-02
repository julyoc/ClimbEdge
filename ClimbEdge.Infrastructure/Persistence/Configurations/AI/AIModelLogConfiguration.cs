using ClimbEdge.Domain.Entities.AI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.AI
{
    internal class AIModelLogConfiguration : IEntityTypeConfiguration<AIModelLog>
    {
        public void Configure(EntityTypeBuilder<AIModelLog> builder)
        {
            builder.ConfigureBaseModel();
            builder.HasOne(e => e.AIModel).WithMany(e => e.Logs).HasForeignKey(e => e.AIModelId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
