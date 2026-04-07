using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Training;
using ClimbEdge.Domain.Repositories.Training;
using MediatR;

namespace ClimbEdge.Application.Commands.TrainingCommand
{
    public record LogSessionExerciseCommand(LogSessionExerciseDTO entity) : IRequest<GetSessionExerciseDTO>;

    public class LogSessionExerciseCommandHandler : IRequestHandler<LogSessionExerciseCommand, GetSessionExerciseDTO>
    {
        private readonly ISessionExerciseRepository _exerciseRepository;

        public LogSessionExerciseCommandHandler(ISessionExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public async Task<GetSessionExerciseDTO> Handle(LogSessionExerciseCommand request, CancellationToken cancellationToken)
        {
            var exercise = Mapper.Map<LogSessionExerciseDTO, SessionExercise>(request.entity);
            exercise.InitializeSlug();
            await _exerciseRepository.AddAsync(exercise);
            await _exerciseRepository.SaveChangesAsync();
            return Mapper.Map<SessionExercise, GetSessionExerciseDTO>(exercise);
        }
    }
}
