using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Training;
using ClimbEdge.Domain.Repositories.Training;
using MediatR;

namespace ClimbEdge.Application.Commands.TrainingCommand
{
    public record LogTrainingSessionCommand(LogTrainingSessionDTO entity) : IRequest<GetTrainingSessionDTO>;

    public class LogTrainingSessionCommandHandler : IRequestHandler<LogTrainingSessionCommand, GetTrainingSessionDTO>
    {
        private readonly ITrainingSessionRepository _trainingSessionRepository;

        public LogTrainingSessionCommandHandler(ITrainingSessionRepository trainingSessionRepository)
        {
            _trainingSessionRepository = trainingSessionRepository;
        }

        public async Task<GetTrainingSessionDTO> Handle(LogTrainingSessionCommand request, CancellationToken cancellationToken)
        {
            var session = Mapper.Map<LogTrainingSessionDTO, TrainingSession>(request.entity);
            await _trainingSessionRepository.AddAsync(session);
            await _trainingSessionRepository.SaveChangesAsync();
            return Mapper.Map<TrainingSession, GetTrainingSessionDTO>(session);
        }
    }
}
