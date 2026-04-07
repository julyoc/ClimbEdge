using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using ClimbEdge.Domain.Interfaces;
using ClimbEdge.Domain.Repositories.Mountains.Itinerary;
using MediatR;

namespace ClimbEdge.Application.Queries.ExpeditionQuery
{
    public record GetExpeditionsQuery(long? MountainId = null, long? OrganizedBy = null, bool? PublicOnly = null, int Page = 1, int PageSize = 20) : IRequest<IEnumerable<GetExpeditionDTO>>;

    public class GetExpeditionsQueryHandler : IRequestHandler<GetExpeditionsQuery, IEnumerable<GetExpeditionDTO>>
    {
        private readonly IExpeditionRepository _expeditionRepository;

        public GetExpeditionsQueryHandler(IExpeditionRepository expeditionRepository)
        {
            _expeditionRepository = expeditionRepository;
        }

        public async Task<IEnumerable<GetExpeditionDTO>> Handle(GetExpeditionsQuery request, CancellationToken cancellationToken)
        {
            var expeditions = await _expeditionRepository.GetAsync(
                page: request.Page,
                criteria: e => !e.IsDeleted
                    && (request.MountainId == null || e.MountainId == request.MountainId)
                    && (request.OrganizedBy == null || e.OrganizedBy == request.OrganizedBy)
                    && (request.PublicOnly == null || e.IsPublic == request.PublicOnly),
                orderSelectors: new[] { new OrderSelectors("StartDate", false) },
                pageSize: request.PageSize
            );
            return expeditions.Select(e => Mapper.Map<Expedition, GetExpeditionDTO>(e));
        }
    }
}
