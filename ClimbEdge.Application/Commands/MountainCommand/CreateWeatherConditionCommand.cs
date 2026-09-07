using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Entities.Mountains;
using ClimbEdge.Domain.Repositories.Mountains;
using MediatR;

namespace ClimbEdge.Application.Commands.MountainCommand
{
    public record CreateWeatherConditionCommand(CreateWeatherConditionDTO entity) : IRequest<GetWeatherConditionDTO>;

    public class CreateWeatherConditionCommandHandler : IRequestHandler<CreateWeatherConditionCommand, GetWeatherConditionDTO>
    {
        private readonly IWeatherConditionRepository _weatherRepository;

        public CreateWeatherConditionCommandHandler(IWeatherConditionRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        public async Task<GetWeatherConditionDTO> Handle(CreateWeatherConditionCommand request, CancellationToken cancellationToken)
        {
            var dto = request.entity;

            var condition = new WeatherCondition
            {
                MountainId = dto.MountainId,
                RecordedAt = dto.RecordedAt,
                Temperature = dto.Temperature,
                WindSpeed = dto.WindSpeed,
                WindDirection = dto.WindDirection,
                Humidity = dto.Humidity,
                Pressure = dto.Pressure,
                Visibility = dto.Visibility,
                Condition = dto.Condition,
                SnowDepth = dto.SnowDepth,
                DataSource = dto.DataSource,
                RainFall = dto.RainFall,
                SnowFall = dto.SnowFall
            };

            condition.InitializeSlug();
            await _weatherRepository.AddAsync(condition);
            await _weatherRepository.SaveChangesAsync();

            return new GetWeatherConditionDTO
            {
                Uid = condition.Uid,
                Slug = condition.Slug,
                MountainId = condition.MountainId,
                RecordedAt = condition.RecordedAt,
                Temperature = condition.Temperature,
                WindSpeed = condition.WindSpeed,
                WindDirection = condition.WindDirection,
                Humidity = condition.Humidity,
                Pressure = condition.Pressure,
                Visibility = condition.Visibility,
                Condition = condition.Condition,
                SnowDepth = condition.SnowDepth,
                DataSource = condition.DataSource,
                RainFall = condition.RainFall,
                SnowFall = condition.SnowFall,
                CreatedAt = condition.CreatedAt
            };
        }
    }
}
