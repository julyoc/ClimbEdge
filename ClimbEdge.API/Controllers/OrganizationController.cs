using Asp.Versioning;
using ClimbEdge.Application.Commands.OrganizationCommand;
using ClimbEdge.Application.DTOs;
using ClimbEdge.Application.Queries.OrganizationQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClimbEdge.API.Controllers
{
    [ApiVersion("0.1")]
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrganizationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<OrganizationController> _logger;

        public OrganizationController(IMediator mediator, ILogger<OrganizationController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetOrganizationDTO>>> GetAll(
            [FromQuery] bool? publicOnly = null,
            [FromQuery] string? country = null,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 20)
        {
            try
            {
                var result = await _mediator.Send(new GetOrganizationsQuery(publicOnly, country, page, pageSize));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting organizations");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("{uid:guid}")]
        public async Task<ActionResult<GetOrganizationDTO>> GetByUid(Guid uid)
        {
            try
            {
                var result = await _mediator.Send(new GetOrganizationQuery(uid));
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting organization {Uid}", uid);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost]
        public async Task<ActionResult<GetOrganizationDTO>> Create([FromBody] CreateOrganizationDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new CreateOrganizationCommand(entity));
                return CreatedAtAction(nameof(GetByUid), new { uid = result.Uid }, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating organization");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPut("{uid:guid}")]
        public async Task<ActionResult<GetOrganizationDTO>> Update(Guid uid, [FromBody] UpdateOrganizationDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new UpdateOrganizationCommand(uid, entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating organization {Uid}", uid);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("{organizationId:long}/members")]
        public async Task<ActionResult<IEnumerable<GetOrganizationMemberDTO>>> GetMembers(long organizationId)
        {
            try
            {
                var result = await _mediator.Send(new GetOrganizationMembersQuery(organizationId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting members for organization {OrganizationId}", organizationId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("member")]
        public async Task<ActionResult> AddMember([FromBody] AddOrganizationMemberDTO entity)
        {
            try
            {
                await _mediator.Send(new AddOrganizationMemberCommand(entity));
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding member to organization");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpDelete("member")]
        public async Task<ActionResult> RemoveMember([FromBody] RemoveOrganizationMemberDTO entity)
        {
            try
            {
                await _mediator.Send(new RemoveOrganizationMemberCommand(entity));
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing member from organization");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("{organizationId:long}/events")]
        public async Task<ActionResult<IEnumerable<GetOrganizationEventDTO>>> GetEvents(long organizationId)
        {
            try
            {
                var result = await _mediator.Send(new GetOrganizationEventsQuery(organizationId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting events for organization {OrganizationId}", organizationId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("event")]
        public async Task<ActionResult<GetOrganizationEventDTO>> CreateEvent([FromBody] CreateOrganizationEventDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new CreateOrganizationEventCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating organization event");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPut("event/{uid:guid}")]
        public async Task<ActionResult<GetOrganizationEventDTO>> UpdateEvent(Guid uid, [FromBody] UpdateOrganizationEventDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new UpdateOrganizationEventCommand(uid, entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating organization event {Uid}", uid);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("event/register")]
        public async Task<ActionResult<GetOrganizationEventParticipantDTO>> RegisterEventParticipant([FromBody] RegisterEventParticipantDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new RegisterEventParticipantCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error registering event participant");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }
    }
}
