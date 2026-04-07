using ClimbEdge.Domain.Enums.Notifications;

namespace ClimbEdge.Application.DTOs
{
    public record class GetNotificationDTO : BaseDTO
    {
        public long UserId { get; set; }
        public NotificationType Type { get; set; }
        public string? Subject { get; set; }
        public string Message { get; set; } = string.Empty;
        public NotificationStatus Status { get; set; }
        public DateTime? SentAt { get; set; }
        public DateTime? ReadAt { get; set; }
    }

    public record class MarkNotificationsReadDTO
    {
        public long UserId { get; set; }
        public IEnumerable<Guid>? NotificationUids { get; set; }
        public bool MarkAll { get; set; } = false;
    }

    public record class UpdateNotificationPreferenceDTO
    {
        public long UserId { get; set; }
        public string Category { get; set; } = string.Empty;
        public bool EmailEnabled { get; set; } = true;
        public bool PushEnabled { get; set; } = true;
        public bool InAppEnabled { get; set; } = true;
        public bool SMSEnabled { get; set; } = false;
    }

    public record class GetNotificationPreferenceDTO : BaseDTO
    {
        public long UserId { get; set; }
        public string Category { get; set; } = string.Empty;
        public bool EmailEnabled { get; set; }
        public bool PushEnabled { get; set; }
        public bool InAppEnabled { get; set; }
        public bool SMSEnabled { get; set; }
    }
}
