using ClimbEdge.Domain.Entities.Notifications;
using ClimbEdge.Domain.Repositories.Notifications;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.Notifications
{
    public class NotificationLogRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<NotificationLog>(climbEdgeContext, cacheService), INotificationLogRepository
    {
    }
}
