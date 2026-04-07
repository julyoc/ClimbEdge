using Asp.Versioning;
using ClimbEdge.Application.Commands.UserProfileCommand;
using ClimbEdge.Application.DTOs;
using ClimbEdge.Application.Queries.UserProfileQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClimbEdge.API.Controllers
{
    [ApiVersion("0.1")]
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserProfileController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserProfileController> _logger;

        public UserProfileController(IMediator mediator, ILogger<UserProfileController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("{userId:long}")]
        public async Task<ActionResult<GetUserProfileDTO>> GetByUserId(long userId)
        {
            try
            {
                var result = await _mediator.Send(new FindUserProfileWithUserIdQuery(userId));
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting user profile for user {UserId}", userId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost]
        public async Task<ActionResult<GetUserProfileDTO>> Create([FromBody] CreateUserProfileDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new CreateUserProfileCommand(entity));
                return CreatedAtAction(nameof(GetByUserId), new { userId = result.UserId }, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating user profile");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPut("{userId:long}")]
        public async Task<ActionResult<GetUserProfileDTO>> Update(long userId, [FromBody] UpdateUserProfileDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new UpdateUserProfileCommand(userId, entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating user profile for user {UserId}", userId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }
    }
}
