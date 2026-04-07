using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Training;
using ClimbEdge.Domain.Repositories.Training;
using MediatR;

namespace ClimbEdge.Application.Queries.TrainingQuery
{
    public record GetTrainingProgressQuery(long TrainingPlanId) : IRequest<IEnumerable<GetTrainingProgressDTO>>;

    public class GetTrainingProgressQueryHandler
        : IRequestHandler<GetTrainingProgressQuery, IEnumerable<GetTrainingProgressDTO>>
    {
        private readonly ITrainingProgressRepository _progressRepository;

        public GetTrainingProgressQueryHandler(ITrainingProgressRepository progressRepository)
        {
            _progressRepository = progressRepository;
        }

        public async Task<IEnumerable<GetTrainingProgressDTO>> Handle(
            GetTrainingProgressQuery request, CancellationToken cancellationToken)
        {
            var records = await _progressRepository.GetAsync(
                criteria: p => p.TrainingPlanId == request.TrainingPlanId && !p.IsDeleted);

            return records
                .OrderBy(p => p.MeasurementDate)
                .Select(p => Mapper.Map<TrainingProgress, GetTrainingProgressDTO>(p));
        }
    }
}
