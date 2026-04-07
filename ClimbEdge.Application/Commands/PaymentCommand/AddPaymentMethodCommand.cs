using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Payment;
using ClimbEdge.Domain.Repositories.Payment;
using MediatR;

namespace ClimbEdge.Application.Commands.PaymentCommand
{
    public record AddPaymentMethodCommand(AddPaymentMethodDTO entity) : IRequest<GetPaymentMethodDTO>;

    public class AddPaymentMethodCommandHandler : IRequestHandler<AddPaymentMethodCommand, GetPaymentMethodDTO>
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;

        public AddPaymentMethodCommandHandler(IPaymentMethodRepository paymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }

        public async Task<GetPaymentMethodDTO> Handle(
            AddPaymentMethodCommand request, CancellationToken cancellationToken)
        {
            var method = Mapper.Map<AddPaymentMethodDTO, PaymentMethod>(request.entity);
            method.InitializeSlug();
            await _paymentMethodRepository.AddAsync(method);
            await _paymentMethodRepository.SaveChangesAsync();
            return Mapper.Map<PaymentMethod, GetPaymentMethodDTO>(method);
        }
    }
}
