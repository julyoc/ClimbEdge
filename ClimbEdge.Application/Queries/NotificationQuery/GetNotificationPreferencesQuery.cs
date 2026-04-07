using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Notifications;
using ClimbEdge.Domain.Repositories.Notifications;
using MediatR;

namespace ClimbEdge.Application.Queries.NotificationQuery
{
    public record GetNotificationPreferencesQuery(long UserId) : IRequest<IEnumerable<GetNotificationPreferenceDTO>>;

    public class GetNotificationPreferencesQueryHandler
        : IRequestHandler<GetNotificationPreferencesQuery, IEnumerable<GetNotificationPreferenceDTO>>
    {
        private readonly INotificationPreferenceRepository _preferenceRepository;

        public GetNotificationPreferencesQueryHandler(INotificationPreferenceRepository preferenceRepository)
        {
            _preferenceRepository = preferenceRepository;
        }

        public async Task<IEnumerable<GetNotificationPreferenceDTO>> Handle(
            GetNotificationPreferencesQuery request, CancellationToken cancellationToken)
        {
            var prefs = await _preferenceRepository.GetAsync(
                criteria: p => p.UserId == request.UserId && !p.IsDeleted);

            return prefs
                .OrderBy(p => p.Category)
                .Select(p => Mapper.Map<NotificationPreference, GetNotificationPreferenceDTO>(p));
        }
    }
}
