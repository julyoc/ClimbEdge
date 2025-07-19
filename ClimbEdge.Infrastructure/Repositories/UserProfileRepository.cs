using ClimbEdge.Domain.Entities;
using ClimbEdge.Domain.Repositories;
using ClimbEdge.Infrastructure.Caching;
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
    public class UserProfileRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService) : Repository<UserProfile>(climbEdgeContext, cacheService), IUserProfileRepository
    {
        public async Task<UserProfile> GetUserProfileAsync(long userId)
        {
            var cachedEntity = await _cacheService.GetAsync<UserProfile>($"{nameof(UserProfile)}_user_{userId}");
            if (cachedEntity != null) return cachedEntity;
            var entity = await _climbEdgeContext.Set<UserProfile>().FirstOrDefaultAsync(up => up.AppUserId == userId);
            await _cacheService.SetAsync($"{nameof(UserProfile)}_user_{userId}", entity);
            return entity ?? throw new KeyNotFoundException($"UserProfile with UserId {userId} not found.");
        }
    }
}
