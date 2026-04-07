using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Climbing;
using ClimbEdge.Domain.Repositories.Climbing;
using MediatR;

namespace ClimbEdge.Application.Queries.ClimbZoneQuery
{
    public record GetClimbZoneQuery(Guid ZoneUid) : IRequest<GetClimbZoneDTO?>;

    public class GetClimbZoneQueryHandler : IRequestHandler<GetClimbZoneQuery, GetClimbZoneDTO?>
    {
        private readonly IClimbZoneRepository _climbZoneRepository;

        public GetClimbZoneQueryHandler(IClimbZoneRepository climbZoneRepository)
        {
            _climbZoneRepository = climbZoneRepository;
        }

        public async Task<GetClimbZoneDTO?> Handle(
            GetClimbZoneQuery request, CancellationToken cancellationToken)
        {
            var zone = await _climbZoneRepository.GetAsync(request.ZoneUid);
            if (zone is null) return null;
            return Mapper.Map<ClimbZone, GetClimbZoneDTO>(zone);
        }
    }
}
