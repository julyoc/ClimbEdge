using ClimbEdge.Domain.Entities.Payment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Payment
{
    internal class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.InvoiceNumber).IsRequired();
            builder.HasIndex(e => e.InvoiceNumber).IsUnique();
        }
    }
}
