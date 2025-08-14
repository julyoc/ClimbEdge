using ClimbEdge.Domain.Entities;
using ClimbEdge.Domain.Enums;
using ClimbEdge.Domain.Interfaces;
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
    public class ConfigurationRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService) : Repository<Configuration>(climbEdgeContext, cacheService), IConfigurationRepository
    {
        public Task<IEnumerable<Configuration>> GetByKeyAsync(ConfigurationKey key) => GetAsync(criteria: c => c.Key == key);
        public Task<IEnumerable<Configuration>> GetByUserId(long userId) => GetAsync(criteria: c => c.UserId == userId);
    }
}
