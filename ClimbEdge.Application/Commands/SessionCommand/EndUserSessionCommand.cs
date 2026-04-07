using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Sessions;
using ClimbEdge.Domain.Repositories.Sessions;
using MediatR;

namespace ClimbEdge.Application.Commands.SessionCommand
{
    public record EndUserSessionCommand(Guid SessionUid, string? Notes = null) : IRequest<GetSessionDTO>;

    public class EndUserSessionCommandHandler : IRequestHandler<EndUserSessionCommand, GetSessionDTO>
    {
        private readonly IUserSessionRepository _userSessionRepository;

        public EndUserSessionCommandHandler(IUserSessionRepository userSessionRepository)
        {
            _userSessionRepository = userSessionRepository;
        }

        public async Task<GetSessionDTO> Handle(EndUserSessionCommand request, CancellationToken cancellationToken)
        {
            var session = await _userSessionRepository.GetAsync(request.SessionUid);
            if (session == null) throw new InvalidOperationException("Session not found.");
            if (session.EndedAt != null) throw new InvalidOperationException("Session has already ended.");

            session.EndedAt = DateTime.UtcNow;
            if (request.Notes != null) session.Notes = request.Notes;
            session.UpdateTimestamps();
            await _userSessionRepository.UpdateAsync(session);
            await _userSessionRepository.SaveChangesAsync();
            return Mapper.Map<UserSession, GetSessionDTO>(session);
        }
    }
}
