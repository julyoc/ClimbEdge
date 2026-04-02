using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Mountains.Itinerary
{
    internal class ExpeditionConfiguration : IEntityTypeConfiguration<Expedition>
    {
        public void Configure(EntityTypeBuilder<Expedition> builder)
        {
            builder.ConfigureBaseModel();

            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Description).HasColumnType("text");
            builder.Property(e => e.Status).IsRequired();
            builder.Property(e => e.StartDate).IsRequired();
            builder.Property(e => e.EndDate).IsRequired();
            builder.Property(e => e.PlannedDurationDays).IsRequired();
            builder.Property(e => e.MinParticipants).IsRequired();
            builder.Property(e => e.MaxParticipants).IsRequired();
            builder.Property(e => e.RequiresPermit).IsRequired();
            builder.Property(e => e.InsuranceRequired).IsRequired();
            builder.Property(e => e.IsPublic).IsRequired();
            builder.Property(e => e.IsDraft).IsRequired();
            builder.Property(e => e.BaseCampLocation).HasGeoZ();
            builder.Property(e => e.BaseCampInfo)
                   .HasColumnType("jsonb")
                   .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                       v => JsonSerializer.Deserialize<Dictionary<string, object>>(v, (JsonSerializerOptions)null!));

            builder.HasIndex(e => e.Name).IsUnique();
            builder.HasIndex(e => e.BaseCampLocation).IsGeoIndex();

            builder.HasOne(e => e.Mountain).WithMany(e => e.Expeditions).HasForeignKey(e => e.MountainId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.MountainRoute).WithMany(e => e.Expeditions).HasForeignKey(e => e.MountainRouteId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.OrganizedUser).WithMany(e => e.Expeditions).HasForeignKey(e => e.OrganizedBy).IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.OrganizedByOrganization).WithMany(e => e.Expeditions).HasForeignKey(e => e.OrganizedByOrganizationId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(e => e.DifficultyScales).WithMany(e => e.Expeditions).UsingEntity<ExpeditionLevelScales>();
            builder.HasMany(e => e.Participants).WithMany(e => e.ExpeditionsJoined).UsingEntity<ExpeditionParticipant>();
        }
    }
}
