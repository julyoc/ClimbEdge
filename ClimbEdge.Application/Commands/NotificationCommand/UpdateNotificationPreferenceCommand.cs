using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Notifications;
using ClimbEdge.Domain.Repositories.Notifications;
using MediatR;

namespace ClimbEdge.Application.Commands.NotificationCommand
{
    public record UpdateNotificationPreferenceCommand(UpdateNotificationPreferenceDTO entity) : IRequest<GetNotificationPreferenceDTO>;

    public class UpdateNotificationPreferenceCommandHandler
        : IRequestHandler<UpdateNotificationPreferenceCommand, GetNotificationPreferenceDTO>
    {
        private readonly INotificationPreferenceRepository _preferenceRepository;

        public UpdateNotificationPreferenceCommandHandler(INotificationPreferenceRepository preferenceRepository)
        {
            _preferenceRepository = preferenceRepository;
        }

        public async Task<GetNotificationPreferenceDTO> Handle(
            UpdateNotificationPreferenceCommand request, CancellationToken cancellationToken)
        {
            var existing = await _preferenceRepository.GetAsync(
                criteria: p => p.UserId == request.entity.UserId
                    && p.Category == request.entity.Category && !p.IsDeleted);

            var pref = existing.FirstOrDefault();

            if (pref is null)
            {
                pref = new NotificationPreference
                {
                    UserId = request.entity.UserId,
                    Category = request.entity.Category,
                    EmailEnabled = request.entity.EmailEnabled,
                    PushEnabled = request.entity.PushEnabled,
                    InAppEnabled = request.entity.InAppEnabled,
                    SMSEnabled = request.entity.SMSEnabled
                };
                pref.InitializeSlug();
                await _preferenceRepository.AddAsync(pref);
            }
            else
            {
                pref.EmailEnabled = request.entity.EmailEnabled;
                pref.PushEnabled = request.entity.PushEnabled;
                pref.InAppEnabled = request.entity.InAppEnabled;
                pref.SMSEnabled = request.entity.SMSEnabled;
                pref.UpdateTimestamps();
                await _preferenceRepository.UpdateAsync(pref);
            }

            await _preferenceRepository.SaveChangesAsync();
            return Mapper.Map<NotificationPreference, GetNotificationPreferenceDTO>(pref);
        }
    }
}
