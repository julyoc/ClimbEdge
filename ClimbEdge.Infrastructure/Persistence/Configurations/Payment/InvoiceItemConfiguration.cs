using ClimbEdge.Domain.Entities.Payment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Payment
{
    internal class InvoiceItemConfiguration : IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceItem> builder)
        {
            builder.ConfigureBaseModel();
            builder.HasOne(e => e.Invoice).WithMany(e => e.Items).HasForeignKey(e => e.InvoiceId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
