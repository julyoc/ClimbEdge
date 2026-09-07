using ClimbEdge.Application.DTOs;
using ClimbEdge.Application.Commands.ExpeditionCommand;
using ClimbEdge.Domain.Repositories.Mountains.Itinerary;
using MediatR;

namespace ClimbEdge.Application.Queries.ExpeditionQuery
{
    public record GetSafetyPlanQuery(long ExpeditionId) : IRequest<GetSafetyPlanDTO?>;

    public class GetSafetyPlanQueryHandler : IRequestHandler<GetSafetyPlanQuery, GetSafetyPlanDTO?>
    {
        private readonly ISafetyPlanRepository _safetyPlanRepository;

        public GetSafetyPlanQueryHandler(ISafetyPlanRepository safetyPlanRepository)
        {
            _safetyPlanRepository = safetyPlanRepository;
        }

        public async Task<GetSafetyPlanDTO?> Handle(GetSafetyPlanQuery request, CancellationToken cancellationToken)
        {
            var plans = await _safetyPlanRepository.GetAsync(criteria: p => p.ExpeditionId == request.ExpeditionId && !p.IsDeleted);
            var plan = plans.FirstOrDefault();
            return plan == null ? null : CreateSafetyPlanCommandHandler.MapToDTO(plan);
        }
    }
}
