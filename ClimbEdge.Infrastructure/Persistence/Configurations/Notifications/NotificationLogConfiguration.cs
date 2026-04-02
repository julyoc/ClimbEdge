using ClimbEdge.Domain.Entities.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Notifications
{
    internal class NotificationLogConfiguration : IEntityTypeConfiguration<NotificationLog>
    {
        public void Configure(EntityTypeBuilder<NotificationLog> builder)
        {
            builder.ConfigureBaseModel();
            builder.HasOne(e => e.Notification).WithMany(e => e.Logs).HasForeignKey(e => e.NotificationId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
