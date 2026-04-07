using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Organizations;
using ClimbEdge.Domain.Repositories.Organizations;
using MediatR;

namespace ClimbEdge.Application.Commands.OrganizationCommand
{
    public record RegisterEventParticipantCommand(RegisterEventParticipantDTO entity) : IRequest<GetOrganizationEventParticipantDTO>;

    public class RegisterEventParticipantCommandHandler
        : IRequestHandler<RegisterEventParticipantCommand, GetOrganizationEventParticipantDTO>
    {
        private readonly IOrganizationEventParticipantRepository _participantRepository;
        private readonly IOrganizationEventRepository _eventRepository;

        public RegisterEventParticipantCommandHandler(
            IOrganizationEventParticipantRepository participantRepository,
            IOrganizationEventRepository eventRepository)
        {
            _participantRepository = participantRepository;
            _eventRepository = eventRepository;
        }

        public async Task<GetOrganizationEventParticipantDTO> Handle(
            RegisterEventParticipantCommand request, CancellationToken cancellationToken)
        {
            var existing = await _participantRepository.GetAsync(
                criteria: p => p.EventId == request.entity.EventId
                    && p.UserId == request.entity.UserId && !p.IsDeleted);

            if (existing.Any())
                throw new InvalidOperationException("User is already registered for this event.");

            var participant = new OrganizationEventParticipant
            {
                EventId = request.entity.EventId,
                UserId = request.entity.UserId,
                Notes = request.entity.Notes,
                RegistrationDate = DateTime.UtcNow,
                Status = "Registered"
            };
            participant.InitializeSlug();
            await _participantRepository.AddAsync(participant);
            await _participantRepository.SaveChangesAsync();
            return Mapper.Map<OrganizationEventParticipant, GetOrganizationEventParticipantDTO>(participant);
        }
    }
}
