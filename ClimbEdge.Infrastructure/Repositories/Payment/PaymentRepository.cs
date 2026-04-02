using ClimbEdge.Domain.Repositories.Payment;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.Payment
{
    public class PaymentRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<global::ClimbEdge.Domain.Entities.Payment.Payment>(climbEdgeContext, cacheService), IPaymentRepository
    {
    }
}
