using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Training;
using ClimbEdge.Domain.Repositories.Training;
using MediatR;

namespace ClimbEdge.Application.Commands.TrainingCommand
{
    public record CreateTrainingPlanCommand(CreateTrainingPlanDTO entity) : IRequest<GetTrainingPlanDTO>;

    public class CreateTrainingPlanCommandHandler : IRequestHandler<CreateTrainingPlanCommand, GetTrainingPlanDTO>
    {
        private readonly ITrainingPlanRepository _trainingPlanRepository;

        public CreateTrainingPlanCommandHandler(ITrainingPlanRepository trainingPlanRepository)
        {
            _trainingPlanRepository = trainingPlanRepository;
        }

        public async Task<GetTrainingPlanDTO> Handle(CreateTrainingPlanCommand request, CancellationToken cancellationToken)
        {
            var activePlans = await _trainingPlanRepository.GetAsync(
                criteria: p => p.UserId == request.entity.UserId && p.IsActive && !p.IsDeleted);
            if (activePlans.Any()) throw new InvalidOperationException("User already has an active training plan. Deactivate it before creating a new one.");

            var plan = Mapper.Map<CreateTrainingPlanDTO, TrainingPlan>(request.entity);
            plan.IsActive = true;
            await _trainingPlanRepository.AddAsync(plan);
            await _trainingPlanRepository.SaveChangesAsync();
            return Mapper.Map<TrainingPlan, GetTrainingPlanDTO>(plan);
        }
    }
}
