using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Climbing;
using ClimbEdge.Domain.Repositories.Climbing;
using MediatR;

namespace ClimbEdge.Application.Commands.ClimbRouteCommand
{
    public record UpdateClimbRouteCommand(Guid RouteUid, UpdateClimbRouteDTO entity) : IRequest<GetClimbRouteDTO>;

    public class UpdateClimbRouteCommandHandler : IRequestHandler<UpdateClimbRouteCommand, GetClimbRouteDTO>
    {
        private readonly IClimbRouteRepository _climbRouteRepository;

        public UpdateClimbRouteCommandHandler(IClimbRouteRepository climbRouteRepository)
        {
            _climbRouteRepository = climbRouteRepository;
        }

        public async Task<GetClimbRouteDTO> Handle(UpdateClimbRouteCommand request, CancellationToken cancellationToken)
        {
            var route = await _climbRouteRepository.GetAsync(request.RouteUid);
            if (route == null) throw new InvalidOperationException("Climb route not found.");
            Mapper.MapUpdate(request.entity, route);
            route.UpdateTimestamps();
            await _climbRouteRepository.UpdateAsync(route);
            await _climbRouteRepository.SaveChangesAsync();
            return Mapper.Map<ClimbRoute, GetClimbRouteDTO>(route);
        }
    }
}
