using ClimbEdge.Application.Commands.ExpeditionCommand;
using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Repositories.Mountains.Itinerary;
using MediatR;

namespace ClimbEdge.Application.Queries.ExpeditionQuery
{
    public record GetEquipmentCatalogQuery(long? CategoryId = null) : IRequest<IEnumerable<GetEquipmentDTO>>;

    public class GetEquipmentCatalogQueryHandler : IRequestHandler<GetEquipmentCatalogQuery, IEnumerable<GetEquipmentDTO>>
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public GetEquipmentCatalogQueryHandler(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public async Task<IEnumerable<GetEquipmentDTO>> Handle(GetEquipmentCatalogQuery request, CancellationToken cancellationToken)
        {
            var items = await _equipmentRepository.GetAsync(
                criteria: e => !e.IsDeleted
                    && (request.CategoryId == null || e.EquipmentCategoryId == request.CategoryId));

            return items
                .OrderBy(e => e.Name)
                .Select(CreateEquipmentCommandHandler.MapToDTO);
        }
    }
}
