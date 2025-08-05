using ClimbEdge.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Auditing
{
    internal class AuditTrailConfiguration : IEntityTypeConfiguration<AuditTrail>
    {
        public void Configure(EntityTypeBuilder<AuditTrail> builder)
        {
            // Configurar propiedades heredadas de BaseModel
            builder.ConfigureBaseModel();

            // Configurar propiedades específicas
            builder.Property(e => e.EntityName).IsRequired().HasMaxLength(128);
            builder.Property(e => e.EntityId).IsRequired();
            builder.Property(e => e.AuditActionType).IsRequired();
            builder.Property(e => e.UserId);
            builder.Property(e => e.SessionId);
            builder.Property(e => e.IpAddress).HasColumnType("inet");
            builder.Property(e => e.UserAgent).HasMaxLength(99);
            builder.Property(e => e.OldValues).HasColumnType("jsonb");
            builder.Property(e => e.NewValues).HasColumnType("jsonb");
            builder.Property(e => e.ChangesSummary);
            builder.Property(e => e.ReasonForChange);
            builder.Property(e => e.AffectedColumns).HasColumnType("varchar(99)[]");
            builder.Property(e => e.CorrelationId);
            builder.Property(e => e.RiskLevel);
            builder.Property(e => e.IsSystemAction).HasDefaultValue(false);
            builder.Property(e => e.Duration); // miilisegundos
            builder.Property(e => e.ResultStatus);
            builder.Property(e => e.ErrorMessage);
            builder.Property(e => e.AdditionalContext).HasColumnType("jsonb");

            // Índices
            builder.HasIndex(e => e.UserId);
            builder.HasIndex(e => e.EntityName);
            builder.HasIndex(e => e.EntityId);
            builder.HasIndex(e => e.SessionId);
            builder.HasIndex(e => e.IpAddress);
            builder.HasIndex(e => e.CorrelationId);
        }
    }
}
