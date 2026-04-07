using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using ClimbEdge.Domain.Repositories.Mountains.Itinerary;
using MediatR;

namespace ClimbEdge.Application.Commands.ExpeditionCommand
{
    public record AddExpeditionParticipantCommand(AddExpeditionParticipantDTO entity) : IRequest;

    public class AddExpeditionParticipantCommandHandler : IRequestHandler<AddExpeditionParticipantCommand>
    {
        private readonly IExpeditionParticipantRepository _participantRepository;
        private readonly IExpeditionRepository _expeditionRepository;

        public AddExpeditionParticipantCommandHandler(
            IExpeditionParticipantRepository participantRepository,
            IExpeditionRepository expeditionRepository)
        {
            _participantRepository = participantRepository;
            _expeditionRepository = expeditionRepository;
        }

        public async Task Handle(AddExpeditionParticipantCommand request, CancellationToken cancellationToken)
        {
            var existing = await _participantRepository.GetAsync(
                criteria: p => p.ExpeditionId == request.entity.ExpeditionId
                    && p.UserId == request.entity.UserId && !p.IsDeleted);
            if (existing.Any()) throw new InvalidOperationException("User is already a participant in this expedition.");

            var participant = new ExpeditionParticipant
            {
                ExpeditionId = request.entity.ExpeditionId,
                UserId = request.entity.UserId,
                Role = request.entity.Role,
                InvitedAt = DateTime.UtcNow
            };
            await _participantRepository.AddAsync(participant);
            await _participantRepository.SaveChangesAsync();
        }
    }
}
