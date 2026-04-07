using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Mountains;
using ClimbEdge.Domain.Repositories.Mountains;
using MediatR;

namespace ClimbEdge.Application.Commands.MountainCommand
{
    public record UpdateMountainRouteCommand(Guid RouteUid, UpdateMountainRouteDTO entity) : IRequest<GetMountainRouteDTO>;

    public class UpdateMountainRouteCommandHandler : IRequestHandler<UpdateMountainRouteCommand, GetMountainRouteDTO>
    {
        private readonly IMountainRouteRepository _routeRepository;

        public UpdateMountainRouteCommandHandler(IMountainRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<GetMountainRouteDTO> Handle(UpdateMountainRouteCommand request, CancellationToken cancellationToken)
        {
            var route = await _routeRepository.GetAsync(request.RouteUid)
                ?? throw new InvalidOperationException("Mountain route not found.");

            Mapper.MapUpdate(request.entity, route);
            route.UpdateTimestamps();
            await _routeRepository.UpdateAsync(route);
            await _routeRepository.SaveChangesAsync();
            return Mapper.Map<MountainRoute, GetMountainRouteDTO>(route);
        }
    }
}
