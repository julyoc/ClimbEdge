using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using ClimbEdge.Domain.Repositories.Mountains.Itinerary;
using MediatR;

namespace ClimbEdge.Application.Commands.ExpeditionCommand
{
    public record CreateEquipmentCommand(CreateEquipmentDTO entity) : IRequest<GetEquipmentDTO>;

    public class CreateEquipmentCommandHandler : IRequestHandler<CreateEquipmentCommand, GetEquipmentDTO>
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public CreateEquipmentCommandHandler(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public async Task<GetEquipmentDTO> Handle(CreateEquipmentCommand request, CancellationToken cancellationToken)
        {
            var dto = request.entity;

            var equipment = new Equipment
            {
                Name = dto.Name,
                EquipmentCategoryId = dto.EquipmentCategoryId,
                Description = dto.Description,
                IsPersonal = dto.IsPersonal,
                IsMandatory = dto.IsMandatory,
                Weight = dto.Weight,
                Brand = dto.Brand,
                Model = dto.Model,
                Specifications = dto.Specifications,
                ImageUrl = dto.ImageUrl
            };

            equipment.InitializeSlug();
            await _equipmentRepository.AddAsync(equipment);
            await _equipmentRepository.SaveChangesAsync();

            return MapToDTO(equipment);
        }

        internal static GetEquipmentDTO MapToDTO(Equipment e) => new()
        {
            Uid = e.Uid,
            Slug = e.Slug,
            Name = e.Name,
            EquipmentCategoryId = e.EquipmentCategoryId,
            Description = e.Description,
            IsPersonal = e.IsPersonal,
            IsMandatory = e.IsMandatory,
            Weight = e.Weight,
            Brand = e.Brand,
            Model = e.Model,
            Specifications = e.Specifications,
            ImageUrl = e.ImageUrl,
            CreatedAt = e.CreatedAt,
            UpdatedAt = e.UpdatedAt
        };
    }
}
