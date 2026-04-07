using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Organizations;
using ClimbEdge.Domain.Interfaces;
using ClimbEdge.Domain.Repositories.Organizations;
using MediatR;

namespace ClimbEdge.Application.Queries.OrganizationQuery
{
    public record GetOrganizationQuery(Guid OrganizationUid) : IRequest<GetOrganizationDTO?>;

    public class GetOrganizationQueryHandler : IRequestHandler<GetOrganizationQuery, GetOrganizationDTO?>
    {
        private readonly IOrganizationRepository _organizationRepository;

        public GetOrganizationQueryHandler(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task<GetOrganizationDTO?> Handle(GetOrganizationQuery request, CancellationToken cancellationToken)
        {
            var org = await _organizationRepository.GetAsync(request.OrganizationUid);
            if (org == null) return null;
            return Mapper.Map<Organization, GetOrganizationDTO>(org);
        }
    }
}
