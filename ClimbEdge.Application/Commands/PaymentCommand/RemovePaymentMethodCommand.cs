using ClimbEdge.Domain.Repositories.Payment;
using MediatR;

namespace ClimbEdge.Application.Commands.PaymentCommand
{
    public record RemovePaymentMethodCommand(Guid PaymentMethodUid) : IRequest;

    public class RemovePaymentMethodCommandHandler : IRequestHandler<RemovePaymentMethodCommand>
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;

        public RemovePaymentMethodCommandHandler(IPaymentMethodRepository paymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }

        public async Task Handle(RemovePaymentMethodCommand request, CancellationToken cancellationToken)
        {
            await _paymentMethodRepository.DeleteAsync(request.PaymentMethodUid);
            await _paymentMethodRepository.SaveChangesAsync();
        }
    }
}
