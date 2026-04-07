using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Sessions;
using ClimbEdge.Domain.Repositories.Sessions;
using MediatR;

namespace ClimbEdge.Application.Queries.SessionQuery
{
    public record GetBoardSessionSummaryQuery(long BoardId, long UserId) : IRequest<GetBoardSessionSummaryDTO?>;

    public class GetBoardSessionSummaryQueryHandler
        : IRequestHandler<GetBoardSessionSummaryQuery, GetBoardSessionSummaryDTO?>
    {
        private readonly IBoardSessionSummaryRepository _summaryRepository;

        public GetBoardSessionSummaryQueryHandler(IBoardSessionSummaryRepository summaryRepository)
        {
            _summaryRepository = summaryRepository;
        }

        public async Task<GetBoardSessionSummaryDTO?> Handle(
            GetBoardSessionSummaryQuery request, CancellationToken cancellationToken)
        {
            var records = await _summaryRepository.GetAsync(
                criteria: s => s.BoardId == request.BoardId && s.UserId == request.UserId && !s.IsDeleted);

            var summary = records.FirstOrDefault();
            if (summary is null) return null;

            return Mapper.Map<BoardSessionSummary, GetBoardSessionSummaryDTO>(summary);
        }
    }
}
