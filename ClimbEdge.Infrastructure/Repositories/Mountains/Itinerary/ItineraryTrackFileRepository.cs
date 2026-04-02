using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using ClimbEdge.Domain.Repositories.Mountains.Itinerary;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.Mountains.Itinerary
{
    public class ItineraryTrackFileRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<ItineraryTrackFile>(climbEdgeContext, cacheService), IItineraryTrackFileRepository
    {
    }
}
