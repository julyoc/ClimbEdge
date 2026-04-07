using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Training;
using ClimbEdge.Domain.Repositories.Training;
using MediatR;

namespace ClimbEdge.Application.Queries.TrainingQuery
{
    public record GetTrainingPeriodsQuery(long TrainingPlanId) : IRequest<IEnumerable<GetTrainingPeriodDTO>>;

    public class GetTrainingPeriodsQueryHandler
        : IRequestHandler<GetTrainingPeriodsQuery, IEnumerable<GetTrainingPeriodDTO>>
    {
        private readonly ITrainingPeriodRepository _periodRepository;

        public GetTrainingPeriodsQueryHandler(ITrainingPeriodRepository periodRepository)
        {
            _periodRepository = periodRepository;
        }

        public async Task<IEnumerable<GetTrainingPeriodDTO>> Handle(
            GetTrainingPeriodsQuery request, CancellationToken cancellationToken)
        {
            var periods = await _periodRepository.GetAsync(
                criteria: p => p.TrainingPlanId == request.TrainingPlanId && !p.IsDeleted);

            return periods.Select(p => Mapper.Map<TrainingPeriod, GetTrainingPeriodDTO>(p));
        }
    }
}
