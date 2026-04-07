using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using ClimbEdge.Domain.Repositories.Mountains.Itinerary;
using MediatR;

namespace ClimbEdge.Application.Queries.ExpeditionQuery
{
    public record GetExpeditionEquipmentQuery(long ExpeditionId) : IRequest<IEnumerable<GetExpeditionEquipmentDTO>>;

    public class GetExpeditionEquipmentQueryHandler
        : IRequestHandler<GetExpeditionEquipmentQuery, IEnumerable<GetExpeditionEquipmentDTO>>
    {
        private readonly IExpeditionEquipmentRepository _equipmentRepository;

        public GetExpeditionEquipmentQueryHandler(IExpeditionEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public async Task<IEnumerable<GetExpeditionEquipmentDTO>> Handle(
            GetExpeditionEquipmentQuery request, CancellationToken cancellationToken)
        {
            var items = await _equipmentRepository.GetAsync(
                criteria: e => e.ExpeditionId == request.ExpeditionId && !e.IsDeleted);

            return items.Select(e => Mapper.Map<ExpeditionEquipment, GetExpeditionEquipmentDTO>(e));
        }
    }
}
