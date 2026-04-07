using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Training;
using ClimbEdge.Domain.Repositories.Training;
using MediatR;

namespace ClimbEdge.Application.Queries.TrainingQuery
{
    public record GetTrainingWeeksQuery(long TrainingPeriodId) : IRequest<IEnumerable<GetTrainingWeekDTO>>;

    public class GetTrainingWeeksQueryHandler
        : IRequestHandler<GetTrainingWeeksQuery, IEnumerable<GetTrainingWeekDTO>>
    {
        private readonly ITrainingWeekRepository _weekRepository;

        public GetTrainingWeeksQueryHandler(ITrainingWeekRepository weekRepository)
        {
            _weekRepository = weekRepository;
        }

        public async Task<IEnumerable<GetTrainingWeekDTO>> Handle(
            GetTrainingWeeksQuery request, CancellationToken cancellationToken)
        {
            var weeks = await _weekRepository.GetAsync(
                criteria: w => w.TrainingPeriodId == request.TrainingPeriodId && !w.IsDeleted);

            return weeks.Select(w => Mapper.Map<TrainingWeek, GetTrainingWeekDTO>(w));
        }
    }
}
