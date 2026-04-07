using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Climbing;
using ClimbEdge.Domain.Repositories.Climbing;
using MediatR;

namespace ClimbEdge.Application.Queries.ClimbRouteQuery
{
    public record GetClimbRouteQuery(Guid RouteUid) : IRequest<GetClimbRouteDTO?>;

    public class GetClimbRouteQueryHandler : IRequestHandler<GetClimbRouteQuery, GetClimbRouteDTO?>
    {
        private readonly IClimbRouteRepository _climbRouteRepository;

        public GetClimbRouteQueryHandler(IClimbRouteRepository climbRouteRepository)
        {
            _climbRouteRepository = climbRouteRepository;
        }

        public async Task<GetClimbRouteDTO?> Handle(GetClimbRouteQuery request, CancellationToken cancellationToken)
        {
            var route = await _climbRouteRepository.GetAsync(request.RouteUid);
            if (route == null) return null;
            return Mapper.Map<ClimbRoute, GetClimbRouteDTO>(route);
        }
    }
}
