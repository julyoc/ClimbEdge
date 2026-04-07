using ClimbEdge.Domain.Repositories.Training;
using MediatR;

namespace ClimbEdge.Application.Commands.TrainingCommand
{
    public record DeleteTrainingPlanCommand(Guid PlanUid) : IRequest;

    public class DeleteTrainingPlanCommandHandler : IRequestHandler<DeleteTrainingPlanCommand>
    {
        private readonly ITrainingPlanRepository _trainingPlanRepository;

        public DeleteTrainingPlanCommandHandler(ITrainingPlanRepository trainingPlanRepository)
        {
            _trainingPlanRepository = trainingPlanRepository;
        }

        public async Task Handle(DeleteTrainingPlanCommand request, CancellationToken cancellationToken)
        {
            var exists = await _trainingPlanRepository.ExistsAsync(request.PlanUid);
            if (!exists) throw new InvalidOperationException("Training plan not found.");
            await _trainingPlanRepository.DeleteAsync(request.PlanUid);
            await _trainingPlanRepository.SaveChangesAsync();
        }
    }
}
