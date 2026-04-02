using ClimbEdge.Domain.Entities.Payment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Payment
{
    internal class PayPerUseConfiguration : IEntityTypeConfiguration<PayPerUse>
    {
        public void Configure(EntityTypeBuilder<PayPerUse> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.ServiceType).IsRequired();
        }
    }
}
