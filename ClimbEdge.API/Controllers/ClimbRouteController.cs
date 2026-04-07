using Asp.Versioning;
using ClimbEdge.Application.Commands.ClimbRouteCommand;
using ClimbEdge.Application.DTOs;
using ClimbEdge.Application.Queries.ClimbRouteQuery;
using ClimbEdge.Application.Queries.DifficultyScaleQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClimbEdge.API.Controllers
{
    [ApiVersion("0.1")]
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ClimbRouteController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ClimbRouteController> _logger;

        public ClimbRouteController(IMediator mediator, ILogger<ClimbRouteController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetClimbRouteDTO>>> GetAll(
            [FromQuery] long? climbZoneId = null,
            [FromQuery] long? difficultyScaleNameId = null,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 20)
        {
            try
            {
                var result = await _mediator.Send(new GetClimbRoutesQuery(climbZoneId, difficultyScaleNameId, page, pageSize));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting climb routes");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("{uid:guid}")]
        public async Task<ActionResult<GetClimbRouteDTO>> GetByUid(Guid uid)
        {
            try
            {
                var result = await _mediator.Send(new GetClimbRouteQuery(uid));
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting climb route {Uid}", uid);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost]
        public async Task<ActionResult<GetClimbRouteDTO>> Create([FromBody] CreateClimbRouteDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new CreateClimbRouteCommand(entity));
                return CreatedAtAction(nameof(GetByUid), new { uid = result.Uid }, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating climb route");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPut("{uid:guid}")]
        public async Task<ActionResult<GetClimbRouteDTO>> Update(Guid uid, [FromBody] UpdateClimbRouteDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new UpdateClimbRouteCommand(uid, entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating climb route {Uid}", uid);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpDelete("{uid:guid}")]
        public async Task<ActionResult> Delete(Guid uid)
        {
            try
            {
                await _mediator.Send(new DeleteClimbRouteCommand(uid));
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting climb route {Uid}", uid);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("difficulty-scales")]
        public async Task<ActionResult<IEnumerable<GetDifficultyScaleDTO>>> GetDifficultyScales(
            [FromQuery] long? difficultyScaleNameId = null)
        {
            try
            {
                var result = await _mediator.Send(new GetDifficultyScalesQuery(difficultyScaleNameId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting difficulty scales");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }
    }
}
