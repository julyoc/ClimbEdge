using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using ClimbEdge.Domain.Repositories.Mountains.Itinerary;
using MediatR;

namespace ClimbEdge.Application.Queries.ExpeditionQuery
{
    public record GetExpeditionBudgetQuery(long ExpeditionId) : IRequest<IEnumerable<GetExpeditionBudgetDTO>>;

    public class GetExpeditionBudgetQueryHandler
        : IRequestHandler<GetExpeditionBudgetQuery, IEnumerable<GetExpeditionBudgetDTO>>
    {
        private readonly IExpeditionBudgetRepository _budgetRepository;

        public GetExpeditionBudgetQueryHandler(IExpeditionBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        public async Task<IEnumerable<GetExpeditionBudgetDTO>> Handle(
            GetExpeditionBudgetQuery request, CancellationToken cancellationToken)
        {
            var items = await _budgetRepository.GetAsync(
                criteria: b => b.ExpeditionId == request.ExpeditionId && !b.IsDeleted);

            return items
                .OrderBy(b => b.ExpeditionBudgetCategoryId)
                .Select(b => Mapper.Map<ExpeditionBudget, GetExpeditionBudgetDTO>(b));
        }
    }
}
