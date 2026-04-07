using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Climbing;
using ClimbEdge.Domain.Repositories.Climbing;
using MediatR;

namespace ClimbEdge.Application.Commands.ClimbZoneCommand
{
    public record CreateClimbZoneCommand(CreateClimbZoneDTO entity) : IRequest<GetClimbZoneDTO>;

    public class CreateClimbZoneCommandHandler : IRequestHandler<CreateClimbZoneCommand, GetClimbZoneDTO>
    {
        private readonly IClimbZoneRepository _climbZoneRepository;

        public CreateClimbZoneCommandHandler(IClimbZoneRepository climbZoneRepository)
        {
            _climbZoneRepository = climbZoneRepository;
        }

        public async Task<GetClimbZoneDTO> Handle(CreateClimbZoneCommand request, CancellationToken cancellationToken)
        {
            var zone = Mapper.Map<CreateClimbZoneDTO, ClimbZone>(request.entity);
            zone.InitializeSlug();
            await _climbZoneRepository.AddAsync(zone);
            await _climbZoneRepository.SaveChangesAsync();
            return Mapper.Map<ClimbZone, GetClimbZoneDTO>(zone);
        }
    }
}
