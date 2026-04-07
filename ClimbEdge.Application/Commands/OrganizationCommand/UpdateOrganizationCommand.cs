using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Organizations;
using ClimbEdge.Domain.Repositories.Organizations;
using MediatR;

namespace ClimbEdge.Application.Commands.OrganizationCommand
{
    public record UpdateOrganizationCommand(Guid OrganizationUid, UpdateOrganizationDTO entity) : IRequest<GetOrganizationDTO>;

    public class UpdateOrganizationCommandHandler : IRequestHandler<UpdateOrganizationCommand, GetOrganizationDTO>
    {
        private readonly IOrganizationRepository _organizationRepository;

        public UpdateOrganizationCommandHandler(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task<GetOrganizationDTO> Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
        {
            var organization = await _organizationRepository.GetAsync(request.OrganizationUid);
            if (organization == null) throw new InvalidOperationException("Organization not found.");
            Mapper.MapUpdate(request.entity, organization);
            organization.UpdateTimestamps();
            await _organizationRepository.UpdateAsync(organization);
            await _organizationRepository.SaveChangesAsync();
            return Mapper.Map<Organization, GetOrganizationDTO>(organization);
        }
    }
}
