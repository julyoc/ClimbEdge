using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Repositories.Training;
using MediatR;

namespace ClimbEdge.Application.Commands.TrainingCommand
{
    public record CompleteTrainingSessionCommand(CompleteTrainingSessionDTO entity) : IRequest<GetTrainingSessionDTO>;

    public class CompleteTrainingSessionCommandHandler : IRequestHandler<CompleteTrainingSessionCommand, GetTrainingSessionDTO>
    {
        private readonly ITrainingSessionRepository _sessionRepository;

        public CompleteTrainingSessionCommandHandler(ITrainingSessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task<GetTrainingSessionDTO> Handle(CompleteTrainingSessionCommand request, CancellationToken cancellationToken)
        {
            var dto = request.entity;
            var session = await _sessionRepository.GetAsync(dto.TrainingSessionUid);
            if (session is null)
                throw new InvalidOperationException($"TrainingSession {dto.TrainingSessionUid} not found.");

            session.IsCompleted      = true;
            session.ActualDuration   = dto.ActualDuration;
            session.TrainingZone     = dto.TrainingZone;
            session.ElevationGained  = dto.ElevationGained;
            session.WeightCarried    = dto.WeightCarried;
            session.Distance         = dto.Distance;
            session.HeartRateAvg     = dto.HeartRateAvg;
            session.HeartRateMax     = dto.HeartRateMax;
            session.Rating           = dto.Rating;
            session.Notes            = dto.Notes ?? session.Notes;
            session.UserSessionId    = dto.UserSessionId;
            session.UpdateTimestamps();

            await _sessionRepository.UpdateAsync(session);
            await _sessionRepository.SaveChangesAsync();
            return Mapper.Map<Domain.Entities.Training.TrainingSession, GetTrainingSessionDTO>(session);
        }
    }
}
