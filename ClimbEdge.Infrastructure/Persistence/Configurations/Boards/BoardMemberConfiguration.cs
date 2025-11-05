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
    public class BoardMemberConfiguration : IEntityTypeConfiguration<BoardMember>
    {
        public void Configure(EntityTypeBuilder<BoardMember> builder)
        {
            builder.ConfigureBaseModel();

            builder.Property(bm => bm.IsPropertyOwner)
                   .IsRequired()
                   .HasDefaultValue(false);
            builder.Property(bm => bm.Role)
                     .IsRequired();
            builder.HasIndex(bm => new { bm.BoardId, bm.UserId }).IsUnique();

            // Relaciones
            builder.HasOne(b => b.Board)
                   .WithMany(b => b.Members)
                   .HasForeignKey(b => b.BoardId)
                   .IsRequired();
            builder.HasOne(b => b.User)
                     .WithMany(b => b.Members)
                     .HasForeignKey(b => b.UserId)
                     .IsRequired();
        }
    }
}
