using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Notifications;
using ClimbEdge.Domain.Interfaces;
using ClimbEdge.Domain.Repositories.Notifications;
using MediatR;

namespace ClimbEdge.Application.Queries.NotificationQuery
{
    public record GetNotificationsQuery(long UserId, bool? UnreadOnly = null, int Page = 1, int PageSize = 20) : IRequest<IEnumerable<GetNotificationDTO>>;

    public class GetNotificationsQueryHandler : IRequestHandler<GetNotificationsQuery, IEnumerable<GetNotificationDTO>>
    {
        private readonly INotificationRepository _notificationRepository;

        public GetNotificationsQueryHandler(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<IEnumerable<GetNotificationDTO>> Handle(GetNotificationsQuery request, CancellationToken cancellationToken)
        {
            var notifications = await _notificationRepository.GetAsync(
                page: request.Page,
                criteria: n => n.UserId == request.UserId
                    && !n.IsDeleted
                    && (request.UnreadOnly == null
                        || (request.UnreadOnly == true && n.ReadAt == null)
                        || (request.UnreadOnly == false && n.ReadAt != null)),
                orderSelectors: new[] { new OrderSelectors("CreatedAt", true) },
                pageSize: request.PageSize
            );
            return notifications.Select(n => Mapper.Map<Notification, GetNotificationDTO>(n));
        }
    }
}
