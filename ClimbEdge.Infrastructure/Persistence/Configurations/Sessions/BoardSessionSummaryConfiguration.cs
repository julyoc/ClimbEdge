using ClimbEdge.Domain.Entities.Sessions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Sessions
{
    internal class BoardSessionSummaryConfiguration : IEntityTypeConfiguration<BoardSessionSummary>
    {
        public void Configure(EntityTypeBuilder<BoardSessionSummary> builder)
        {
            builder.ConfigureBaseModel();
            builder.HasOne(e => e.Board).WithMany().HasForeignKey(e => e.BoardId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
