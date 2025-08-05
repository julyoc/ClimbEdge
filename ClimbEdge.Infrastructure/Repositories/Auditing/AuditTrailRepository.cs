using ClimbEdge.Common.Constants;
using ClimbEdge.Domain.Entities.Auditing;
using ClimbEdge.Domain.Repositories.Auditing;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClimbEdge.Infrastructure.Repositories.Auditing
{
    public class AuditTrailRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService) : Repository<AuditTrail>(climbEdgeContext, cacheService, false), IAuditTrailRepository
    {
        public Task<IEnumerable<AuditTrail>> GetByCorrelationIdAsync(string id, int? page = null, int pageSize = Constants.MaxPageSize, Func<AuditTrail, bool>? criteria = null)
        {
            if (page.HasValue) return GetAsync((e) => e.CorrelationId == id && (criteria == null || criteria(e)), page.Value, pageSize);
            return GetAsync((e) => e.CorrelationId == id && (criteria == null || criteria(e)));
        }
        public Task<IEnumerable<AuditTrail>> GetByEntityIdAsync(Guid id, int? page = null, int pageSize = Constants.MaxPageSize, Func<AuditTrail, bool>? criteria = null)
        {
            if (page.HasValue) return GetAsync((e) => e.EntityId == id && (criteria == null || criteria(e)), page.Value, pageSize);
            return GetAsync((e) => e.EntityId == id && (criteria == null || criteria(e)));
        }
        public Task<IEnumerable<AuditTrail>> GetByEntityIdAsync(string id, int? page = null, int pageSize = Constants.MaxPageSize, Func<AuditTrail, bool>? criteria = null) => GetByEntityIdAsync(Guid.Parse(id), page, pageSize, criteria);
        public Task<IEnumerable<AuditTrail>> GetByEntityNameAsync(string name, int? page = null, int pageSize = Constants.MaxPageSize, Func<AuditTrail, bool>? criteria = null)
        {
            if (page.HasValue) return GetAsync((e) => e.EntityName == name && (criteria == null || criteria(e)), page.Value, pageSize);
            return GetAsync((e) => e.EntityName == name && (criteria == null || criteria(e)));
        }
        public Task<IEnumerable<AuditTrail>> GetByIpAddressAsync(IPAddress ip, int? page = null, int pageSize = Constants.MaxPageSize, Func<AuditTrail, bool>? criteria = null)
        {
            if (page.HasValue) return GetAsync((e) => e.IpAddress == ip && (criteria == null || criteria(e)), page.Value, pageSize);
            return GetAsync((e) => e.IpAddress == ip && (criteria == null || criteria(e)));
        }
        public Task<IEnumerable<AuditTrail>> GetByIpAddressAsync(string ip, int? page = null, int pageSize = Constants.MaxPageSize, Func<AuditTrail, bool>? criteria = null) => GetByIpAddressAsync(IPAddress.Parse(ip), page, pageSize, criteria);
        public Task<IEnumerable<AuditTrail>> GetBySessionIdAsync(string id, int? page = null, int pageSize = Constants.MaxPageSize, Func<AuditTrail, bool>? criteria = null)
        {
            if (page.HasValue) return GetAsync((e) => e.SessionId == id && (criteria == null || criteria(e)), page.Value, pageSize);
            return GetAsync((e) => e.SessionId == id && (criteria == null || criteria(e)));
        }
        public Task<IEnumerable<AuditTrail>> GetByUserIdAsync(Guid id, int? page = null, int pageSize = Constants.MaxPageSize, Func<AuditTrail, bool>? criteria = null)
        {
            if (page.HasValue) return GetAsync((e) => e.UserId == id && (criteria == null || criteria(e)), page.Value, pageSize);
            return GetAsync((e) => e.UserId == id && (criteria == null || criteria(e)));
        }
        public Task<IEnumerable<AuditTrail>> GetByUserIdAsync(string id, int? page = null, int pageSize = Constants.MaxPageSize, Func<AuditTrail, bool>? criteria = null) => GetByUserIdAsync(Guid.Parse(id), page, pageSize, criteria);
    }
}
