using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Training;
using ClimbEdge.Domain.Repositories.Training;
using MediatR;

namespace ClimbEdge.Application.Queries.TrainingQuery
{
    public record GetTrainingExercisesQuery() : IRequest<IEnumerable<GetTrainingExerciseDTO>>;

    public class GetTrainingExercisesQueryHandler
        : IRequestHandler<GetTrainingExercisesQuery, IEnumerable<GetTrainingExerciseDTO>>
    {
        private readonly ITrainingExerciseRepository _exerciseRepository;

        public GetTrainingExercisesQueryHandler(ITrainingExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public async Task<IEnumerable<GetTrainingExerciseDTO>> Handle(
            GetTrainingExercisesQuery request, CancellationToken cancellationToken)
        {
            var exercises = await _exerciseRepository.GetAsync(
                criteria: e => !e.IsDeleted);

            return exercises
                .OrderBy(e => e.Name)
                .Select(e => Mapper.Map<TrainingExercise, GetTrainingExerciseDTO>(e));
        }
    }
}
