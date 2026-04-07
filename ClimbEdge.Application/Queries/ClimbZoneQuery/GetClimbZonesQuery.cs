using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Climbing;
using ClimbEdge.Domain.Repositories.Climbing;
using MediatR;

namespace ClimbEdge.Application.Queries.ClimbZoneQuery
{
    public record GetClimbZonesQuery() : IRequest<IEnumerable<GetClimbZoneDTO>>;

    public class GetClimbZonesQueryHandler : IRequestHandler<GetClimbZonesQuery, IEnumerable<GetClimbZoneDTO>>
    {
        private readonly IClimbZoneRepository _climbZoneRepository;

        public GetClimbZonesQueryHandler(IClimbZoneRepository climbZoneRepository)
        {
            _climbZoneRepository = climbZoneRepository;
        }

        public async Task<IEnumerable<GetClimbZoneDTO>> Handle(
            GetClimbZonesQuery request, CancellationToken cancellationToken)
        {
            var zones = await _climbZoneRepository.GetAsync(
                criteria: z => !z.IsDeleted);

            return zones
                .OrderBy(z => z.Name)
                .Select(z => Mapper.Map<ClimbZone, GetClimbZoneDTO>(z));
        }
    }
}
