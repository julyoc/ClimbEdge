using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Repositories.Climbing;
using MediatR;

namespace ClimbEdge.Application.Queries.ClimbRouteQuery
{
    public record GetClimbRouteDescriptionsQuery(long ClimbRouteId) : IRequest<IEnumerable<GetClimbRouteDescriptionDTO>>;

    public class GetClimbRouteDescriptionsQueryHandler : IRequestHandler<GetClimbRouteDescriptionsQuery, IEnumerable<GetClimbRouteDescriptionDTO>>
    {
        private readonly IClimbRouteDescriptionRepository _descriptionRepository;

        public GetClimbRouteDescriptionsQueryHandler(IClimbRouteDescriptionRepository descriptionRepository)
        {
            _descriptionRepository = descriptionRepository;
        }

        public async Task<IEnumerable<GetClimbRouteDescriptionDTO>> Handle(GetClimbRouteDescriptionsQuery request, CancellationToken cancellationToken)
        {
            var descriptions = await _descriptionRepository.GetAsync(
                criteria: d => d.ClimbRouteId == request.ClimbRouteId && !d.IsDeleted);

            return descriptions.Select(d => new GetClimbRouteDescriptionDTO
            {
                Uid = d.Uid,
                Slug = d.Slug,
                ClimbRouteId = d.ClimbRouteId,
                Content = d.Content,
                CreatedAt = d.CreatedAt,
                UpdatedAt = d.UpdatedAt
            });
        }
    }
}
