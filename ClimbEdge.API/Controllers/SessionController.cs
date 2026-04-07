using Asp.Versioning;
using ClimbEdge.Application.Commands.SessionCommand;
using ClimbEdge.Application.DTOs;
using ClimbEdge.Application.Queries.SessionQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClimbEdge.API.Controllers
{
    [ApiVersion("0.1")]
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SessionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<SessionController> _logger;

        public SessionController(IMediator mediator, ILogger<SessionController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetSessionDTO>>> GetAll(
            [FromQuery] long userId,
            [FromQuery] bool? activeOnly = null,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 20)
        {
            try
            {
                var result = await _mediator.Send(new GetUserSessionsQuery(userId, activeOnly, page, pageSize));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting sessions for user {UserId}", userId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("{uid:guid}")]
        public async Task<ActionResult<GetSessionDTO>> GetByUid(Guid uid)
        {
            try
            {
                var result = await _mediator.Send(new GetUserSessionQuery(uid));
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting session {Uid}", uid);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("start")]
        public async Task<ActionResult<GetSessionDTO>> Start([FromBody] StartSessionDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new StartUserSessionCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error starting user session");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPut("{uid:guid}/end")]
        public async Task<ActionResult<GetSessionDTO>> End(Guid uid, [FromQuery] string? notes = null)
        {
            try
            {
                var result = await _mediator.Send(new EndUserSessionCommand(uid, notes));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ending session {Uid}", uid);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("progress")]
        public async Task<ActionResult<GetProgressDTO>> RecordProgress([FromBody] RecordProgressDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new RecordSessionProgressCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error recording session progress");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("{sessionId:long}/progress")]
        public async Task<ActionResult<IEnumerable<GetProgressDTO>>> GetProgress(long sessionId)
        {
            try
            {
                var result = await _mediator.Send(new GetSessionProgressQuery(sessionId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting progress for session {SessionId}", sessionId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }
    }
}
