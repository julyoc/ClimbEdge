using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Climbing;
using ClimbEdge.Domain.Repositories.Climbing;
using MediatR;

namespace ClimbEdge.Application.Commands.ClimbRouteCommand
{
    public record CreateClimbRouteCommand(CreateClimbRouteDTO entity) : IRequest<GetClimbRouteDTO>;

    public class CreateClimbRouteCommandHandler : IRequestHandler<CreateClimbRouteCommand, GetClimbRouteDTO>
    {
        private readonly IClimbRouteRepository _climbRouteRepository;

        public CreateClimbRouteCommandHandler(IClimbRouteRepository climbRouteRepository)
        {
            _climbRouteRepository = climbRouteRepository;
        }

        public async Task<GetClimbRouteDTO> Handle(CreateClimbRouteCommand request, CancellationToken cancellationToken)
        {
            var route = Mapper.Map<CreateClimbRouteDTO, ClimbRoute>(request.entity);
            await _climbRouteRepository.AddAsync(route);
            await _climbRouteRepository.SaveChangesAsync();
            return Mapper.Map<ClimbRoute, GetClimbRouteDTO>(route);
        }
    }
}
