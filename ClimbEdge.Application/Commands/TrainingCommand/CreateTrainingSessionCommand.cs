using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Training;
using ClimbEdge.Domain.Repositories.Training;
using MediatR;

namespace ClimbEdge.Application.Commands.TrainingCommand
{
    public record CreateTrainingSessionCommand(CreateTrainingSessionDTO entity) : IRequest<GetTrainingSessionDTO>;

    public class CreateTrainingSessionCommandHandler : IRequestHandler<CreateTrainingSessionCommand, GetTrainingSessionDTO>
    {
        private readonly ITrainingSessionRepository _sessionRepository;

        public CreateTrainingSessionCommandHandler(ITrainingSessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task<GetTrainingSessionDTO> Handle(CreateTrainingSessionCommand request, CancellationToken cancellationToken)
        {
            var session = Mapper.Map<CreateTrainingSessionDTO, TrainingSession>(request.entity);
            session.InitializeSlug();
            await _sessionRepository.AddAsync(session);
            await _sessionRepository.SaveChangesAsync();
            return Mapper.Map<TrainingSession, GetTrainingSessionDTO>(session);
        }
    }
}
