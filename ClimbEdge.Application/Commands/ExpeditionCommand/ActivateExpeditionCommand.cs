using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Enums.Mountains.Itinerary;
using ClimbEdge.Domain.Repositories.Mountains.Itinerary;
using MediatR;

namespace ClimbEdge.Application.Commands.ExpeditionCommand
{
    public record ActivateExpeditionCommand(ActivateExpeditionDTO entity) : IRequest<bool>;

    public class ActivateExpeditionCommandHandler : IRequestHandler<ActivateExpeditionCommand, bool>
    {
        private readonly IExpeditionRepository _expeditionRepository;

        public ActivateExpeditionCommandHandler(IExpeditionRepository expeditionRepository)
        {
            _expeditionRepository = expeditionRepository;
        }

        public async Task<bool> Handle(ActivateExpeditionCommand request, CancellationToken cancellationToken)
        {
            var dto = request.entity;

            var expedition = await _expeditionRepository.GetAsync(dto.ExpeditionUid);
            if (expedition is null)
                throw new InvalidOperationException($"Expedition {dto.ExpeditionUid} not found.");

            if (expedition.Status == ExpeditionStatus.InProgress)
                return true; // idempotent

            if (expedition.Status != ExpeditionStatus.Planning && expedition.Status != ExpeditionStatus.Scheduled)
                throw new InvalidOperationException($"Expedition cannot be activated from status '{expedition.Status}'.");

            expedition.Status = ExpeditionStatus.InProgress;

            if (!string.IsNullOrWhiteSpace(dto.ActivationNote))
            {
                expedition.BaseCampInfo ??= new Dictionary<string, object>();
                expedition.BaseCampInfo["activationNote"] = dto.ActivationNote;
                expedition.BaseCampInfo["activatedAt"] = DateTime.UtcNow.ToString("O");
            }

            expedition.UpdateTimestamps();

            await _expeditionRepository.UpdateAsync(expedition);
            await _expeditionRepository.SaveChangesAsync();

            return true;
        }
    }
}
