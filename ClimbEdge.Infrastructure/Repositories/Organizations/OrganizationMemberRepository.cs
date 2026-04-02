using ClimbEdge.Domain.Entities.Organizations;
using ClimbEdge.Domain.Repositories.Organizations;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.Organizations
{
    public class OrganizationMemberRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<OrganizationMember>(climbEdgeContext, cacheService), IOrganizationMemberRepository
    {
    }
}
