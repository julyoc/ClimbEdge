using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Mountains;
using ClimbEdge.Domain.Repositories.Mountains;
using MediatR;

namespace ClimbEdge.Application.Queries.MountainQuery
{
    public record GetMountainRouteQuery(Guid RouteUid) : IRequest<GetMountainRouteDTO?>;

    public class GetMountainRouteQueryHandler : IRequestHandler<GetMountainRouteQuery, GetMountainRouteDTO?>
    {
        private readonly IMountainRouteRepository _routeRepository;

        public GetMountainRouteQueryHandler(IMountainRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<GetMountainRouteDTO?> Handle(
            GetMountainRouteQuery request, CancellationToken cancellationToken)
        {
            var route = await _routeRepository.GetAsync(request.RouteUid);
            if (route is null) return null;
            return Mapper.Map<MountainRoute, GetMountainRouteDTO>(route);
        }
    }
}
