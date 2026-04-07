using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Organizations;
using ClimbEdge.Domain.Interfaces;
using ClimbEdge.Domain.Repositories.Organizations;
using MediatR;

namespace ClimbEdge.Application.Queries.OrganizationQuery
{
    public record GetOrganizationsQuery(bool? PublicOnly = null, string? Country = null, int Page = 1, int PageSize = 20) : IRequest<IEnumerable<GetOrganizationDTO>>;

    public class GetOrganizationsQueryHandler : IRequestHandler<GetOrganizationsQuery, IEnumerable<GetOrganizationDTO>>
    {
        private readonly IOrganizationRepository _organizationRepository;

        public GetOrganizationsQueryHandler(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task<IEnumerable<GetOrganizationDTO>> Handle(GetOrganizationsQuery request, CancellationToken cancellationToken)
        {
            var orgs = await _organizationRepository.GetAsync(
                page: request.Page,
                criteria: o => !o.IsDeleted
                    && (request.PublicOnly == null || o.IsPublic == request.PublicOnly)
                    && (request.Country == null || o.Country == request.Country),
                orderSelectors: new[] { new OrderSelectors("Name", false) },
                pageSize: request.PageSize
            );
            return orgs.Select(o => Mapper.Map<Organization, GetOrganizationDTO>(o));
        }
    }
}
