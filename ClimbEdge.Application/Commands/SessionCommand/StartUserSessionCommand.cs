using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Sessions;
using ClimbEdge.Domain.Repositories.Sessions;
using MediatR;

namespace ClimbEdge.Application.Commands.SessionCommand
{
    public record StartUserSessionCommand(StartSessionDTO entity) : IRequest<GetSessionDTO>;

    public class StartUserSessionCommandHandler : IRequestHandler<StartUserSessionCommand, GetSessionDTO>
    {
        private readonly IUserSessionRepository _userSessionRepository;

        public StartUserSessionCommandHandler(IUserSessionRepository userSessionRepository)
        {
            _userSessionRepository = userSessionRepository;
        }

        public async Task<GetSessionDTO> Handle(StartUserSessionCommand request, CancellationToken cancellationToken)
        {
            var activeSession = await _userSessionRepository.GetAsync(
                criteria: s => s.UserId == request.entity.UserId && s.EndedAt == null && !s.IsDeleted);
            if (activeSession.Any()) throw new InvalidOperationException("User already has an active session. End it before starting a new one.");

            var session = Mapper.Map<StartSessionDTO, UserSession>(request.entity);
            session.StartedAt = DateTime.UtcNow;
            await _userSessionRepository.AddAsync(session);
            await _userSessionRepository.SaveChangesAsync();
            return Mapper.Map<UserSession, GetSessionDTO>(session);
        }
    }
}
