using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Mountains.Itinerary
{
    internal class ExpeditionBudgetConfiguration : IEntityTypeConfiguration<ExpeditionBudget>
    {
        public void Configure(EntityTypeBuilder<ExpeditionBudget> builder)
        {
            builder.ConfigureBaseModel();
            builder.HasOne(e => e.Expedition).WithMany().HasForeignKey(e => e.ExpeditionId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.ExpeditionBudgetCategory).WithMany().HasForeignKey(e => e.ExpeditionBudgetCategoryId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
