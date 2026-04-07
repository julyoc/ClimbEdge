using Asp.Versioning;
using ClimbEdge.Application.Commands.CommentCommand;
using ClimbEdge.Application.DTOs;
using ClimbEdge.Application.Queries.CommentQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClimbEdge.API.Controllers
{
    [ApiVersion("0.1")]
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CommentController> _logger;

        public CommentController(IMediator mediator, ILogger<CommentController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCommentDTO>>> GetComments(
            [FromQuery] string entityType,
            [FromQuery] long entityId)
        {
            try
            {
                var result = await _mediator.Send(new GetCommentsQuery(entityType, entityId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting comments for {EntityType}/{EntityId}", entityType, entityId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("{parentCommentId:long}/replies")]
        public async Task<ActionResult<IEnumerable<GetCommentDTO>>> GetReplies(long parentCommentId)
        {
            try
            {
                var result = await _mediator.Send(new GetCommentRepliesQuery(parentCommentId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting replies for comment {ParentCommentId}", parentCommentId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost]
        public async Task<ActionResult<GetCommentDTO>> Create([FromBody] CreateCommentDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new CreateCommentCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating comment");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPut("{uid:guid}")]
        public async Task<ActionResult<GetCommentDTO>> Update(Guid uid, [FromBody] UpdateCommentDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new UpdateCommentCommand(uid, entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating comment {Uid}", uid);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpDelete("{uid:guid}")]
        public async Task<ActionResult> Delete(Guid uid)
        {
            try
            {
                await _mediator.Send(new DeleteCommentCommand(uid));
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting comment {Uid}", uid);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }
    }
}
