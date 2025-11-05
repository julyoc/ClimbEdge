using ClimbEdge.Domain.Entities;
using ClimbEdge.Domain.Enums;
using ClimbEdge.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Repositories
{
    public interface IConfigurationRepository : IRepository<Configuration>
    {
        Task<IEnumerable<Configuration>> GetByKeyAsync(ConfigurationKey key);
        Task<IEnumerable<Configuration>> GetByUserId(long userId);
    }
}
