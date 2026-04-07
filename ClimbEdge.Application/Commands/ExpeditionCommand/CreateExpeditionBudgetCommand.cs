using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using ClimbEdge.Domain.Repositories.Mountains.Itinerary;
using MediatR;

namespace ClimbEdge.Application.Commands.ExpeditionCommand
{
    public record CreateExpeditionBudgetCommand(CreateExpeditionBudgetDTO entity) : IRequest<GetExpeditionBudgetDTO>;

    public class CreateExpeditionBudgetCommandHandler
        : IRequestHandler<CreateExpeditionBudgetCommand, GetExpeditionBudgetDTO>
    {
        private readonly IExpeditionBudgetRepository _budgetRepository;

        public CreateExpeditionBudgetCommandHandler(IExpeditionBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        public async Task<GetExpeditionBudgetDTO> Handle(
            CreateExpeditionBudgetCommand request, CancellationToken cancellationToken)
        {
            var budget = Mapper.Map<CreateExpeditionBudgetDTO, ExpeditionBudget>(request.entity);
            budget.InitializeSlug();
            await _budgetRepository.AddAsync(budget);
            await _budgetRepository.SaveChangesAsync();
            return Mapper.Map<ExpeditionBudget, GetExpeditionBudgetDTO>(budget);
        }
    }
}
