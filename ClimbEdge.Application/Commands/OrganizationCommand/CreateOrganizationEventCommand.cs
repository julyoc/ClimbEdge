using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Organizations;
using ClimbEdge.Domain.Repositories.Organizations;
using MediatR;

namespace ClimbEdge.Application.Commands.OrganizationCommand
{
    public record CreateOrganizationEventCommand(CreateOrganizationEventDTO entity) : IRequest<GetOrganizationEventDTO>;

    public class CreateOrganizationEventCommandHandler
        : IRequestHandler<CreateOrganizationEventCommand, GetOrganizationEventDTO>
    {
        private readonly IOrganizationEventRepository _eventRepository;

        public CreateOrganizationEventCommandHandler(IOrganizationEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<GetOrganizationEventDTO> Handle(
            CreateOrganizationEventCommand request, CancellationToken cancellationToken)
        {
            var orgEvent = Mapper.Map<CreateOrganizationEventDTO, OrganizationEvent>(request.entity);
            orgEvent.InitializeSlug();
            await _eventRepository.AddAsync(orgEvent);
            await _eventRepository.SaveChangesAsync();
            return Mapper.Map<OrganizationEvent, GetOrganizationEventDTO>(orgEvent);
        }
    }
}
