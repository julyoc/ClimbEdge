using ClimbEdge.Domain.Repositories.Mountains.Itinerary;
using MediatR;

namespace ClimbEdge.Application.Commands.ExpeditionCommand
{
    public record DeleteExpeditionCommand(Guid Uid) : IRequest;

    public class DeleteExpeditionCommandHandler : IRequestHandler<DeleteExpeditionCommand>
    {
        private readonly IExpeditionRepository _expeditionRepository;

        public DeleteExpeditionCommandHandler(IExpeditionRepository expeditionRepository)
        {
            _expeditionRepository = expeditionRepository;
        }

        public async Task Handle(DeleteExpeditionCommand request, CancellationToken cancellationToken)
        {
            await _expeditionRepository.DeleteAsync(request.Uid);
            await _expeditionRepository.SaveChangesAsync();
        }
    }
}
