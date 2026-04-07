using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Mountains;
using ClimbEdge.Domain.Repositories.Mountains;
using MediatR;

namespace ClimbEdge.Application.Commands.MountainCommand
{
    public record CreateMountainRouteCommand(CreateMountainRouteDTO entity) : IRequest<GetMountainRouteDTO>;

    public class CreateMountainRouteCommandHandler : IRequestHandler<CreateMountainRouteCommand, GetMountainRouteDTO>
    {
        private readonly IMountainRouteRepository _routeRepository;

        public CreateMountainRouteCommandHandler(IMountainRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<GetMountainRouteDTO> Handle(CreateMountainRouteCommand request, CancellationToken cancellationToken)
        {
            var route = Mapper.Map<CreateMountainRouteDTO, MountainRoute>(request.entity);
            route.InitializeSlug();
            await _routeRepository.AddAsync(route);
            await _routeRepository.SaveChangesAsync();
            return Mapper.Map<MountainRoute, GetMountainRouteDTO>(route);
        }
    }
}
