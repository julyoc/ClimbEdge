using Asp.Versioning;
using ClimbEdge.Application.Commands.ExpeditionCommand;
using ClimbEdge.Application.DTOs;
using ClimbEdge.Application.Queries.ExpeditionQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClimbEdge.API.Controllers
{
    [ApiVersion("0.1")]
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ExpeditionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ExpeditionController> _logger;

        public ExpeditionController(IMediator mediator, ILogger<ExpeditionController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetExpeditionDTO>>> GetAll(
            [FromQuery] long? mountainId = null,
            [FromQuery] long? organizedBy = null,
            [FromQuery] bool? publicOnly = null,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 20)
        {
            try
            {
                var result = await _mediator.Send(new GetExpeditionsQuery(mountainId, organizedBy, publicOnly, page, pageSize));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting expeditions");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("{uid:guid}")]
        public async Task<ActionResult<GetExpeditionDTO>> GetByUid(Guid uid)
        {
            try
            {
                var result = await _mediator.Send(new GetExpeditionQuery(uid));
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting expedition {Uid}", uid);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost]
        public async Task<ActionResult<GetExpeditionDTO>> Create([FromBody] CreateExpeditionDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new CreateExpeditionCommand(entity));
                return CreatedAtAction(nameof(GetByUid), new { uid = result.Uid }, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating expedition");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPut("{uid:guid}")]
        public async Task<ActionResult<GetExpeditionDTO>> Update(Guid uid, [FromBody] UpdateExpeditionDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new UpdateExpeditionCommand(uid, entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating expedition {Uid}", uid);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("activate")]
        public async Task<ActionResult<bool>> Activate([FromBody] ActivateExpeditionDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new ActivateExpeditionCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error activating expedition");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("close")]
        public async Task<ActionResult<bool>> Close([FromBody] CloseExpeditionDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new CloseExpeditionCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error closing expedition");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("{uid:guid}/performance")]
        public async Task<ActionResult<GetExpeditionPerformanceSummaryDTO>> GetPerformance(Guid uid)
        {
            try
            {
                var result = await _mediator.Send(new GetExpeditionPerformanceSummaryQuery(uid));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting expedition performance {Uid}", uid);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("{expeditionId:long}/participants")]
        public async Task<ActionResult<IEnumerable<GetExpeditionParticipantDTO>>> GetParticipants(long expeditionId)
        {
            try
            {
                var result = await _mediator.Send(new GetExpeditionParticipantsQuery(expeditionId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting participants for expedition {ExpeditionId}", expeditionId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("participant")]
        public async Task<ActionResult> AddParticipant([FromBody] AddExpeditionParticipantDTO entity)
        {
            try
            {
                await _mediator.Send(new AddExpeditionParticipantCommand(entity));
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding expedition participant");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("{expeditionId:long}/equipment")]
        public async Task<ActionResult<IEnumerable<GetExpeditionEquipmentDTO>>> GetEquipment(long expeditionId)
        {
            try
            {
                var result = await _mediator.Send(new GetExpeditionEquipmentQuery(expeditionId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting equipment for expedition {ExpeditionId}", expeditionId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("equipment")]
        public async Task<ActionResult> AddEquipment([FromBody] AddExpeditionEquipmentDTO entity)
        {
            try
            {
                await _mediator.Send(new AddExpeditionEquipmentCommand(entity));
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding expedition equipment");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpDelete("equipment/{id:long}")]
        public async Task<ActionResult> RemoveEquipment(long id)
        {
            try
            {
                await _mediator.Send(new RemoveExpeditionEquipmentCommand(id));
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing expedition equipment {Id}", id);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("{expeditionId:long}/budget")]
        public async Task<ActionResult<IEnumerable<GetExpeditionBudgetDTO>>> GetBudget(long expeditionId)
        {
            try
            {
                var result = await _mediator.Send(new GetExpeditionBudgetQuery(expeditionId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting budget for expedition {ExpeditionId}", expeditionId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("budget")]
        public async Task<ActionResult<GetExpeditionBudgetDTO>> CreateBudget([FromBody] CreateExpeditionBudgetDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new CreateExpeditionBudgetCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating expedition budget");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("{expeditionId:long}/itinerary")]
        public async Task<ActionResult<IEnumerable<GetItineraryDayDTO>>> GetItinerary(long expeditionId)
        {
            try
            {
                var result = await _mediator.Send(new GetItineraryDaysQuery(expeditionId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting itinerary for expedition {ExpeditionId}", expeditionId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("itinerary/day")]
        public async Task<ActionResult<GetItineraryDayDTO>> CreateItineraryDay([FromBody] CreateItineraryDayDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new CreateItineraryDayCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating itinerary day");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("{expeditionId:long}/tracks")]
        public async Task<ActionResult<IEnumerable<GetItineraryTrackDTO>>> GetTracks(long expeditionId)
        {
            try
            {
                var result = await _mediator.Send(new GetItineraryTracksQuery(expeditionId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting tracks for expedition {ExpeditionId}", expeditionId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("itinerary/track")]
        public async Task<ActionResult<long>> CreateTrack([FromBody] CreateItineraryTrackDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new CreateItineraryTrackCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating itinerary track");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPut("itinerary/track/complete")]
        public async Task<ActionResult> CompleteTrack([FromBody] CompleteItineraryTrackDTO entity)
        {
            try
            {
                await _mediator.Send(new CompleteItineraryTrackCommand(entity));
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error completing itinerary track");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("{expeditionId:long}/logs")]
        public async Task<ActionResult<IEnumerable<GetExpeditionLogDTO>>> GetLogs(long expeditionId)
        {
            try
            {
                var result = await _mediator.Send(new GetExpeditionLogsQuery(expeditionId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting logs for expedition {ExpeditionId}", expeditionId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("log")]
        public async Task<ActionResult<long>> RecordLog([FromBody] RecordExpeditionLogDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new RecordExpeditionLogCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error recording expedition log");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("{expeditionId:long}/summit-history")]
        public async Task<ActionResult<IEnumerable<GetSummitAttemptDTO>>> GetSummitHistory(long expeditionId)
        {
            try
            {
                var result = await _mediator.Send(new GetExpeditionSummitHistoryQuery(expeditionId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting summit history for expedition {ExpeditionId}", expeditionId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("summit")]
        public async Task<ActionResult<long>> RecordSummit([FromBody] RecordSummitAttemptDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new RecordSummitAttemptCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error recording summit attempt");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("{expeditionId:long}/incidents")]
        public async Task<ActionResult<IEnumerable<GetExpeditionIncidentDTO>>> GetIncidents(long expeditionId)
        {
            try
            {
                var result = await _mediator.Send(new GetExpeditionIncidentHistoryQuery(expeditionId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting incidents for expedition {ExpeditionId}", expeditionId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("incident")]
        public async Task<ActionResult<long>> RegisterIncident([FromBody] RegisterExpeditionIncidentDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new RegisterExpeditionIncidentCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error registering expedition incident");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("{expeditionId:long}/decisions")]
        public async Task<ActionResult<IEnumerable<GetCriticalDecisionDTO>>> GetDecisions(long expeditionId)
        {
            try
            {
                var result = await _mediator.Send(new GetExpeditionCriticalDecisionsQuery(expeditionId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting decisions for expedition {ExpeditionId}", expeditionId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("decision")]
        public async Task<ActionResult<long>> RegisterDecision([FromBody] RegisterCriticalDecisionDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new RegisterCriticalDecisionCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error registering critical decision");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("debrief")]
        public async Task<ActionResult<long>> WriteDebrief([FromBody] WriteExpeditionDebriefDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new WriteExpeditionDebriefCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error writing expedition debrief");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("{expeditionId:long}/debrief")]
        public async Task<ActionResult<GetExpeditionDebriefDTO>> GetDebrief(long expeditionId)
        {
            try
            {
                var result = await _mediator.Send(new GetExpeditionDebriefQuery(expeditionId));
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting debrief for expedition {ExpeditionId}", expeditionId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        // ── SafetyPlan ─────────────────────────────────────────────────────────

        [HttpGet("{expeditionId:long}/safety-plan")]
        public async Task<ActionResult<GetSafetyPlanDTO>> GetSafetyPlan(long expeditionId)
        {
            try
            {
                var result = await _mediator.Send(new GetSafetyPlanQuery(expeditionId));
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting safety plan for expedition {ExpeditionId}", expeditionId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("safety-plan")]
        public async Task<ActionResult<GetSafetyPlanDTO>> CreateSafetyPlan([FromBody] CreateSafetyPlanDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new CreateSafetyPlanCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating safety plan");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPut("{expeditionId:long}/safety-plan")]
        public async Task<ActionResult<GetSafetyPlanDTO>> UpdateSafetyPlan(long expeditionId, [FromBody] UpdateSafetyPlanDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new UpdateSafetyPlanCommand(expeditionId, entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating safety plan for expedition {ExpeditionId}", expeditionId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        // ── ItineraryDayTrack ──────────────────────────────────────────────────

        [HttpGet("itinerary/day/{itineraryDayId:long}/tracks")]
        public async Task<ActionResult<IEnumerable<GetItineraryDayTrackDTO>>> GetDayTracks(long itineraryDayId)
        {
            try
            {
                var result = await _mediator.Send(new GetItineraryDayTracksQuery(itineraryDayId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting day tracks for itinerary day {ItineraryDayId}", itineraryDayId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("itinerary/day/track")]
        public async Task<ActionResult<GetItineraryDayTrackDTO>> CreateDayTrack([FromBody] CreateItineraryDayTrackDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new CreateItineraryDayTrackCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating itinerary day track");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        // ── ItineraryDayWaypoint ───────────────────────────────────────────────

        [HttpGet("itinerary/day/{itineraryDayId:long}/waypoints")]
        public async Task<ActionResult<IEnumerable<GetItineraryDayWaypointDTO>>> GetDayWaypoints(long itineraryDayId)
        {
            try
            {
                var result = await _mediator.Send(new GetItineraryDayWaypointsQuery(itineraryDayId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting waypoints for itinerary day {ItineraryDayId}", itineraryDayId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("itinerary/day/waypoint")]
        public async Task<ActionResult<GetItineraryDayWaypointDTO>> CreateDayWaypoint([FromBody] CreateItineraryDayWaypointDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new CreateItineraryDayWaypointCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating itinerary day waypoint");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        // ── Equipment catalog ──────────────────────────────────────────────────

        [HttpGet("equipment/catalog")]
        public async Task<ActionResult<IEnumerable<GetEquipmentDTO>>> GetEquipmentCatalog([FromQuery] long? categoryId = null)
        {
            try
            {
                var result = await _mediator.Send(new GetEquipmentCatalogQuery(categoryId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting equipment catalog");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("equipment/catalog")]
        public async Task<ActionResult<GetEquipmentDTO>> CreateEquipmentCatalogItem([FromBody] CreateEquipmentDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new CreateEquipmentCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating equipment catalog item");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        // ── DELETE ─────────────────────────────────────────────────────────────

        [HttpDelete("{uid:guid}")]
        public async Task<ActionResult> Delete(Guid uid)
        {
            try
            {
                await _mediator.Send(new DeleteExpeditionCommand(uid));
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting expedition {Uid}", uid);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }
    }
}
