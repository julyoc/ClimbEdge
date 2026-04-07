using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Training;
using ClimbEdge.Domain.Repositories.Training;
using MediatR;

namespace ClimbEdge.Application.Queries.TrainingQuery
{
    public record GetSessionExercisesQuery(long TrainingSessionId) : IRequest<IEnumerable<GetSessionExerciseDTO>>;

    public class GetSessionExercisesQueryHandler
        : IRequestHandler<GetSessionExercisesQuery, IEnumerable<GetSessionExerciseDTO>>
    {
        private readonly ISessionExerciseRepository _exerciseRepository;

        public GetSessionExercisesQueryHandler(ISessionExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public async Task<IEnumerable<GetSessionExerciseDTO>> Handle(
            GetSessionExercisesQuery request, CancellationToken cancellationToken)
        {
            var exercises = await _exerciseRepository.GetAsync(
                criteria: e => e.TrainingSessionId == request.TrainingSessionId && !e.IsDeleted);

            return exercises
                .OrderBy(e => e.Sequence)
                .Select(e => Mapper.Map<SessionExercise, GetSessionExerciseDTO>(e));
        }
    }
}
