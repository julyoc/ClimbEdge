using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Training;
using ClimbEdge.Domain.Repositories.Training;
using MediatR;

namespace ClimbEdge.Application.Queries.TrainingQuery
{
    public record GetTrainingSessionsQuery(long TrainingWeekId) : IRequest<IEnumerable<GetTrainingSessionDTO>>;

    public class GetTrainingSessionsQueryHandler
        : IRequestHandler<GetTrainingSessionsQuery, IEnumerable<GetTrainingSessionDTO>>
    {
        private readonly ITrainingSessionRepository _sessionRepository;

        public GetTrainingSessionsQueryHandler(ITrainingSessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task<IEnumerable<GetTrainingSessionDTO>> Handle(
            GetTrainingSessionsQuery request, CancellationToken cancellationToken)
        {
            var sessions = await _sessionRepository.GetAsync(
                criteria: s => s.TrainingWeekId == request.TrainingWeekId && !s.IsDeleted);

            return sessions.Select(s => Mapper.Map<TrainingSession, GetTrainingSessionDTO>(s));
        }
    }
}
