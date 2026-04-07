using Asp.Versioning;
using ClimbEdge.Application.Commands.ClimbZoneCommand;
using ClimbEdge.Application.DTOs;
using ClimbEdge.Application.Queries.ClimbZoneQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClimbEdge.API.Controllers
{
    [ApiVersion("0.1")]
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ClimbZoneController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ClimbZoneController> _logger;

        public ClimbZoneController(IMediator mediator, ILogger<ClimbZoneController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetClimbZoneDTO>>> GetAll()
        {
            try
            {
                var result = await _mediator.Send(new GetClimbZonesQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting climb zones");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("{uid:guid}")]
        public async Task<ActionResult<GetClimbZoneDTO>> GetByUid(Guid uid)
        {
            try
            {
                var result = await _mediator.Send(new GetClimbZoneQuery(uid));
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting climb zone {Uid}", uid);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost]
        public async Task<ActionResult<GetClimbZoneDTO>> Create([FromBody] CreateClimbZoneDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new CreateClimbZoneCommand(entity));
                return CreatedAtAction(nameof(GetByUid), new { uid = result.Uid }, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating climb zone");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPut("{uid:guid}")]
        public async Task<ActionResult<GetClimbZoneDTO>> Update(Guid uid, [FromBody] UpdateClimbZoneDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new UpdateClimbZoneCommand(uid, entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating climb zone {Uid}", uid);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpDelete("{uid:guid}")]
        public async Task<ActionResult> Delete(Guid uid)
        {
            try
            {
                await _mediator.Send(new DeleteClimbZoneCommand(uid));
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting climb zone {Uid}", uid);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }
    }
}
