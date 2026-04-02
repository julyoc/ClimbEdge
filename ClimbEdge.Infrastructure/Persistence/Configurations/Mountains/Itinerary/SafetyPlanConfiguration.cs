using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Mountains.Itinerary
{
    internal class SafetyPlanConfiguration : IEntityTypeConfiguration<SafetyPlan>
    {
        public void Configure(EntityTypeBuilder<SafetyPlan> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.EmergencyContactName).IsRequired();
            builder.HasOne(e => e.Expedition).WithMany().HasForeignKey(e => e.ExpeditionId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
