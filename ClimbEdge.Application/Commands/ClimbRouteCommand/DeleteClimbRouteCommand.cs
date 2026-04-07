using ClimbEdge.Domain.Repositories.Climbing;
using MediatR;

namespace ClimbEdge.Application.Commands.ClimbRouteCommand
{
    public record DeleteClimbRouteCommand(Guid RouteUid) : IRequest;

    public class DeleteClimbRouteCommandHandler : IRequestHandler<DeleteClimbRouteCommand>
    {
        private readonly IClimbRouteRepository _climbRouteRepository;

        public DeleteClimbRouteCommandHandler(IClimbRouteRepository climbRouteRepository)
        {
            _climbRouteRepository = climbRouteRepository;
        }

        public async Task Handle(DeleteClimbRouteCommand request, CancellationToken cancellationToken)
        {
            await _climbRouteRepository.DeleteAsync(request.RouteUid);
            await _climbRouteRepository.SaveChangesAsync();
        }
    }
}
