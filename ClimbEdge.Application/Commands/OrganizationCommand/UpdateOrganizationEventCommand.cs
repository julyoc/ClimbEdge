using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Organizations;
using ClimbEdge.Domain.Repositories.Organizations;
using MediatR;

namespace ClimbEdge.Application.Commands.OrganizationCommand
{
    public record UpdateOrganizationEventCommand(Guid EventUid, UpdateOrganizationEventDTO entity) : IRequest<GetOrganizationEventDTO>;

    public class UpdateOrganizationEventCommandHandler
        : IRequestHandler<UpdateOrganizationEventCommand, GetOrganizationEventDTO>
    {
        private readonly IOrganizationEventRepository _eventRepository;

        public UpdateOrganizationEventCommandHandler(IOrganizationEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<GetOrganizationEventDTO> Handle(
            UpdateOrganizationEventCommand request, CancellationToken cancellationToken)
        {
            var orgEvent = await _eventRepository.GetAsync(request.EventUid)
                ?? throw new InvalidOperationException("Event not found.");

            Mapper.MapUpdate(request.entity, orgEvent);
            orgEvent.UpdateTimestamps();
            await _eventRepository.UpdateAsync(orgEvent);
            await _eventRepository.SaveChangesAsync();
            return Mapper.Map<OrganizationEvent, GetOrganizationEventDTO>(orgEvent);
        }
    }
}
