using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Training;
using ClimbEdge.Domain.Repositories.Training;
using MediatR;

namespace ClimbEdge.Application.Commands.TrainingCommand
{
    public record RecordTrainingProgressCommand(RecordTrainingProgressDTO entity) : IRequest<GetTrainingProgressDTO>;

    public class RecordTrainingProgressCommandHandler : IRequestHandler<RecordTrainingProgressCommand, GetTrainingProgressDTO>
    {
        private readonly ITrainingProgressRepository _progressRepository;

        public RecordTrainingProgressCommandHandler(ITrainingProgressRepository progressRepository)
        {
            _progressRepository = progressRepository;
        }

        public async Task<GetTrainingProgressDTO> Handle(RecordTrainingProgressCommand request, CancellationToken cancellationToken)
        {
            var progress = Mapper.Map<RecordTrainingProgressDTO, TrainingProgress>(request.entity);
            progress.InitializeSlug();
            await _progressRepository.AddAsync(progress);
            await _progressRepository.SaveChangesAsync();
            return Mapper.Map<TrainingProgress, GetTrainingProgressDTO>(progress);
        }
    }
}
