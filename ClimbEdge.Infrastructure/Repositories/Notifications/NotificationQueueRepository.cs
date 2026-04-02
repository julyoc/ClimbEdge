using ClimbEdge.Domain.Entities.Notifications;
using ClimbEdge.Domain.Repositories.Notifications;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.Notifications
{
    public class NotificationQueueRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<NotificationQueue>(climbEdgeContext, cacheService), INotificationQueueRepository
    {
    }
}
