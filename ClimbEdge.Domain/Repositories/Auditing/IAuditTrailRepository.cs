using ClimbEdge.Common.Constants;
using ClimbEdge.Domain.Entities.Auditing;
using ClimbEdge.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Repositories.Auditing
{
    public interface IAuditTrailRepository : IRepository<AuditTrail>
    {
        Task<IEnumerable<AuditTrail>> GetByEntityNameAsync(string name, int? page = null, int pageSize = Constants.MaxPageSize, Expression<Func<AuditTrail, bool>>? criteria = null);
        Task<IEnumerable<AuditTrail>> GetByEntityIdAsync(Guid id, int? page = null, int pageSize = Constants.MaxPageSize, Expression<Func<AuditTrail, bool>>? criteria = null);
        Task<IEnumerable<AuditTrail>> GetByEntityIdAsync(string id, int? page = null, int pageSize = Constants.MaxPageSize, Expression<Func<AuditTrail, bool>>? criteria = null);
        Task<IEnumerable<AuditTrail>> GetByUserIdAsync(Guid id, int? page = null, int pageSize = Constants.MaxPageSize, Expression<Func<AuditTrail, bool>>? criteria = null);
        Task<IEnumerable<AuditTrail>> GetByUserIdAsync(string id, int? page = null, int pageSize = Constants.MaxPageSize, Expression<Func<AuditTrail, bool>>? criteria = null);
        Task<IEnumerable<AuditTrail>> GetBySessionIdAsync(string id, int? page = null, int pageSize = Constants.MaxPageSize, Expression<Func<AuditTrail, bool>>? criteria = null);
        Task<IEnumerable<AuditTrail>> GetByIpAddressAsync(IPAddress ip, int? page = null, int pageSize = Constants.MaxPageSize, Expression<Func<AuditTrail, bool>>? criteria = null);
        Task<IEnumerable<AuditTrail>> GetByIpAddressAsync(string ip, int? page = null, int pageSize = Constants.MaxPageSize, Expression<Func<AuditTrail, bool>>? criteria = null);
        Task<IEnumerable<AuditTrail>> GetByCorrelationIdAsync(string id, int? page = null, int pageSize = Constants.MaxPageSize, Expression<Func<AuditTrail, bool>>? criteria = null);
    }
}
