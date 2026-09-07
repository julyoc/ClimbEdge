using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Repositories.Mountains;
using MediatR;

namespace ClimbEdge.Application.Queries.MountainQuery
{
    public record GetWeatherConditionsQuery(long MountainId, DateTime? From = null, DateTime? To = null) : IRequest<IEnumerable<GetWeatherConditionDTO>>;

    public class GetWeatherConditionsQueryHandler : IRequestHandler<GetWeatherConditionsQuery, IEnumerable<GetWeatherConditionDTO>>
    {
        private readonly IWeatherConditionRepository _weatherRepository;

        public GetWeatherConditionsQueryHandler(IWeatherConditionRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        public async Task<IEnumerable<GetWeatherConditionDTO>> Handle(GetWeatherConditionsQuery request, CancellationToken cancellationToken)
        {
            var conditions = await _weatherRepository.GetAsync(
                criteria: w => w.MountainId == request.MountainId && !w.IsDeleted
                    && (request.From == null || w.RecordedAt >= request.From)
                    && (request.To == null || w.RecordedAt <= request.To));

            return conditions
                .OrderByDescending(w => w.RecordedAt)
                .Select(w => new GetWeatherConditionDTO
                {
                    Uid = w.Uid,
                    Slug = w.Slug,
                    MountainId = w.MountainId,
                    RecordedAt = w.RecordedAt,
                    Temperature = w.Temperature,
                    WindSpeed = w.WindSpeed,
                    WindDirection = w.WindDirection,
                    Humidity = w.Humidity,
                    Pressure = w.Pressure,
                    Visibility = w.Visibility,
                    Condition = w.Condition,
                    SnowDepth = w.SnowDepth,
                    DataSource = w.DataSource,
                    RainFall = w.RainFall,
                    SnowFall = w.SnowFall,
                    CreatedAt = w.CreatedAt
                });
        }
    }
}
