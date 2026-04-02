using ClimbEdge.Domain.Entities.Organizations;
using ClimbEdge.Domain.Repositories.Organizations;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.Organizations
{
    public class OrganizationInstructorRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<OrganizationInstructor>(climbEdgeContext, cacheService), IOrganizationInstructorRepository
    {
    }
}
