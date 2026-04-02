using ClimbEdge.Domain.Entities.Organizations;
using ClimbEdge.Domain.Repositories.Organizations;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.Organizations
{
    public class OrganizationFileRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<OrganizationFile>(climbEdgeContext, cacheService), IOrganizationFileRepository
    {
    }
}
