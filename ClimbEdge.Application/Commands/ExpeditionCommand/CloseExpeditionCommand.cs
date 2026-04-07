using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Enums.Mountains.Itinerary;
using ClimbEdge.Domain.Repositories.Mountains.Itinerary;
using MediatR;

namespace ClimbEdge.Application.Commands.ExpeditionCommand
{
    public record CloseExpeditionCommand(CloseExpeditionDTO entity) : IRequest<bool>;

    public class CloseExpeditionCommandHandler : IRequestHandler<CloseExpeditionCommand, bool>
    {
        private readonly IExpeditionRepository _expeditionRepository;

        public CloseExpeditionCommandHandler(IExpeditionRepository expeditionRepository)
        {
            _expeditionRepository = expeditionRepository;
        }

        public async Task<bool> Handle(CloseExpeditionCommand request, CancellationToken cancellationToken)
        {
            var dto = request.entity;

            var expedition = await _expeditionRepository.GetAsync(dto.ExpeditionUid);
            if (expedition is null)
                throw new InvalidOperationException($"Expedition {dto.ExpeditionUid} not found.");

            var closingStatuses = new[]
            {
                ExpeditionStatus.Completed, ExpeditionStatus.Cancelled, ExpeditionStatus.Postponed
            };

            if (!closingStatuses.Contains(dto.FinalStatus))
                throw new InvalidOperationException($"'{dto.FinalStatus}' is not a valid closing status.");

            expedition.Status = dto.FinalStatus;

            if (dto.ActualDurationDays.HasValue)
                expedition.ActualDurationDays = dto.ActualDurationDays.Value;

            if (!string.IsNullOrWhiteSpace(dto.FinalNotes))
            {
                expedition.BaseCampInfo ??= new Dictionary<string, object>();
                expedition.BaseCampInfo["closingNotes"] = dto.FinalNotes;
                expedition.BaseCampInfo["closedAt"] = DateTime.UtcNow.ToString("O");
            }

            expedition.UpdateTimestamps();

            await _expeditionRepository.UpdateAsync(expedition);
            await _expeditionRepository.SaveChangesAsync();

            return true;
        }
    }
}
