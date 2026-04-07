using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Training;
using ClimbEdge.Domain.Repositories.Training;
using MediatR;

namespace ClimbEdge.Application.Commands.TrainingCommand
{
    public record SetTrainingGoalCommand(SetTrainingGoalDTO entity) : IRequest<GetTrainingGoalDTO>;

    public class SetTrainingGoalCommandHandler : IRequestHandler<SetTrainingGoalCommand, GetTrainingGoalDTO>
    {
        private readonly ITrainingGoalRepository _goalRepository;

        public SetTrainingGoalCommandHandler(ITrainingGoalRepository goalRepository)
        {
            _goalRepository = goalRepository;
        }

        public async Task<GetTrainingGoalDTO> Handle(SetTrainingGoalCommand request, CancellationToken cancellationToken)
        {
            var goal = Mapper.Map<SetTrainingGoalDTO, TrainingGoal>(request.entity);
            goal.InitializeSlug();
            await _goalRepository.AddAsync(goal);
            await _goalRepository.SaveChangesAsync();
            return Mapper.Map<TrainingGoal, GetTrainingGoalDTO>(goal);
        }
    }
}
