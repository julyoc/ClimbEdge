using ClimbEdge.Domain.Repositories.Mountains;
using MediatR;

namespace ClimbEdge.Application.Commands.MountainCommand
{
    public record DeleteMountainRouteCommand(Guid Uid) : IRequest;

    public class DeleteMountainRouteCommandHandler : IRequestHandler<DeleteMountainRouteCommand>
    {
        private readonly IMountainRouteRepository _mountainRouteRepository;

        public DeleteMountainRouteCommandHandler(IMountainRouteRepository mountainRouteRepository)
        {
            _mountainRouteRepository = mountainRouteRepository;
        }

        public async Task Handle(DeleteMountainRouteCommand request, CancellationToken cancellationToken)
        {
            await _mountainRouteRepository.DeleteAsync(request.Uid);
            await _mountainRouteRepository.SaveChangesAsync();
        }
    }
}
