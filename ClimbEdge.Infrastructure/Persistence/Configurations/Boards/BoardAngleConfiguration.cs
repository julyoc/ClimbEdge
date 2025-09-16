using ClimbEdge.Domain.Entities.Boards;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Boards
{
    internal class BoardAngleConfiguration : IEntityTypeConfiguration<BoardAngle>
    {
        public void Configure(EntityTypeBuilder<BoardAngle> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(ba => ba.Angle)
                   .IsRequired();
            builder.HasIndex(ba => new { ba.Angle, ba.Unit }).IsUnique();
            builder.Property(ba => ba.Unit)
                   .IsRequired();
            builder.Property(ba => ba.Description);
        }
    }
}
