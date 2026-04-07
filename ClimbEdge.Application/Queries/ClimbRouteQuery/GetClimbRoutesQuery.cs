using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Climbing;
using ClimbEdge.Domain.Interfaces;
using ClimbEdge.Domain.Repositories.Climbing;
using MediatR;

namespace ClimbEdge.Application.Queries.ClimbRouteQuery
{
    public record GetClimbRoutesQuery(long? ClimbZoneId = null, long? DifficultyScaleNameId = null, int Page = 1, int PageSize = 20) : IRequest<IEnumerable<GetClimbRouteDTO>>;

    public class GetClimbRoutesQueryHandler : IRequestHandler<GetClimbRoutesQuery, IEnumerable<GetClimbRouteDTO>>
    {
        private readonly IClimbRouteRepository _climbRouteRepository;

        public GetClimbRoutesQueryHandler(IClimbRouteRepository climbRouteRepository)
        {
            _climbRouteRepository = climbRouteRepository;
        }

        public async Task<IEnumerable<GetClimbRouteDTO>> Handle(GetClimbRoutesQuery request, CancellationToken cancellationToken)
        {
            var routes = await _climbRouteRepository.GetAsync(
                page: request.Page,
                criteria: r => !r.IsDeleted
                    && (request.ClimbZoneId == null || r.ClimbZoneId == request.ClimbZoneId)
                    && (request.DifficultyScaleNameId == null || r.DifficultyScaleNameId == request.DifficultyScaleNameId),
                orderSelectors: new[] { new OrderSelectors("Name", false) },
                pageSize: request.PageSize
            );
            return routes.Select(r => Mapper.Map<ClimbRoute, GetClimbRouteDTO>(r));
        }
    }
}
