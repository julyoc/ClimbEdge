using ClimbEdge.Domain.Entities.Help;
using ClimbEdge.Domain.Repositories.Help;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.Help
{
    public class SupportTicketRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<SupportTicket>(climbEdgeContext, cacheService), ISupportTicketRepository
    {
    }
}
