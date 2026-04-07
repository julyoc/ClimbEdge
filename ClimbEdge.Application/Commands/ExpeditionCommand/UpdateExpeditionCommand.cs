using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using ClimbEdge.Domain.Repositories.Mountains.Itinerary;
using MediatR;

namespace ClimbEdge.Application.Commands.ExpeditionCommand
{
    public record UpdateExpeditionCommand(Guid ExpeditionUid, UpdateExpeditionDTO entity) : IRequest<GetExpeditionDTO>;

    public class UpdateExpeditionCommandHandler : IRequestHandler<UpdateExpeditionCommand, GetExpeditionDTO>
    {
        private readonly IExpeditionRepository _expeditionRepository;

        public UpdateExpeditionCommandHandler(IExpeditionRepository expeditionRepository)
        {
            _expeditionRepository = expeditionRepository;
        }

        public async Task<GetExpeditionDTO> Handle(UpdateExpeditionCommand request, CancellationToken cancellationToken)
        {
            var expedition = await _expeditionRepository.GetAsync(request.ExpeditionUid);
            if (expedition == null) throw new InvalidOperationException("Expedition not found.");
            Mapper.MapUpdate(request.entity, expedition);
            expedition.UpdateTimestamps();
            await _expeditionRepository.UpdateAsync(expedition);
            await _expeditionRepository.SaveChangesAsync();
            return Mapper.Map<Expedition, GetExpeditionDTO>(expedition);
        }
    }
}
