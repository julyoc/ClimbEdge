using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Organizations;
using ClimbEdge.Domain.Repositories.Organizations;
using MediatR;

namespace ClimbEdge.Application.Commands.OrganizationCommand
{
    public record CreateOrganizationCommand(CreateOrganizationDTO entity) : IRequest<GetOrganizationDTO>;

    public class CreateOrganizationCommandHandler : IRequestHandler<CreateOrganizationCommand, GetOrganizationDTO>
    {
        private readonly IOrganizationRepository _organizationRepository;

        public CreateOrganizationCommandHandler(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task<GetOrganizationDTO> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
        {
            var organization = Mapper.Map<CreateOrganizationDTO, Organization>(request.entity);
            await _organizationRepository.AddAsync(organization);
            await _organizationRepository.SaveChangesAsync();
            return Mapper.Map<Organization, GetOrganizationDTO>(organization);
        }
    }
}
