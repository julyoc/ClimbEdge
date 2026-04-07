using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Mountains;
using ClimbEdge.Domain.Repositories.Mountains;
using MediatR;

namespace ClimbEdge.Application.Queries.MountainQuery
{
    public record GetMountainQuery(Guid MountainUid) : IRequest<GetMountainDTO?>;

    public class GetMountainQueryHandler : IRequestHandler<GetMountainQuery, GetMountainDTO?>
    {
        private readonly IMountainRepository _mountainRepository;

        public GetMountainQueryHandler(IMountainRepository mountainRepository)
        {
            _mountainRepository = mountainRepository;
        }

        public async Task<GetMountainDTO?> Handle(
            GetMountainQuery request, CancellationToken cancellationToken)
        {
            var mountain = await _mountainRepository.GetAsync(request.MountainUid);
            if (mountain is null) return null;
            return Mapper.Map<Mountain, GetMountainDTO>(mountain);
        }
    }
}
