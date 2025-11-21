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
    public class MountainExpeditionLogRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService, GeometryFactory geometryFactory) : Repository<MountainExpeditionLog>(climbEdgeContext, cacheService), IMountainExpeditionLogRepository
    {
        public GeometryFactory GetGeometryFactory()
        {
            return geometryFactory;
        }
    }
}
