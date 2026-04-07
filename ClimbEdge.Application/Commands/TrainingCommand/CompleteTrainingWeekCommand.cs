using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Repositories.Training;
using MediatR;

namespace ClimbEdge.Application.Commands.TrainingCommand
{
    public record CompleteTrainingWeekCommand(CompleteTrainingWeekDTO entity) : IRequest<bool>;

    public class CompleteTrainingWeekCommandHandler : IRequestHandler<CompleteTrainingWeekCommand, bool>
    {
        private readonly ITrainingWeekRepository _weekRepository;

        public CompleteTrainingWeekCommandHandler(ITrainingWeekRepository weekRepository)
        {
            _weekRepository = weekRepository;
        }

        public async Task<bool> Handle(CompleteTrainingWeekCommand request, CancellationToken cancellationToken)
        {
            var dto = request.entity;
            var week = await _weekRepository.GetAsync(dto.TrainingWeekUid);
            if (week is null)
                throw new InvalidOperationException($"TrainingWeek {dto.TrainingWeekUid} not found.");

            week.IsCompleted        = true;
            week.CompletedHours     = dto.CompletedHours;
            week.Zone1Hours         = dto.Zone1Hours;
            week.Zone2Hours         = dto.Zone2Hours;
            week.Zone3Hours         = dto.Zone3Hours;
            week.StrengthHours      = dto.StrengthHours;
            week.AlpineClimbingHours   = dto.AlpineClimbingHours;
            week.SchoolClimbingHours   = dto.SchoolClimbingHours;
            week.ElevationGained    = dto.ElevationGained;
            week.WeeklyEvaluation   = dto.WeeklyEvaluation;
            week.UpdateTimestamps();

            await _weekRepository.UpdateAsync(week);
            await _weekRepository.SaveChangesAsync();
            return true;
        }
    }
}
