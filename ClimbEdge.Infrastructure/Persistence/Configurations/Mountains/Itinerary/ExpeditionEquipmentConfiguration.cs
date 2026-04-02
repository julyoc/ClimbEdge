using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Mountains.Itinerary
{
    internal class ExpeditionEquipmentConfiguration : IEntityTypeConfiguration<ExpeditionEquipment>
    {
        public void Configure(EntityTypeBuilder<ExpeditionEquipment> builder)
        {
            builder.ConfigureBaseModel();
            builder.HasOne(e => e.Expedition).WithMany().HasForeignKey(e => e.ExpeditionId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Equipment).WithMany().HasForeignKey(e => e.EquipmentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
