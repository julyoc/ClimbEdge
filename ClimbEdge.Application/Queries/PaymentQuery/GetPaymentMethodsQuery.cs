using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Payment;
using ClimbEdge.Domain.Repositories.Payment;
using MediatR;

namespace ClimbEdge.Application.Queries.PaymentQuery
{
    public record GetPaymentMethodsQuery(long UserId) : IRequest<IEnumerable<GetPaymentMethodDTO>>;

    public class GetPaymentMethodsQueryHandler
        : IRequestHandler<GetPaymentMethodsQuery, IEnumerable<GetPaymentMethodDTO>>
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;

        public GetPaymentMethodsQueryHandler(IPaymentMethodRepository paymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }

        public async Task<IEnumerable<GetPaymentMethodDTO>> Handle(
            GetPaymentMethodsQuery request, CancellationToken cancellationToken)
        {
            var methods = await _paymentMethodRepository.GetAsync(
                criteria: m => m.UserId == request.UserId && m.IsActive && !m.IsDeleted);

            return methods
                .OrderByDescending(m => m.IsDefault)
                .Select(m => Mapper.Map<PaymentMethod, GetPaymentMethodDTO>(m));
        }
    }
}
