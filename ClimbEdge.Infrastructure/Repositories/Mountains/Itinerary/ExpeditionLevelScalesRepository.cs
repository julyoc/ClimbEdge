using ClimbEdge.Domain.Entities.Mountains;
using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using ClimbEdge.Domain.Repositories.Mountains;
using ClimbEdge.Domain.Repositories.Mountains.Itinerary;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Repositories.Mountains.Itinerary
{
    public class ExpeditionLevelScalesRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService) : Repository<ExpeditionLevelScales>(climbEdgeContext, cacheService), IExpeditionLevelScalesRepostory
    {
    }
}
