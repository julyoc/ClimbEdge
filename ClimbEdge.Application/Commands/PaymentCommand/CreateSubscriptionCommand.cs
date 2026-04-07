using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Payment;
using ClimbEdge.Domain.Enums.Payment;
using ClimbEdge.Domain.Repositories.Payment;
using MediatR;

namespace ClimbEdge.Application.Commands.PaymentCommand
{
    public record CreateSubscriptionCommand(CreateSubscriptionDTO entity) : IRequest<GetSubscriptionDTO>;

    public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, GetSubscriptionDTO>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IPlanRepository _planRepository;

        public CreateSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository, IPlanRepository planRepository)
        {
            _subscriptionRepository = subscriptionRepository;
            _planRepository = planRepository;
        }

        public async Task<GetSubscriptionDTO> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var activeSubscriptions = await _subscriptionRepository.GetAsync(
                criteria: s => s.UserId == request.entity.UserId
                    && s.Status == SubscriptionStatus.Active && !s.IsDeleted);
            if (activeSubscriptions.Any()) throw new InvalidOperationException("User already has an active subscription.");

            var planExists = await _planRepository.ExistsAsync(request.entity.PlanId.ToString());
            if (!planExists) throw new InvalidOperationException("Plan not found.");

            var subscription = new Subscription
            {
                UserId = request.entity.UserId,
                PlanId = request.entity.PlanId,
                Status = SubscriptionStatus.Active,
                StartDate = DateTime.UtcNow,
                AutoRenew = request.entity.AutoRenew,
                NextBillingDate = DateTime.UtcNow.AddMonths(1)
            };
            await _subscriptionRepository.AddAsync(subscription);
            await _subscriptionRepository.SaveChangesAsync();
            return Mapper.Map<Subscription, GetSubscriptionDTO>(subscription);
        }
    }
}
