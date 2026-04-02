using ClimbEdge.Domain.Entities.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Notifications
{
    internal class NotificationQueueConfiguration : IEntityTypeConfiguration<NotificationQueue>
    {
        public void Configure(EntityTypeBuilder<NotificationQueue> builder)
        {
            builder.ConfigureBaseModel();
            builder.HasOne(e => e.Notification).WithMany(e => e.QueueEntries).HasForeignKey(e => e.NotificationId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
