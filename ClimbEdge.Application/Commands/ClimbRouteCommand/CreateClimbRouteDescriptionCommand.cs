using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Entities.Climbing;
using ClimbEdge.Domain.Repositories.Climbing;
using MediatR;

namespace ClimbEdge.Application.Commands.ClimbRouteCommand
{
    public record CreateClimbRouteDescriptionCommand(CreateClimbRouteDescriptionDTO entity) : IRequest<GetClimbRouteDescriptionDTO>;

    public class CreateClimbRouteDescriptionCommandHandler : IRequestHandler<CreateClimbRouteDescriptionCommand, GetClimbRouteDescriptionDTO>
    {
        private readonly IClimbRouteDescriptionRepository _descriptionRepository;

        public CreateClimbRouteDescriptionCommandHandler(IClimbRouteDescriptionRepository descriptionRepository)
        {
            _descriptionRepository = descriptionRepository;
        }

        public async Task<GetClimbRouteDescriptionDTO> Handle(CreateClimbRouteDescriptionCommand request, CancellationToken cancellationToken)
        {
            var dto = request.entity;
            var description = new ClimbRouteDescription
            {
                ClimbRouteId = dto.ClimbRouteId,
                Content = dto.Content
            };

            description.InitializeSlug();
            await _descriptionRepository.AddAsync(description);
            await _descriptionRepository.SaveChangesAsync();

            return new GetClimbRouteDescriptionDTO
            {
                Uid = description.Uid,
                Slug = description.Slug,
                ClimbRouteId = description.ClimbRouteId,
                Content = description.Content,
                CreatedAt = description.CreatedAt
            };
        }
    }
}
