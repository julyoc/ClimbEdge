using ClimbEdge.Domain.Entities.Help;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Help
{
    internal class TicketAttachmentConfiguration : IEntityTypeConfiguration<TicketAttachment>
    {
        public void Configure(EntityTypeBuilder<TicketAttachment> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.FileName).IsRequired();
            builder.Property(e => e.FileUrl).IsRequired();
            builder.HasOne(e => e.Ticket).WithMany(e => e.Attachments).HasForeignKey(e => e.TicketId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
