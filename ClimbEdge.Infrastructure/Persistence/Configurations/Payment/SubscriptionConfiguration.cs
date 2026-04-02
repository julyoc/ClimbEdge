using ClimbEdge.Domain.Entities.Payment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Payment
{
    internal class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.ConfigureBaseModel();
            builder.HasOne(e => e.Plan).WithMany(e => e.Subscriptions).HasForeignKey(e => e.PlanId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
