using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Repositories.Training;
using MediatR;

namespace ClimbEdge.Application.Commands.TrainingCommand
{
    public record MarkTrainingGoalAchievedCommand(Guid GoalUid) : IRequest<GetTrainingGoalDTO>;

    public class MarkTrainingGoalAchievedCommandHandler : IRequestHandler<MarkTrainingGoalAchievedCommand, GetTrainingGoalDTO>
    {
        private readonly ITrainingGoalRepository _goalRepository;

        public MarkTrainingGoalAchievedCommandHandler(ITrainingGoalRepository goalRepository)
        {
            _goalRepository = goalRepository;
        }

        public async Task<GetTrainingGoalDTO> Handle(MarkTrainingGoalAchievedCommand request, CancellationToken cancellationToken)
        {
            var goal = await _goalRepository.GetAsync(request.GoalUid);
            if (goal is null)
                throw new InvalidOperationException($"TrainingGoal {request.GoalUid} not found.");

            goal.IsAchieved    = true;
            goal.AchievedDate  = DateTime.UtcNow;
            goal.IsActive      = false;
            goal.UpdateTimestamps();

            await _goalRepository.UpdateAsync(goal);
            await _goalRepository.SaveChangesAsync();
            return Mapper.Map<Domain.Entities.Training.TrainingGoal, GetTrainingGoalDTO>(goal);
        }
    }
}
