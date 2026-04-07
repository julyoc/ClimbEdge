using Asp.Versioning;
using ClimbEdge.Application.Commands.BoardCommand;
using ClimbEdge.Application.Commands.BoardProblemCommand;
using ClimbEdge.Application.DTOs;
using ClimbEdge.Application.Queries.BoardProblemQuery;
using ClimbEdge.Application.Queries.BoardQuery;
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
    public class BoardController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<BoardController> _logger;

        public BoardController(IMediator mediator, ILogger<BoardController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetBoardDTO>>> GetAll(
            [FromQuery] long? organizationId = null,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 20)
        {
            try
            {
                var result = await _mediator.Send(new GetBoardsQuery(organizationId, page, pageSize));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting boards");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("{uid:guid}")]
        public async Task<ActionResult<GetBoardDTO>> GetByUid(Guid uid)
        {
            try
            {
                var result = await _mediator.Send(new GetBoardQuery(uid));
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting board {Uid}", uid);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost]
        public async Task<ActionResult<GetBoardDTO>> Create([FromBody] CreateBoardDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new CreateBoardCommand(entity));
                return CreatedAtAction(nameof(GetByUid), new { uid = result.Uid }, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating board");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPut("{uid:guid}")]
        public async Task<ActionResult<GetBoardDTO>> Update(Guid uid, [FromBody] UpdateBoardDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new UpdateBoardCommand(uid, entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating board {Uid}", uid);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpDelete("{uid:guid}")]
        public async Task<ActionResult> Delete(Guid uid)
        {
            try
            {
                await _mediator.Send(new DeleteBoardCommand(uid));
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting board {Uid}", uid);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("{boardId:long}/members")]
        public async Task<ActionResult<IEnumerable<GetBoardMemberDTO>>> GetMembers(long boardId)
        {
            try
            {
                var result = await _mediator.Send(new GetBoardMembersQuery(boardId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting members for board {BoardId}", boardId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("member")]
        public async Task<ActionResult<GetBoardMemberDTO>> AddMember([FromBody] AddBoardMemberDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new AddBoardMemberCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding board member");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpDelete("member")]
        public async Task<ActionResult> RemoveMember([FromQuery] long boardId, [FromQuery] long userId)
        {
            try
            {
                await _mediator.Send(new RemoveBoardMemberCommand(boardId, userId));
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing board member");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("{boardId:long}/session-summary/{userId:long}")]
        public async Task<ActionResult<GetBoardSessionSummaryDTO>> GetSessionSummary(long boardId, long userId)
        {
            try
            {
                var result = await _mediator.Send(new GetBoardSessionSummaryQuery(boardId, userId));
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting board session summary");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("{boardConfigId:long}/problems")]
        public async Task<ActionResult<IEnumerable<GetBoardProblemDTO>>> GetProblems(
            long boardConfigId,
            [FromQuery] bool includeArchived = false,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 20)
        {
            try
            {
                var result = await _mediator.Send(new GetBoardProblemsQuery(boardConfigId, includeArchived, page, pageSize));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting problems for board config {BoardConfigId}", boardConfigId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("problem/{uid:guid}")]
        public async Task<ActionResult<GetBoardProblemDTO>> GetProblem(Guid uid)
        {
            try
            {
                var result = await _mediator.Send(new GetBoardProblemQuery(uid));
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting board problem {Uid}", uid);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("problem")]
        public async Task<ActionResult<GetBoardProblemDTO>> CreateProblem([FromBody] CreateBoardProblemDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new CreateBoardProblemCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating board problem");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPut("problem/{uid:guid}")]
        public async Task<ActionResult<GetBoardProblemDTO>> UpdateProblem(Guid uid, [FromBody] UpdateBoardProblemDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new UpdateBoardProblemCommand(uid, entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating board problem {Uid}", uid);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpDelete("problem/{uid:guid}")]
        public async Task<ActionResult> DeleteProblem(Guid uid)
        {
            try
            {
                await _mediator.Send(new DeleteBoardProblemCommand(uid));
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting board problem {Uid}", uid);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPut("problem/{uid:guid}/archive")]
        public async Task<ActionResult<GetBoardProblemDTO>> ArchiveProblem(Guid uid)
        {
            try
            {
                var result = await _mediator.Send(new ArchiveBoardProblemCommand(uid));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error archiving board problem {Uid}", uid);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }
    }
}
