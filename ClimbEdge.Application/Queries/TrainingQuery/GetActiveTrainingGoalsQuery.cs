using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Training;
using ClimbEdge.Domain.Repositories.Training;
using MediatR;

namespace ClimbEdge.Application.Queries.TrainingQuery
{
    public record GetActiveTrainingGoalsQuery(long UserId) : IRequest<IEnumerable<GetTrainingGoalDTO>>;

    public class GetActiveTrainingGoalsQueryHandler
        : IRequestHandler<GetActiveTrainingGoalsQuery, IEnumerable<GetTrainingGoalDTO>>
    {
        private readonly ITrainingGoalRepository _goalRepository;

        public GetActiveTrainingGoalsQueryHandler(ITrainingGoalRepository goalRepository)
        {
            _goalRepository = goalRepository;
        }

        public async Task<IEnumerable<GetTrainingGoalDTO>> Handle(
            GetActiveTrainingGoalsQuery request, CancellationToken cancellationToken)
        {
            var goals = await _goalRepository.GetAsync(
                criteria: g => g.UserId == request.UserId && g.IsActive && !g.IsDeleted);

            return goals
                .OrderBy(g => g.Priority)
                .Select(g => Mapper.Map<TrainingGoal, GetTrainingGoalDTO>(g));
        }
    }
}
