using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Repositories.Mountains.Itinerary;
using MediatR;

namespace ClimbEdge.Application.Commands.ExpeditionCommand
{
    public record UpdateSafetyPlanCommand(long ExpeditionId, UpdateSafetyPlanDTO entity) : IRequest<GetSafetyPlanDTO>;

    public class UpdateSafetyPlanCommandHandler : IRequestHandler<UpdateSafetyPlanCommand, GetSafetyPlanDTO>
    {
        private readonly ISafetyPlanRepository _safetyPlanRepository;

        public UpdateSafetyPlanCommandHandler(ISafetyPlanRepository safetyPlanRepository)
        {
            _safetyPlanRepository = safetyPlanRepository;
        }

        public async Task<GetSafetyPlanDTO> Handle(UpdateSafetyPlanCommand request, CancellationToken cancellationToken)
        {
            var plans = await _safetyPlanRepository.GetAsync(criteria: p => p.ExpeditionId == request.ExpeditionId && !p.IsDeleted);
            var plan = plans.FirstOrDefault() ?? throw new KeyNotFoundException($"SafetyPlan for expedition {request.ExpeditionId} not found.");

            var dto = request.entity;
            if (dto.EmergencyContactName != null) plan.EmergencyContactName = dto.EmergencyContactName;
            if (dto.EmergencyContactPhone != null) plan.EmergencyContactPhone = dto.EmergencyContactPhone;
            if (dto.EmergencyContactRelation != null) plan.EmergencyContactRelation = dto.EmergencyContactRelation;
            if (dto.LocalRescueService != null) plan.LocalRescueService = dto.LocalRescueService;
            if (dto.NearestHospital != null) plan.NearestHospital = dto.NearestHospital;
            if (dto.EvacuationPlan != null) plan.EvacuationPlan = dto.EvacuationPlan;
            if (dto.CommunicationPlan != null) plan.CommunicationPlan = dto.CommunicationPlan;
            if (dto.RiskAssessment != null) plan.RiskAssessment = dto.RiskAssessment;
            if (dto.ContingencyPlans != null) plan.ContingencyPlans = dto.ContingencyPlans;
            if (dto.MedicalSupplies != null) plan.MedicalSupplies = dto.MedicalSupplies;

            plan.LastUpdated = DateTime.UtcNow;
            plan.UpdateTimestamps();
            await _safetyPlanRepository.SaveChangesAsync();

            return CreateSafetyPlanCommandHandler.MapToDTO(plan);
        }
    }
}
