using ClimbEdge.Domain.Entities.Organizations;
using ClimbEdge.Domain.Repositories.Organizations;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.Organizations
{
    public class OrganizationRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<Organization>(climbEdgeContext, cacheService), IOrganizationRepository
    {
    }
}
