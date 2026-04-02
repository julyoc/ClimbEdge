using ClimbEdge.Domain.Entities.AI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.AI
{
    internal class AIGenerationTemplateConfiguration : IEntityTypeConfiguration<AIGenerationTemplate>
    {
        public void Configure(EntityTypeBuilder<AIGenerationTemplate> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.Name).IsRequired();
            builder.HasIndex(e => e.Name).IsUnique();
            builder.HasOne(e => e.AIModel).WithMany(e => e.GenerationTemplates).HasForeignKey(e => e.AIModelId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
