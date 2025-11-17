using ClimbEdge.Domain.Entities.Mountains;
using ClimbEdge.Domain.Repositories.Mountains;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Repositories.Mountains
{
    public class RouteFileRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService) : Repository<RouteFile>(climbEdgeContext, cacheService), IRouteFileRepository
    {
    }
}
