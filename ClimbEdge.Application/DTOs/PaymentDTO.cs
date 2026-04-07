using ClimbEdge.Domain.Enums.Payment;

namespace ClimbEdge.Application.DTOs
{
    public record class CreateSubscriptionDTO
    {
        public long UserId { get; set; }
        public long PlanId { get; set; }
        public bool AutoRenew { get; set; } = true;
    }

    public record class GetSubscriptionDTO : BaseDTO
    {
        public long UserId { get; set; }
        public long PlanId { get; set; }
        public SubscriptionStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? NextBillingDate { get; set; }
        public bool AutoRenew { get; set; }
        public DateTime? CancelledAt { get; set; }
        public string? CancellationReason { get; set; }
    }

    public record class CancelSubscriptionDTO
    {
        public Guid SubscriptionUid { get; set; }
        public string? CancellationReason { get; set; }
    }

    public record class GetPlanDTO : BaseDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string BillingPeriod { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public int? MaxBoards { get; set; }
        public int? MaxMembers { get; set; }
        public int? AIGenerationsPerMonth { get; set; }
    }

    public record class AddPaymentMethodDTO
    {
        public long UserId { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Provider { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string? LastFourDigits { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool IsDefault { get; set; } = false;
    }

    public record class GetPaymentMethodDTO : BaseDTO
    {
        public long UserId { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Provider { get; set; } = string.Empty;
        public string? LastFourDigits { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
    }
}
