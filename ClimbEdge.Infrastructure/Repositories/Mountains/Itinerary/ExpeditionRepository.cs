using ClimbEdge.Domain.Entities.Mountains;
using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using ClimbEdge.Domain.Repositories.Mountains;
using ClimbEdge.Domain.Repositories.Mountains.Itinerary;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Repositories.Mountains.Itinerary
{
    public class ExpeditionRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService, GeometryFactory geometryFactory) : Repository<Expedition>(climbEdgeContext, cacheService), IExpeditionRepository
    {
        public GeometryFactory GetGeometryFactory()
        {
            return geometryFactory;
        }
    }
}
