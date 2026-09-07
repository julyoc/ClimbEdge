using ClimbEdge.Domain.Repositories.Mountains;
using MediatR;

namespace ClimbEdge.Application.Commands.MountainCommand
{
    public record DeleteMountainCommand(Guid Uid) : IRequest;

    public class DeleteMountainCommandHandler : IRequestHandler<DeleteMountainCommand>
    {
        private readonly IMountainRepository _mountainRepository;

        public DeleteMountainCommandHandler(IMountainRepository mountainRepository)
        {
            _mountainRepository = mountainRepository;
        }

        public async Task Handle(DeleteMountainCommand request, CancellationToken cancellationToken)
        {
            await _mountainRepository.DeleteAsync(request.Uid);
            await _mountainRepository.SaveChangesAsync();
        }
    }
}
