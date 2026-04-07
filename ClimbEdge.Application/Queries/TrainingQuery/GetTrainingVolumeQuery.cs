using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Training;
using ClimbEdge.Domain.Repositories.Training;
using MediatR;

namespace ClimbEdge.Application.Queries.TrainingQuery
{
    public record GetTrainingVolumeQuery(long TrainingWeekId) : IRequest<GetTrainingVolumeDTO?>;

    public class GetTrainingVolumeQueryHandler
        : IRequestHandler<GetTrainingVolumeQuery, GetTrainingVolumeDTO?>
    {
        private readonly ITrainingVolumeRepository _trainingVolumeRepository;

        public GetTrainingVolumeQueryHandler(ITrainingVolumeRepository trainingVolumeRepository)
        {
            _trainingVolumeRepository = trainingVolumeRepository;
        }

        public async Task<GetTrainingVolumeDTO?> Handle(
            GetTrainingVolumeQuery request, CancellationToken cancellationToken)
        {
            var records = await _trainingVolumeRepository.GetAsync(
                criteria: v => v.TrainingWeekId == request.TrainingWeekId && !v.IsDeleted);

            var volume = records.FirstOrDefault();
            if (volume is null) return null;

            return Mapper.Map<TrainingVolume, GetTrainingVolumeDTO>(volume);
        }
    }
}
