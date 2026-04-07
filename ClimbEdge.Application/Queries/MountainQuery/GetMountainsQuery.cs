using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Mountains;
using ClimbEdge.Domain.Repositories.Mountains;
using MediatR;

namespace ClimbEdge.Application.Queries.MountainQuery
{
    public record GetMountainsQuery() : IRequest<IEnumerable<GetMountainDTO>>;

    public class GetMountainsQueryHandler : IRequestHandler<GetMountainsQuery, IEnumerable<GetMountainDTO>>
    {
        private readonly IMountainRepository _mountainRepository;

        public GetMountainsQueryHandler(IMountainRepository mountainRepository)
        {
            _mountainRepository = mountainRepository;
        }

        public async Task<IEnumerable<GetMountainDTO>> Handle(
            GetMountainsQuery request, CancellationToken cancellationToken)
        {
            var mountains = await _mountainRepository.GetAsync(
                criteria: m => m.IsActive && !m.IsDeleted);

            return mountains
                .OrderBy(m => m.Name)
                .Select(m => Mapper.Map<Mountain, GetMountainDTO>(m));
        }
    }
}
