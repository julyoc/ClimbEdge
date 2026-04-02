using ClimbEdge.Domain.Entities.AI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.AI
{
    internal class AIModelBenchmarkConfiguration : IEntityTypeConfiguration<AIModelBenchmark>
    {
        public void Configure(EntityTypeBuilder<AIModelBenchmark> builder)
        {
            builder.ConfigureBaseModel();
            builder.HasOne(e => e.AIModel).WithMany(e => e.Benchmarks).HasForeignKey(e => e.AIModelId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.AIModelVersion).WithMany(e => e.Benchmarks).HasForeignKey(e => e.AIModelVersionId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
