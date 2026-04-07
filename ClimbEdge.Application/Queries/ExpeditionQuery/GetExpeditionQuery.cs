using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using ClimbEdge.Domain.Repositories.Mountains.Itinerary;
using MediatR;

namespace ClimbEdge.Application.Queries.ExpeditionQuery
{
    public record GetExpeditionQuery(Guid ExpeditionUid) : IRequest<GetExpeditionDTO?>;

    public class GetExpeditionQueryHandler : IRequestHandler<GetExpeditionQuery, GetExpeditionDTO?>
    {
        private readonly IExpeditionRepository _expeditionRepository;

        public GetExpeditionQueryHandler(IExpeditionRepository expeditionRepository)
        {
            _expeditionRepository = expeditionRepository;
        }

        public async Task<GetExpeditionDTO?> Handle(GetExpeditionQuery request, CancellationToken cancellationToken)
        {
            var expedition = await _expeditionRepository.GetAsync(request.ExpeditionUid);
            if (expedition == null) return null;
            return Mapper.Map<Expedition, GetExpeditionDTO>(expedition);
        }
    }
}
