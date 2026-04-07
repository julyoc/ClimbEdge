using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Training;
using ClimbEdge.Domain.Repositories.Training;
using MediatR;

namespace ClimbEdge.Application.Commands.TrainingCommand
{
    public record UpdateTrainingPlanCommand(Guid PlanUid, UpdateTrainingPlanDTO entity) : IRequest<GetTrainingPlanDTO>;

    public class UpdateTrainingPlanCommandHandler : IRequestHandler<UpdateTrainingPlanCommand, GetTrainingPlanDTO>
    {
        private readonly ITrainingPlanRepository _trainingPlanRepository;

        public UpdateTrainingPlanCommandHandler(ITrainingPlanRepository trainingPlanRepository)
        {
            _trainingPlanRepository = trainingPlanRepository;
        }

        public async Task<GetTrainingPlanDTO> Handle(UpdateTrainingPlanCommand request, CancellationToken cancellationToken)
        {
            var plan = await _trainingPlanRepository.GetAsync(request.PlanUid);
            if (plan == null) throw new InvalidOperationException("Training plan not found.");
            Mapper.MapUpdate(request.entity, plan);
            plan.UpdateTimestamps();
            await _trainingPlanRepository.UpdateAsync(plan);
            await _trainingPlanRepository.SaveChangesAsync();
            return Mapper.Map<TrainingPlan, GetTrainingPlanDTO>(plan);
        }
    }
}
