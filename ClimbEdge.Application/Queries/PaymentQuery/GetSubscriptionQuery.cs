using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Payment;
using ClimbEdge.Domain.Repositories.Payment;
using MediatR;

namespace ClimbEdge.Application.Queries.PaymentQuery
{
    public record GetSubscriptionQuery(long UserId) : IRequest<GetSubscriptionDTO?>;

    public class GetSubscriptionQueryHandler : IRequestHandler<GetSubscriptionQuery, GetSubscriptionDTO?>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public GetSubscriptionQueryHandler(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<GetSubscriptionDTO?> Handle(GetSubscriptionQuery request, CancellationToken cancellationToken)
        {
            var subscriptions = await _subscriptionRepository.GetAsync(
                criteria: s => s.UserId == request.UserId && !s.IsDeleted,
                orderSelectors: new[] { new Domain.Interfaces.OrderSelectors("StartDate", true) });
            var subscription = subscriptions.FirstOrDefault();
            if (subscription == null) return null;
            return Mapper.Map<Subscription, GetSubscriptionDTO>(subscription);
        }
    }
}
