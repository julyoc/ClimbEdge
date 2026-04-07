using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Training;
using ClimbEdge.Domain.Repositories.Training;
using MediatR;

namespace ClimbEdge.Application.Queries.TrainingQuery
{
    public record GetTrainingPlanQuery(Guid PlanUid) : IRequest<GetTrainingPlanDTO?>;

    public class GetTrainingPlanQueryHandler : IRequestHandler<GetTrainingPlanQuery, GetTrainingPlanDTO?>
    {
        private readonly ITrainingPlanRepository _trainingPlanRepository;

        public GetTrainingPlanQueryHandler(ITrainingPlanRepository trainingPlanRepository)
        {
            _trainingPlanRepository = trainingPlanRepository;
        }

        public async Task<GetTrainingPlanDTO?> Handle(GetTrainingPlanQuery request, CancellationToken cancellationToken)
        {
            var plan = await _trainingPlanRepository.GetAsync(request.PlanUid);
            if (plan == null) return null;
            return Mapper.Map<TrainingPlan, GetTrainingPlanDTO>(plan);
        }
    }
}
