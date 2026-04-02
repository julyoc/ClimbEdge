using ClimbEdge.Domain.Entities.Mountains.Itinerary.Logistics;
using ClimbEdge.Domain.Repositories.Mountains.Itinerary.Logistics;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.Mountains.Itinerary.Logistics
{
    public class TransportationRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<Transportation>(climbEdgeContext, cacheService), ITransportationRepository
    {
    }
}
