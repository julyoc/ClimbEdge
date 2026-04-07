using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Organizations;
using ClimbEdge.Domain.Repositories.Organizations;
using MediatR;

namespace ClimbEdge.Application.Queries.OrganizationQuery
{
    public record GetOrganizationEventsQuery(long OrganizationId) : IRequest<IEnumerable<GetOrganizationEventDTO>>;

    public class GetOrganizationEventsQueryHandler
        : IRequestHandler<GetOrganizationEventsQuery, IEnumerable<GetOrganizationEventDTO>>
    {
        private readonly IOrganizationEventRepository _eventRepository;

        public GetOrganizationEventsQueryHandler(IOrganizationEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<IEnumerable<GetOrganizationEventDTO>> Handle(
            GetOrganizationEventsQuery request, CancellationToken cancellationToken)
        {
            var events = await _eventRepository.GetAsync(
                criteria: e => e.OrganizationId == request.OrganizationId && !e.IsDeleted);

            return events
                .OrderBy(e => e.StartDate)
                .Select(e => Mapper.Map<OrganizationEvent, GetOrganizationEventDTO>(e));
        }
    }
}
