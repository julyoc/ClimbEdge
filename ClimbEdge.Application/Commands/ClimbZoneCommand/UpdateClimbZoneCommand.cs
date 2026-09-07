using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Climbing;
using ClimbEdge.Domain.Repositories.Climbing;
using MediatR;
using NetTopologySuite.IO;

namespace ClimbEdge.Application.Commands.ClimbZoneCommand
{
    public record UpdateClimbZoneCommand(Guid ZoneUid, UpdateClimbZoneDTO entity) : IRequest<GetClimbZoneDTO>;

    public class UpdateClimbZoneCommandHandler : IRequestHandler<UpdateClimbZoneCommand, GetClimbZoneDTO>
    {
        private readonly IClimbZoneRepository _climbZoneRepository;

        public UpdateClimbZoneCommandHandler(IClimbZoneRepository climbZoneRepository)
        {
            _climbZoneRepository = climbZoneRepository;
        }

        public async Task<GetClimbZoneDTO> Handle(UpdateClimbZoneCommand request, CancellationToken cancellationToken)
        {
            var zone = await _climbZoneRepository.GetAsync(request.ZoneUid)
                ?? throw new InvalidOperationException("Climb zone not found.");

            Mapper.MapUpdate(request.entity, zone);

            if (!string.IsNullOrWhiteSpace(request.entity.LocationWkt))
            {
                var reader = new WKTReader();
                zone.Location = reader.Read(request.entity.LocationWkt) as NetTopologySuite.Geometries.Point;
            }

            zone.UpdateTimestamps();
            await _climbZoneRepository.UpdateAsync(zone);
            await _climbZoneRepository.SaveChangesAsync();
            return ClimbZoneMapper.ToDTO(zone);
        }
    }
}
