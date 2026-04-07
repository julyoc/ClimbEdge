using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Training;
using ClimbEdge.Domain.Repositories.Training;
using MediatR;

namespace ClimbEdge.Application.Commands.TrainingCommand
{
    public record CreateTrainingPeriodCommand(CreateTrainingPeriodDTO entity) : IRequest<GetTrainingPeriodDTO>;

    public class CreateTrainingPeriodCommandHandler : IRequestHandler<CreateTrainingPeriodCommand, GetTrainingPeriodDTO>
    {
        private readonly ITrainingPeriodRepository _periodRepository;

        public CreateTrainingPeriodCommandHandler(ITrainingPeriodRepository periodRepository)
        {
            _periodRepository = periodRepository;
        }

        public async Task<GetTrainingPeriodDTO> Handle(CreateTrainingPeriodCommand request, CancellationToken cancellationToken)
        {
            var period = Mapper.Map<CreateTrainingPeriodDTO, TrainingPeriod>(request.entity);
            period.InitializeSlug();
            await _periodRepository.AddAsync(period);
            await _periodRepository.SaveChangesAsync();
            return Mapper.Map<TrainingPeriod, GetTrainingPeriodDTO>(period);
        }
    }
}
