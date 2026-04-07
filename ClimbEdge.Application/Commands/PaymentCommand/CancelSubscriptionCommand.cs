using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Payment;
using ClimbEdge.Domain.Enums.Payment;
using ClimbEdge.Domain.Repositories.Payment;
using MediatR;

namespace ClimbEdge.Application.Commands.PaymentCommand
{
    public record CancelSubscriptionCommand(CancelSubscriptionDTO entity) : IRequest<GetSubscriptionDTO>;

    public class CancelSubscriptionCommandHandler : IRequestHandler<CancelSubscriptionCommand, GetSubscriptionDTO>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public CancelSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<GetSubscriptionDTO> Handle(CancelSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var subscription = await _subscriptionRepository.GetAsync(request.entity.SubscriptionUid);
            if (subscription == null) throw new InvalidOperationException("Subscription not found.");
            if (subscription.Status == SubscriptionStatus.Cancelled) throw new InvalidOperationException("Subscription is already cancelled.");

            subscription.Status = SubscriptionStatus.Cancelled;
            subscription.CancelledAt = DateTime.UtcNow;
            subscription.CancellationReason = request.entity.CancellationReason;
            subscription.AutoRenew = false;
            subscription.UpdateTimestamps();
            await _subscriptionRepository.UpdateAsync(subscription);
            await _subscriptionRepository.SaveChangesAsync();
            return Mapper.Map<Subscription, GetSubscriptionDTO>(subscription);
        }
    }
}
