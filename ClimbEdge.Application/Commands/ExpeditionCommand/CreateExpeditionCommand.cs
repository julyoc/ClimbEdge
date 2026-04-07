using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using ClimbEdge.Domain.Enums.Mountains.Itinerary;
using ClimbEdge.Domain.Repositories.Mountains.Itinerary;
using MediatR;

namespace ClimbEdge.Application.Commands.ExpeditionCommand
{
    public record CreateExpeditionCommand(CreateExpeditionDTO entity) : IRequest<GetExpeditionDTO>;

    public class CreateExpeditionCommandHandler : IRequestHandler<CreateExpeditionCommand, GetExpeditionDTO>
    {
        private readonly IExpeditionRepository _expeditionRepository;

        public CreateExpeditionCommandHandler(IExpeditionRepository expeditionRepository)
        {
            _expeditionRepository = expeditionRepository;
        }

        public async Task<GetExpeditionDTO> Handle(CreateExpeditionCommand request, CancellationToken cancellationToken)
        {
            var expedition = Mapper.Map<CreateExpeditionDTO, Expedition>(request.entity);
            expedition.Status = ExpeditionStatus.Planning;
            await _expeditionRepository.AddAsync(expedition);
            await _expeditionRepository.SaveChangesAsync();
            return Mapper.Map<Expedition, GetExpeditionDTO>(expedition);
        }
    }
}
