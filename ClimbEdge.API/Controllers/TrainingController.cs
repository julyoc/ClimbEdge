using Asp.Versioning;
using ClimbEdge.Application.Commands.TrainingCommand;
using ClimbEdge.Application.DTOs;
using ClimbEdge.Application.Queries.TrainingQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClimbEdge.API.Controllers
{
    [ApiVersion("0.1")]
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TrainingController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<TrainingController> _logger;

        public TrainingController(IMediator mediator, ILogger<TrainingController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        // ── Plans ──────────────────────────────────────────────────────────────

        [HttpGet("plans")]
        public async Task<ActionResult<IEnumerable<GetTrainingPlanDTO>>> GetPlans(
            [FromQuery] long userId,
            [FromQuery] bool? activeOnly = null,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 20)
        {
            try
            {
                var result = await _mediator.Send(new GetTrainingPlansQuery(userId, activeOnly, page, pageSize));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting training plans for user {UserId}", userId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("plans/{uid:guid}")]
        public async Task<ActionResult<GetTrainingPlanDTO>> GetPlan(Guid uid)
        {
            try
            {
                var result = await _mediator.Send(new GetTrainingPlanQuery(uid));
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting training plan {Uid}", uid);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("plans")]
        public async Task<ActionResult<GetTrainingPlanDTO>> CreatePlan([FromBody] CreateTrainingPlanDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new CreateTrainingPlanCommand(entity));
                return CreatedAtAction(nameof(GetPlan), new { uid = result.Uid }, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating training plan");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPut("plans/{uid:guid}")]
        public async Task<ActionResult<GetTrainingPlanDTO>> UpdatePlan(Guid uid, [FromBody] UpdateTrainingPlanDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new UpdateTrainingPlanCommand(uid, entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating training plan {Uid}", uid);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpDelete("plans/{uid:guid}")]
        public async Task<ActionResult> DeletePlan(Guid uid)
        {
            try
            {
                await _mediator.Send(new DeleteTrainingPlanCommand(uid));
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting training plan {Uid}", uid);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("plans/{planId:long}/progress")]
        public async Task<ActionResult<IEnumerable<GetTrainingProgressDTO>>> GetPlanProgress(long planId)
        {
            try
            {
                var result = await _mediator.Send(new GetTrainingProgressQuery(planId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting training progress for plan {PlanId}", planId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("progress")]
        public async Task<ActionResult<GetTrainingProgressDTO>> RecordProgress([FromBody] RecordTrainingProgressDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new RecordTrainingProgressCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error recording training progress");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        // ── Periods ────────────────────────────────────────────────────────────

        [HttpGet("plans/{planId:long}/periods")]
        public async Task<ActionResult<IEnumerable<GetTrainingPeriodDTO>>> GetPeriods(long planId)
        {
            try
            {
                var result = await _mediator.Send(new GetTrainingPeriodsQuery(planId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting training periods for plan {PlanId}", planId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("periods")]
        public async Task<ActionResult<GetTrainingPeriodDTO>> CreatePeriod([FromBody] CreateTrainingPeriodDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new CreateTrainingPeriodCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating training period");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        // ── Weeks ──────────────────────────────────────────────────────────────

        [HttpGet("periods/{periodId:long}/weeks")]
        public async Task<ActionResult<IEnumerable<GetTrainingWeekDTO>>> GetWeeks(long periodId)
        {
            try
            {
                var result = await _mediator.Send(new GetTrainingWeeksQuery(periodId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting training weeks for period {PeriodId}", periodId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("weeks")]
        public async Task<ActionResult<GetTrainingWeekDTO>> CreateWeek([FromBody] CreateTrainingWeekDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new CreateTrainingWeekCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating training week");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPut("weeks/complete")]
        public async Task<ActionResult<bool>> CompleteWeek([FromBody] CompleteTrainingWeekDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new CompleteTrainingWeekCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error completing training week");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("weeks/{weekId:long}/volume")]
        public async Task<ActionResult<GetTrainingVolumeDTO>> GetVolume(long weekId)
        {
            try
            {
                var result = await _mediator.Send(new GetTrainingVolumeQuery(weekId));
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting training volume for week {WeekId}", weekId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        // ── Sessions ───────────────────────────────────────────────────────────

        [HttpGet("weeks/{weekId:long}/sessions")]
        public async Task<ActionResult<IEnumerable<GetTrainingSessionDTO>>> GetSessions(long weekId)
        {
            try
            {
                var result = await _mediator.Send(new GetTrainingSessionsQuery(weekId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting training sessions for week {WeekId}", weekId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("sessions")]
        public async Task<ActionResult<GetTrainingSessionDTO>> CreateSession([FromBody] CreateTrainingSessionDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new CreateTrainingSessionCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating training session");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPut("sessions/log")]
        public async Task<ActionResult<GetTrainingSessionDTO>> LogSession([FromBody] LogTrainingSessionDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new LogTrainingSessionCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error logging training session");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPut("sessions/complete")]
        public async Task<ActionResult<GetTrainingSessionDTO>> CompleteSession([FromBody] CompleteTrainingSessionDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new CompleteTrainingSessionCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error completing training session");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("sessions/{sessionId:long}/exercises")]
        public async Task<ActionResult<IEnumerable<GetSessionExerciseDTO>>> GetSessionExercises(long sessionId)
        {
            try
            {
                var result = await _mediator.Send(new GetSessionExercisesQuery(sessionId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting exercises for session {SessionId}", sessionId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("sessions/exercise")]
        public async Task<ActionResult<GetSessionExerciseDTO>> LogExercise([FromBody] LogSessionExerciseDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new LogSessionExerciseCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error logging session exercise");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        // ── Exercises & Templates ──────────────────────────────────────────────

        [HttpGet("exercises")]
        public async Task<ActionResult<IEnumerable<GetTrainingExerciseDTO>>> GetExercises()
        {
            try
            {
                var result = await _mediator.Send(new GetTrainingExercisesQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting training exercises");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("templates")]
        public async Task<ActionResult<IEnumerable<GetTrainingTemplateDTO>>> GetTemplates()
        {
            try
            {
                var result = await _mediator.Send(new GetTrainingTemplatesQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting training templates");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        // ── Goals ──────────────────────────────────────────────────────────────

        [HttpGet("{userId:long}/goals")]
        public async Task<ActionResult<IEnumerable<GetTrainingGoalDTO>>> GetGoals(long userId)
        {
            try
            {
                var result = await _mediator.Send(new GetActiveTrainingGoalsQuery(userId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting goals for user {UserId}", userId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("goals")]
        public async Task<ActionResult<GetTrainingGoalDTO>> SetGoal([FromBody] SetTrainingGoalDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new SetTrainingGoalCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error setting training goal");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPut("goals/{uid:guid}/achieve")]
        public async Task<ActionResult<GetTrainingGoalDTO>> AchieveGoal(Guid uid)
        {
            try
            {
                var result = await _mediator.Send(new MarkTrainingGoalAchievedCommand(uid));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error marking training goal as achieved {Uid}", uid);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        // ── Fitness & Physiology ───────────────────────────────────────────────

        [HttpPost("fitness-test")]
        public async Task<ActionResult<GetFitnessTestDTO>> RecordFitnessTest([FromBody] RecordFitnessTestDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new RecordFitnessTestCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error recording fitness test");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("{userId:long}/fitness-tests")]
        public async Task<ActionResult<IEnumerable<GetFitnessTestDTO>>> GetFitnessTests(long userId)
        {
            try
            {
                var result = await _mediator.Send(new GetFitnessTestHistoryQuery(userId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting fitness tests for user {UserId}", userId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("physiological-data")]
        public async Task<ActionResult<GetPhysiologicalDataDTO>> RecordPhysiologicalData([FromBody] RecordPhysiologicalDataDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new RecordPhysiologicalDataCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error recording physiological data");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("{userId:long}/physiological-data")]
        public async Task<ActionResult<IEnumerable<GetPhysiologicalDataDTO>>> GetPhysiologicalData(long userId)
        {
            try
            {
                var result = await _mediator.Send(new GetPhysiologicalDataHistoryQuery(userId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting physiological data for user {UserId}", userId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }
    }
}
