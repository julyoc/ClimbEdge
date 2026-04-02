using ClimbEdge.Domain.Entities.Sessions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Sessions
{
    internal class UserSessionProgressConfiguration : IEntityTypeConfiguration<UserSessionProgress>
    {
        public void Configure(EntityTypeBuilder<UserSessionProgress> builder)
        {
            builder.ConfigureBaseModel();
            builder.HasOne(e => e.UserSession).WithMany(e => e.Progress).HasForeignKey(e => e.UserSessionId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
