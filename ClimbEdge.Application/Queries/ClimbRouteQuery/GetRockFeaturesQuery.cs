using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Repositories.Climbing;
using MediatR;

namespace ClimbEdge.Application.Queries.ClimbRouteQuery
{
    public record GetRockFeaturesQuery(long ClimbRouteId) : IRequest<IEnumerable<GetRockFeaturesDTO>>;

    public class GetRockFeaturesQueryHandler : IRequestHandler<GetRockFeaturesQuery, IEnumerable<GetRockFeaturesDTO>>
    {
        private readonly IRockFeaturesRepository _rockFeaturesRepository;

        public GetRockFeaturesQueryHandler(IRockFeaturesRepository rockFeaturesRepository)
        {
            _rockFeaturesRepository = rockFeaturesRepository;
        }

        public async Task<IEnumerable<GetRockFeaturesDTO>> Handle(GetRockFeaturesQuery request, CancellationToken cancellationToken)
        {
            var features = await _rockFeaturesRepository.GetAsync(
                criteria: r => r.ClimbRouteId == request.ClimbRouteId && !r.IsDeleted);

            return features.Select(r => new GetRockFeaturesDTO
            {
                Uid = r.Uid,
                Slug = r.Slug,
                ClimbRouteId = r.ClimbRouteId,
                Description = r.Description,
                RockType = r.RockType,
                CreatedAt = r.CreatedAt
            });
        }
    }
}
