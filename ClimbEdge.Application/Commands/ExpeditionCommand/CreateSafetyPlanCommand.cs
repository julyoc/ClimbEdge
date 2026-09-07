using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using ClimbEdge.Domain.Repositories.Mountains.Itinerary;
using MediatR;

namespace ClimbEdge.Application.Commands.ExpeditionCommand
{
    public record CreateSafetyPlanCommand(CreateSafetyPlanDTO entity) : IRequest<GetSafetyPlanDTO>;

    public class CreateSafetyPlanCommandHandler : IRequestHandler<CreateSafetyPlanCommand, GetSafetyPlanDTO>
    {
        private readonly ISafetyPlanRepository _safetyPlanRepository;

        public CreateSafetyPlanCommandHandler(ISafetyPlanRepository safetyPlanRepository)
        {
            _safetyPlanRepository = safetyPlanRepository;
        }

        public async Task<GetSafetyPlanDTO> Handle(CreateSafetyPlanCommand request, CancellationToken cancellationToken)
        {
            var dto = request.entity;

            var plan = new SafetyPlan
            {
                ExpeditionId = dto.ExpeditionId,
                EmergencyContactName = dto.EmergencyContactName,
                EmergencyContactPhone = dto.EmergencyContactPhone,
                EmergencyContactRelation = dto.EmergencyContactRelation,
                LocalRescueService = dto.LocalRescueService,
                NearestHospital = dto.NearestHospital,
                EvacuationPlan = dto.EvacuationPlan,
                CommunicationPlan = dto.CommunicationPlan,
                RiskAssessment = dto.RiskAssessment,
                ContingencyPlans = dto.ContingencyPlans,
                MedicalSupplies = dto.MedicalSupplies,
                LastUpdated = DateTime.UtcNow
            };

            plan.InitializeSlug();
            await _safetyPlanRepository.AddAsync(plan);
            await _safetyPlanRepository.SaveChangesAsync();

            return MapToDTO(plan);
        }

        internal static GetSafetyPlanDTO MapToDTO(SafetyPlan plan) => new()
        {
            Uid = plan.Uid,
            Slug = plan.Slug,
            ExpeditionId = plan.ExpeditionId,
            EmergencyContactName = plan.EmergencyContactName,
            EmergencyContactPhone = plan.EmergencyContactPhone,
            EmergencyContactRelation = plan.EmergencyContactRelation,
            LocalRescueService = plan.LocalRescueService,
            NearestHospital = plan.NearestHospital,
            EvacuationPlan = plan.EvacuationPlan,
            CommunicationPlan = plan.CommunicationPlan,
            RiskAssessment = plan.RiskAssessment,
            ContingencyPlans = plan.ContingencyPlans,
            MedicalSupplies = plan.MedicalSupplies,
            LastUpdated = plan.LastUpdated,
            CreatedAt = plan.CreatedAt,
            UpdatedAt = plan.UpdatedAt
        };
    }
}
