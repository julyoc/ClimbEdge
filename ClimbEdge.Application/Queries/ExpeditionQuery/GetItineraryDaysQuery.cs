using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using ClimbEdge.Domain.Repositories.Mountains.Itinerary;
using MediatR;

namespace ClimbEdge.Application.Queries.ExpeditionQuery
{
    public record GetItineraryDaysQuery(long ExpeditionId) : IRequest<IEnumerable<GetItineraryDayDTO>>;

    public class GetItineraryDaysQueryHandler
        : IRequestHandler<GetItineraryDaysQuery, IEnumerable<GetItineraryDayDTO>>
    {
        private readonly IItineraryDayRepository _dayRepository;

        public GetItineraryDaysQueryHandler(IItineraryDayRepository dayRepository)
        {
            _dayRepository = dayRepository;
        }

        public async Task<IEnumerable<GetItineraryDayDTO>> Handle(
            GetItineraryDaysQuery request, CancellationToken cancellationToken)
        {
            var days = await _dayRepository.GetAsync(
                criteria: d => d.ExpeditionId == request.ExpeditionId && !d.IsDeleted);

            return days
                .OrderBy(d => d.DayNumber)
                .Select(d => Mapper.Map<ItineraryDay, GetItineraryDayDTO>(d));
        }
    }
}
