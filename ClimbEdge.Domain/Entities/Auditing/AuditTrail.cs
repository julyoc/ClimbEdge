using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Enums;
using ClimbEdge.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities.Auditing
{
    public class AuditTrail : BaseModel
    {
        public AuditTrail() : base() { }
        public string EntityName { get; set; }
        public Guid EntityId { get; set; }
        public AuditActionType AuditActionType { get; set; }
        public Guid? UserId { get; set; }
        public string? SessionId { get; set; }
        public IPAddress? IpAddress { get; set; }
        public string? UserAgent { get; set; }
        public Dictionary<string, Object>? OldValues { get; set; }
        public Dictionary<string, Object>? NewValues { get; set; }
        public string? ChangesSummary { get; set; }
        public string? ReasonForChange { get; set; }
        public string[]? AffectedColumns { get; set; }
        public string? CorrelationId { get; set; }
        public AuditRiskLevel? RiskLevel { get; set; }
        public bool IsSystemAction { get; set; } = false;
        public int? Duration { get; set; }
        public ResultStatus? ResultStatus { get; set; }
        public string? ErrorMessage { get; set; }
        public Dictionary<string, Object>? AdditionalContext { get; set; }
        public override void InitializeSlug()
        {
            Slug = $"{EntityName}/{AuditActionType}/{IpAddress}/{CreatedAt.Ticks}";
            AddDomainEvent(new EntityDomainEvent<UserProfile>(Slug, EntityDomainEventType.Created));
        }
    }
}
