using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Training;
using ClimbEdge.Domain.Interfaces;
using ClimbEdge.Domain.Repositories.Training;
using MediatR;

namespace ClimbEdge.Application.Queries.TrainingQuery
{
    public record GetTrainingPlansQuery(long UserId, bool? ActiveOnly = null, int Page = 1, int PageSize = 20) : IRequest<IEnumerable<GetTrainingPlanDTO>>;

    public class GetTrainingPlansQueryHandler : IRequestHandler<GetTrainingPlansQuery, IEnumerable<GetTrainingPlanDTO>>
    {
        private readonly ITrainingPlanRepository _trainingPlanRepository;

        public GetTrainingPlansQueryHandler(ITrainingPlanRepository trainingPlanRepository)
        {
            _trainingPlanRepository = trainingPlanRepository;
        }

        public async Task<IEnumerable<GetTrainingPlanDTO>> Handle(GetTrainingPlansQuery request, CancellationToken cancellationToken)
        {
            var plans = await _trainingPlanRepository.GetAsync(
                page: request.Page,
                criteria: p => p.UserId == request.UserId
                    && !p.IsDeleted
                    && (request.ActiveOnly == null || p.IsActive == request.ActiveOnly),
                orderSelectors: new[] { new OrderSelectors("StartDate", true) },
                pageSize: request.PageSize
            );
            return plans.Select(p => Mapper.Map<TrainingPlan, GetTrainingPlanDTO>(p));
        }
    }
}
