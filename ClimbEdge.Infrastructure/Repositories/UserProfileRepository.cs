using ClimbEdge.Domain.Entities;
using ClimbEdge.Domain.Repositories;
using ClimbEdge.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Repositories
{
    public class UserProfileRepository(ClimbEdgeContext climbEdgeContext) : Repository<UserProfile>(climbEdgeContext), IUserProfileRepository
    {
        public Task<UserProfile> GetUserProfileAsync(long userId) => _climbEdgeContext.Set<UserProfile>().FirstOrDefaultAsync(up => up.UserId == userId);

        public Task<UserProfile> GetUserProfileAsync(string userId) => GetByIdAsync(Guid.Parse(userId));
    }
}
