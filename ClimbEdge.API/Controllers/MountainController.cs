using Asp.Versioning;
using ClimbEdge.Application.Commands.MountainCommand;
using ClimbEdge.Application.DTOs;
using ClimbEdge.Application.Queries.MountainQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClimbEdge.API.Controllers
{
    [ApiVersion("0.1")]
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MountainController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<MountainController> _logger;

        public MountainController(IMediator mediator, ILogger<MountainController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetMountainDTO>>> GetAll()
        {
            try
            {
                var result = await _mediator.Send(new GetMountainsQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting mountains");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("{uid:guid}")]
        public async Task<ActionResult<GetMountainDTO>> GetByUid(Guid uid)
        {
            try
            {
                var result = await _mediator.Send(new GetMountainQuery(uid));
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting mountain {Uid}", uid);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost]
        public async Task<ActionResult<GetMountainDTO>> Create([FromBody] CreateMountainDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new CreateMountainCommand(entity));
                return CreatedAtAction(nameof(GetByUid), new { uid = result.Uid }, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating mountain");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPut("{uid:guid}")]
        public async Task<ActionResult<GetMountainDTO>> Update(Guid uid, [FromBody] UpdateMountainDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new UpdateMountainCommand(uid, entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating mountain {Uid}", uid);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("{mountainId:long}/routes")]
        public async Task<ActionResult<IEnumerable<GetMountainRouteDTO>>> GetRoutes(long mountainId)
        {
            try
            {
                var result = await _mediator.Send(new GetMountainRoutesQuery(mountainId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting routes for mountain {MountainId}", mountainId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("route/{uid:guid}")]
        public async Task<ActionResult<GetMountainRouteDTO>> GetRoute(Guid uid)
        {
            try
            {
                var result = await _mediator.Send(new GetMountainRouteQuery(uid));
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting mountain route {Uid}", uid);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("route")]
        public async Task<ActionResult<GetMountainRouteDTO>> CreateRoute([FromBody] CreateMountainRouteDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new CreateMountainRouteCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating mountain route");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPut("route/{uid:guid}")]
        public async Task<ActionResult<GetMountainRouteDTO>> UpdateRoute(Guid uid, [FromBody] UpdateMountainRouteDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new UpdateMountainRouteCommand(uid, entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating mountain route {Uid}", uid);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }
    }
}
