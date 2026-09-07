using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Repositories.Climbing;
using MediatR;

namespace ClimbEdge.Application.Queries.ClimbRouteQuery
{
    public record GetClimbTagsQuery() : IRequest<IEnumerable<GetClimbTagDTO>>;

    public class GetClimbTagsQueryHandler : IRequestHandler<GetClimbTagsQuery, IEnumerable<GetClimbTagDTO>>
    {
        private readonly IClimbTagRepository _climbTagRepository;

        public GetClimbTagsQueryHandler(IClimbTagRepository climbTagRepository)
        {
            _climbTagRepository = climbTagRepository;
        }

        public async Task<IEnumerable<GetClimbTagDTO>> Handle(GetClimbTagsQuery request, CancellationToken cancellationToken)
        {
            var tags = await _climbTagRepository.GetAsync(criteria: t => !t.IsDeleted);
            return tags.OrderBy(t => t.Name).Select(t => new GetClimbTagDTO
            {
                Uid = t.Uid,
                Slug = t.Slug,
                Name = t.Name,
                Description = t.Description,
                CreatedAt = t.CreatedAt
            });
        }
    }
}
