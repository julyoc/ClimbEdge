using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Training;
using ClimbEdge.Domain.Repositories.Training;
using MediatR;

namespace ClimbEdge.Application.Commands.TrainingCommand
{
    public record CreateTrainingWeekCommand(CreateTrainingWeekDTO entity) : IRequest<GetTrainingWeekDTO>;

    public class CreateTrainingWeekCommandHandler : IRequestHandler<CreateTrainingWeekCommand, GetTrainingWeekDTO>
    {
        private readonly ITrainingWeekRepository _weekRepository;

        public CreateTrainingWeekCommandHandler(ITrainingWeekRepository weekRepository)
        {
            _weekRepository = weekRepository;
        }

        public async Task<GetTrainingWeekDTO> Handle(CreateTrainingWeekCommand request, CancellationToken cancellationToken)
        {
            var week = Mapper.Map<CreateTrainingWeekDTO, TrainingWeek>(request.entity);
            week.InitializeSlug();
            await _weekRepository.AddAsync(week);
            await _weekRepository.SaveChangesAsync();
            return Mapper.Map<TrainingWeek, GetTrainingWeekDTO>(week);
        }
    }
}
