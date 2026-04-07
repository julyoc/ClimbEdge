using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using ClimbEdge.Domain.Repositories.Mountains.Itinerary;
using MediatR;

namespace ClimbEdge.Application.Commands.ExpeditionCommand
{
    public record AddExpeditionEquipmentCommand(AddExpeditionEquipmentDTO entity) : IRequest;

    public class AddExpeditionEquipmentCommandHandler : IRequestHandler<AddExpeditionEquipmentCommand>
    {
        private readonly IExpeditionEquipmentRepository _equipmentRepository;

        public AddExpeditionEquipmentCommandHandler(IExpeditionEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public async Task Handle(AddExpeditionEquipmentCommand request, CancellationToken cancellationToken)
        {
            var existing = await _equipmentRepository.GetAsync(
                criteria: e => e.ExpeditionId == request.entity.ExpeditionId
                    && e.EquipmentId == request.entity.EquipmentId && !e.IsDeleted);

            if (existing.Any())
                throw new InvalidOperationException("This equipment is already listed for the expedition.");

            var entry = new ExpeditionEquipment
            {
                ExpeditionId = request.entity.ExpeditionId,
                EquipmentId = request.entity.EquipmentId,
                Quantity = request.entity.Quantity,
                IsMandatory = request.entity.IsMandatory,
                IsProvided = request.entity.IsProvided,
                ResponsibleParticipant = request.entity.ResponsibleParticipant,
                Notes = request.entity.Notes
            };
            entry.InitializeSlug();

            await _equipmentRepository.AddAsync(entry);
            await _equipmentRepository.SaveChangesAsync();
        }
    }
}
