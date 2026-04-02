using ClimbEdge.Domain.Entities.Help;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Help
{
    internal class TicketMessageConfiguration : IEntityTypeConfiguration<TicketMessage>
    {
        public void Configure(EntityTypeBuilder<TicketMessage> builder)
        {
            builder.ConfigureBaseModel();
            builder.HasOne(e => e.Ticket).WithMany(e => e.Messages).HasForeignKey(e => e.TicketId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
