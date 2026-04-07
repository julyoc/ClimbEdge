using Asp.Versioning;
using ClimbEdge.Application.Commands.PaymentCommand;
using ClimbEdge.Application.DTOs;
using ClimbEdge.Application.Queries.PaymentQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClimbEdge.API.Controllers
{
    [ApiVersion("0.1")]
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(IMediator mediator, ILogger<PaymentController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("plans")]
        public async Task<ActionResult<IEnumerable<GetPlanDTO>>> GetPlans([FromQuery] bool activeOnly = true)
        {
            try
            {
                var result = await _mediator.Send(new GetPlansQuery(activeOnly));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting plans");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("subscription")]
        public async Task<ActionResult<GetSubscriptionDTO>> GetSubscription([FromQuery] long userId)
        {
            try
            {
                var result = await _mediator.Send(new GetSubscriptionQuery(userId));
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting subscription for user {UserId}", userId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("subscription")]
        public async Task<ActionResult<GetSubscriptionDTO>> CreateSubscription([FromBody] CreateSubscriptionDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new CreateSubscriptionCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating subscription");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPut("subscription/cancel")]
        public async Task<ActionResult<GetSubscriptionDTO>> CancelSubscription([FromBody] CancelSubscriptionDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new CancelSubscriptionCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error cancelling subscription");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("methods")]
        public async Task<ActionResult<IEnumerable<GetPaymentMethodDTO>>> GetMethods([FromQuery] long userId)
        {
            try
            {
                var result = await _mediator.Send(new GetPaymentMethodsQuery(userId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting payment methods for user {UserId}", userId);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpPost("methods")]
        public async Task<ActionResult<GetPaymentMethodDTO>> AddMethod([FromBody] AddPaymentMethodDTO entity)
        {
            try
            {
                var result = await _mediator.Send(new AddPaymentMethodCommand(entity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding payment method");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        [HttpDelete("methods/{uid:guid}")]
        public async Task<ActionResult> RemoveMethod(Guid uid)
        {
            try
            {
                await _mediator.Send(new RemovePaymentMethodCommand(uid));
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing payment method {Uid}", uid);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }
    }
}
