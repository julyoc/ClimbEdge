using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Mountains;
using ClimbEdge.Domain.Repositories.Mountains;
using MediatR;

namespace ClimbEdge.Application.Queries.ExpeditionQuery
{
    public record GetExpeditionLogsQuery(long ExpeditionId) : IRequest<IEnumerable<GetExpeditionLogDTO>>;

    public class GetExpeditionLogsQueryHandler
        : IRequestHandler<GetExpeditionLogsQuery, IEnumerable<GetExpeditionLogDTO>>
    {
        private readonly IMountainExpeditionLogRepository _logRepository;

        public GetExpeditionLogsQueryHandler(IMountainExpeditionLogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task<IEnumerable<GetExpeditionLogDTO>> Handle(
            GetExpeditionLogsQuery request, CancellationToken cancellationToken)
        {
            var logs = await _logRepository.GetAsync(
                criteria: l => l.ExpeditionId == request.ExpeditionId && !l.IsDeleted);

            return logs.Select(l => Mapper.Map<MountainExpeditionLog, GetExpeditionLogDTO>(l));
        }
    }
}
