using ClimbEdge.Domain.Entities.Mountains;
using ClimbEdge.Domain.Repositories.Mountains;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Repositories.Mountains
{
    public class MountainRouteRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService) : Repository<MountainRoute>(climbEdgeContext, cacheService), IMountainRouteRepository
    {
    }
}
