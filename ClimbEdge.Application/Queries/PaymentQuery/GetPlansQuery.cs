using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Payment;
using ClimbEdge.Domain.Interfaces;
using ClimbEdge.Domain.Repositories.Payment;
using MediatR;

namespace ClimbEdge.Application.Queries.PaymentQuery
{
    public record GetPlansQuery(bool ActiveOnly = true) : IRequest<IEnumerable<GetPlanDTO>>;

    public class GetPlansQueryHandler : IRequestHandler<GetPlansQuery, IEnumerable<GetPlanDTO>>
    {
        private readonly IPlanRepository _planRepository;

        public GetPlansQueryHandler(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        public async Task<IEnumerable<GetPlanDTO>> Handle(GetPlansQuery request, CancellationToken cancellationToken)
        {
            var plans = await _planRepository.GetAsync(
                criteria: p => !p.IsDeleted && (!request.ActiveOnly || p.IsActive),
                orderSelectors: new[] { new OrderSelectors("Price", false) }
            );
            return plans.Select(p => Mapper.Map<Plan, GetPlanDTO>(p));
        }
    }
}
