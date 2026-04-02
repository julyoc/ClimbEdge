using ClimbEdge.Domain.Entities;
using ClimbEdge.Domain.Repositories;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Repositories
{
    public class UserExperienceLevelScaleRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService) : Repository<UserExperienceLevelScale>(climbEdgeContext, cacheService), IUserExperienceLevelScaleRepository
    {
    }
}
