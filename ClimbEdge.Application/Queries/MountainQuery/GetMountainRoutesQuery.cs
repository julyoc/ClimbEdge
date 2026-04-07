using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Mountains;
using ClimbEdge.Domain.Repositories.Mountains;
using MediatR;

namespace ClimbEdge.Application.Queries.MountainQuery
{
    public record GetMountainRoutesQuery(long MountainId) : IRequest<IEnumerable<GetMountainRouteDTO>>;

    public class GetMountainRoutesQueryHandler : IRequestHandler<GetMountainRoutesQuery, IEnumerable<GetMountainRouteDTO>>
    {
        private readonly IMountainRouteRepository _routeRepository;

        public GetMountainRoutesQueryHandler(IMountainRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<IEnumerable<GetMountainRouteDTO>> Handle(
            GetMountainRoutesQuery request, CancellationToken cancellationToken)
        {
            var routes = await _routeRepository.GetAsync(
                criteria: r => r.MountainId == request.MountainId && !r.IsDeleted);

            return routes
                .OrderBy(r => r.Name)
                .Select(r => Mapper.Map<MountainRoute, GetMountainRouteDTO>(r));
        }
    }
}
