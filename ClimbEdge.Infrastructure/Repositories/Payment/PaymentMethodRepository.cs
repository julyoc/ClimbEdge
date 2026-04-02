using ClimbEdge.Domain.Entities.Payment;
using ClimbEdge.Domain.Repositories.Payment;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.Payment
{
    public class PaymentMethodRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<PaymentMethod>(climbEdgeContext, cacheService), IPaymentMethodRepository
    {
    }
}
