using ClimbEdge.Domain.Repositories.Climbing;
using MediatR;

namespace ClimbEdge.Application.Commands.ClimbZoneCommand
{
    public record DeleteClimbZoneCommand(Guid ZoneUid) : IRequest;

    public class DeleteClimbZoneCommandHandler : IRequestHandler<DeleteClimbZoneCommand>
    {
        private readonly IClimbZoneRepository _climbZoneRepository;

        public DeleteClimbZoneCommandHandler(IClimbZoneRepository climbZoneRepository)
        {
            _climbZoneRepository = climbZoneRepository;
        }

        public async Task Handle(DeleteClimbZoneCommand request, CancellationToken cancellationToken)
        {
            await _climbZoneRepository.DeleteAsync(request.ZoneUid);
            await _climbZoneRepository.SaveChangesAsync();
        }
    }
}
