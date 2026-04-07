using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Sessions;
using ClimbEdge.Domain.Repositories.Sessions;
using MediatR;

namespace ClimbEdge.Application.Commands.SessionCommand
{
    public record RecordSessionProgressCommand(RecordProgressDTO entity) : IRequest<GetProgressDTO>;

    public class RecordSessionProgressCommandHandler : IRequestHandler<RecordSessionProgressCommand, GetProgressDTO>
    {
        private readonly IUserSessionProgressRepository _progressRepository;
        private readonly IUserSessionRepository _sessionRepository;

        public RecordSessionProgressCommandHandler(
            IUserSessionProgressRepository progressRepository,
            IUserSessionRepository sessionRepository)
        {
            _progressRepository = progressRepository;
            _sessionRepository = sessionRepository;
        }

        public async Task<GetProgressDTO> Handle(RecordSessionProgressCommand request, CancellationToken cancellationToken)
        {
            var session = await _sessionRepository.GetAsync(
                criteria: s => s.Id == request.entity.UserSessionId && s.EndedAt == null && !s.IsDeleted);
            if (!session.Any()) throw new InvalidOperationException("Active session not found.");

            var progress = Mapper.Map<RecordProgressDTO, UserSessionProgress>(request.entity);
            progress.TryAt = request.entity.TryAt ?? DateTime.UtcNow;
            await _progressRepository.AddAsync(progress);
            await _progressRepository.SaveChangesAsync();
            return Mapper.Map<UserSessionProgress, GetProgressDTO>(progress);
        }
    }
}
