using ClimbEdge.Domain.Entities.Payment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Payment
{
    internal class PaymentConfiguration : IEntityTypeConfiguration<global::ClimbEdge.Domain.Entities.Payment.Payment>
    {
        public void Configure(EntityTypeBuilder<global::ClimbEdge.Domain.Entities.Payment.Payment> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.TransactionId).IsRequired();
            builder.HasOne(e => e.PaymentMethod).WithMany(e => e.Payments).HasForeignKey(e => e.PaymentMethodId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
