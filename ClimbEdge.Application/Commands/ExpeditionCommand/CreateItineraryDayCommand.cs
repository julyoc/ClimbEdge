using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using ClimbEdge.Domain.Repositories.Mountains.Itinerary;
using MediatR;

namespace ClimbEdge.Application.Commands.ExpeditionCommand
{
    public record CreateItineraryDayCommand(CreateItineraryDayDTO entity) : IRequest<GetItineraryDayDTO>;

    public class CreateItineraryDayCommandHandler
        : IRequestHandler<CreateItineraryDayCommand, GetItineraryDayDTO>
    {
        private readonly IItineraryDayRepository _dayRepository;

        public CreateItineraryDayCommandHandler(IItineraryDayRepository dayRepository)
        {
            _dayRepository = dayRepository;
        }

        public async Task<GetItineraryDayDTO> Handle(
            CreateItineraryDayCommand request, CancellationToken cancellationToken)
        {
            var day = Mapper.Map<CreateItineraryDayDTO, ItineraryDay>(request.entity);
            day.InitializeSlug();
            await _dayRepository.AddAsync(day);
            await _dayRepository.SaveChangesAsync();
            return Mapper.Map<ItineraryDay, GetItineraryDayDTO>(day);
        }
    }
}
