using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using ClimbEdge.Domain.Repositories.Mountains.Itinerary;
using MediatR;

namespace ClimbEdge.Application.Queries.ExpeditionQuery
{
    public record GetExpeditionParticipantsQuery(long ExpeditionId) : IRequest<IEnumerable<GetExpeditionParticipantDTO>>;

    public class GetExpeditionParticipantsQueryHandler
        : IRequestHandler<GetExpeditionParticipantsQuery, IEnumerable<GetExpeditionParticipantDTO>>
    {
        private readonly IExpeditionParticipantRepository _participantRepository;

        public GetExpeditionParticipantsQueryHandler(IExpeditionParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        public async Task<IEnumerable<GetExpeditionParticipantDTO>> Handle(
            GetExpeditionParticipantsQuery request, CancellationToken cancellationToken)
        {
            var participants = await _participantRepository.GetAsync(
                criteria: p => p.ExpeditionId == request.ExpeditionId && !p.IsDeleted);

            return participants.Select(p => Mapper.Map<ExpeditionParticipant, GetExpeditionParticipantDTO>(p));
        }
    }
}
