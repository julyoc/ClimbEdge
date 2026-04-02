using ClimbEdge.Domain.Entities.Mountains.Itinerary.Logistics;
using ClimbEdge.Domain.Repositories.Mountains.Itinerary.Logistics;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.Mountains.Itinerary.Logistics
{
    public class AccommodationRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<Accommodation>(climbEdgeContext, cacheService), IAccommodationRepository
    {
    }
}
