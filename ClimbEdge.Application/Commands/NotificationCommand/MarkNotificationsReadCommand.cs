using ClimbEdge.Domain.Entities.Notifications;
using ClimbEdge.Domain.Enums.Notifications;
using ClimbEdge.Domain.Repositories.Notifications;
using MediatR;

namespace ClimbEdge.Application.Commands.NotificationCommand
{
    public record MarkNotificationsReadCommand(long UserId, IEnumerable<Guid>? NotificationUids = null, bool MarkAll = false) : IRequest<int>;

    public class MarkNotificationsReadCommandHandler : IRequestHandler<MarkNotificationsReadCommand, int>
    {
        private readonly INotificationRepository _notificationRepository;

        public MarkNotificationsReadCommandHandler(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<int> Handle(MarkNotificationsReadCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<Notification> notifications;
            if (request.MarkAll)
            {
                notifications = await _notificationRepository.GetAsync(
                    criteria: n => n.UserId == request.UserId
                        && n.Status != NotificationStatus.Read && !n.IsDeleted);
            }
            else if (request.NotificationUids != null && request.NotificationUids.Any())
            {
                notifications = await _notificationRepository.GetAsync(request.NotificationUids);
                notifications = notifications.Where(n => n.UserId == request.UserId);
            }
            else
            {
                return 0;
            }

            var count = 0;
            foreach (var notification in notifications)
            {
                notification.Status = NotificationStatus.Read;
                notification.ReadAt = DateTime.UtcNow;
                notification.UpdateTimestamps();
                await _notificationRepository.UpdateAsync(notification);
                count++;
            }
            await _notificationRepository.SaveChangesAsync();
            return count;
        }
    }
}
