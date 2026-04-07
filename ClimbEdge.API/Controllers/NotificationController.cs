using Asp.Versioning;
using ClimbEdge.Application.Commands.NotificationCommand;
using ClimbEdge.Application.DTOs;
using ClimbEdge.Application.Queries.NotificationQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClimbEdge.API.Controllers
{
    [ApiVersion("0.1")]
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<NotificationController> _logger;

        public NotificationController(IMediator mediator, ILogger<NotificationController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetNotificationDTO>>> GetAll(
            [FromQuery] long userId,
            [FromQuery] bool? unreadOnly = null,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 20)
        {
            try
            {
                var result = await _mediator.Send(new GetNotificationsQuery(userId, unreadOnly, page, pageSize));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting notifications for user {UserId}", userId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPut("read")]
        public async Task<ActionResult<int>> MarkRead(
            [FromQuery] long userId,
            [FromBody] MarkNotificationsReadDTO? body = null)
        {
            try
            {
                var result = await _mediator.Send(new MarkNotificationsReadCommand(
                    userId,
                    body?.NotificationUids,
                    body?.MarkAll ?? false));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error marking notifications as read for user {UserId}", userId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("preferences")]
        public async Task<ActionResult<IEnumerable<GetNotificationPreferenceDTO>>> GetPreferences([FromQuery] long userId)
        {
            try
            {
                var result = await _mediator.Send(new GetNotificationPreferencesQuery(userId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting notification preferences for user {UserId}", userId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPut("preferences")]
        public async Task<ActionResult<GetNotificationPreferenceDTO>> UpdatePreference([FromBody] UpdateNotificationPreferenceDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new UpdateNotificationPreferenceCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating notification preference");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }
    }
}
