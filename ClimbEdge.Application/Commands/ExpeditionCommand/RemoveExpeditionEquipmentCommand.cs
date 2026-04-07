using ClimbEdge.Domain.Repositories.Mountains.Itinerary;
using MediatR;

namespace ClimbEdge.Application.Commands.ExpeditionCommand
{
    public record RemoveExpeditionEquipmentCommand(long EquipmentEntryId) : IRequest;

    public class RemoveExpeditionEquipmentCommandHandler : IRequestHandler<RemoveExpeditionEquipmentCommand>
    {
        private readonly IExpeditionEquipmentRepository _equipmentRepository;

        public RemoveExpeditionEquipmentCommandHandler(IExpeditionEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public async Task Handle(RemoveExpeditionEquipmentCommand request, CancellationToken cancellationToken)
        {
            var entry = (await _equipmentRepository.GetAsync(
                criteria: e => e.Id == request.EquipmentEntryId && !e.IsDeleted))
                .FirstOrDefault()
                ?? throw new KeyNotFoundException($"Expedition equipment entry {request.EquipmentEntryId} not found.");

            await _equipmentRepository.DeleteAsync(entry.Uid);
            await _equipmentRepository.SaveChangesAsync();
        }
    }
}
