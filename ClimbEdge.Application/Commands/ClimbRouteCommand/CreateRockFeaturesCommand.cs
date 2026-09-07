using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Entities.Climbing;
using ClimbEdge.Domain.Repositories.Climbing;
using MediatR;

namespace ClimbEdge.Application.Commands.ClimbRouteCommand
{
    public record CreateRockFeaturesCommand(CreateRockFeaturesDTO entity) : IRequest<GetRockFeaturesDTO>;

    public class CreateRockFeaturesCommandHandler : IRequestHandler<CreateRockFeaturesCommand, GetRockFeaturesDTO>
    {
        private readonly IRockFeaturesRepository _rockFeaturesRepository;

        public CreateRockFeaturesCommandHandler(IRockFeaturesRepository rockFeaturesRepository)
        {
            _rockFeaturesRepository = rockFeaturesRepository;
        }

        public async Task<GetRockFeaturesDTO> Handle(CreateRockFeaturesCommand request, CancellationToken cancellationToken)
        {
            var features = new RockFeatures
            {
                ClimbRouteId = request.entity.ClimbRouteId,
                Description = request.entity.Description,
                RockType = request.entity.RockType
            };

            features.InitializeSlug();
            await _rockFeaturesRepository.AddAsync(features);
            await _rockFeaturesRepository.SaveChangesAsync();

            return new GetRockFeaturesDTO
            {
                Uid = features.Uid,
                Slug = features.Slug,
                ClimbRouteId = features.ClimbRouteId,
                Description = features.Description,
                RockType = features.RockType,
                CreatedAt = features.CreatedAt
            };
        }
    }
}
