using ClimbEdge.Common.Constants;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Auditing;
using ClimbEdge.Domain.Repositories.Auditing;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClimbEdge.Infrastructure.Repositories.Auditing
{
    public class AuditTrailRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService) : Repository<AuditTrail>(climbEdgeContext, cacheService, false), IAuditTrailRepository
    {
        public Task<IEnumerable<AuditTrail>> GetByCorrelationIdAsync(string id, int? page = null, int pageSize = Constants.MaxPageSize, Expression<Func<AuditTrail, bool>>? criteria = null)
        {
            Expression<Func<AuditTrail, bool>> predicate = e => e.CorrelationId == id;
            if (criteria is not null) predicate = predicate.AndAlso(criteria);
            if (page.HasValue) return GetAsync(criteria: predicate, page: page, pageSize: pageSize);
            return GetAsync(criteria: predicate);
        }
        public Task<IEnumerable<AuditTrail>> GetByEntityIdAsync(Guid id, int? page = null, int pageSize = Constants.MaxPageSize, Expression<Func<AuditTrail, bool>>? criteria = null)
        {
            Expression<Func<AuditTrail, bool>> predicate = e => e.EntityId == id;
            if (criteria is not null) predicate = predicate.AndAlso(criteria);
            if (page.HasValue) return GetAsync(criteria: predicate, page: page, pageSize: pageSize);
            return GetAsync(criteria: predicate);
        }
        public Task<IEnumerable<AuditTrail>> GetByEntityIdAsync(string id, int? page = null, int pageSize = Constants.MaxPageSize, Expression<Func<AuditTrail, bool>>? criteria = null) => GetByEntityIdAsync(Guid.Parse(id), page, pageSize, criteria);
        public Task<IEnumerable<AuditTrail>> GetByEntityNameAsync(string name, int? page = null, int pageSize = Constants.MaxPageSize, Expression<Func<AuditTrail, bool>>? criteria = null)
        {
            Expression<Func<AuditTrail, bool>> predicate = e => e.EntityName == name;
            if (criteria is not null) predicate = predicate.AndAlso(criteria);
            if (page.HasValue) return GetAsync(criteria: predicate, page: page, pageSize: pageSize);
            return GetAsync(criteria: predicate);
        }
        public Task<IEnumerable<AuditTrail>> GetByIpAddressAsync(IPAddress ip, int? page = null, int pageSize = Constants.MaxPageSize, Expression<Func<AuditTrail, bool>>? criteria = null)
        {
            Expression<Func<AuditTrail, bool>> predicate = e => e.IpAddress == ip;
            if (criteria is not null) predicate = predicate.AndAlso(criteria);
            if (page.HasValue) return GetAsync(criteria: predicate, page: page, pageSize: pageSize);
            return GetAsync(criteria: predicate);
        }
        public Task<IEnumerable<AuditTrail>> GetByIpAddressAsync(string ip, int? page = null, int pageSize = Constants.MaxPageSize, Expression<Func<AuditTrail, bool>>? criteria = null) => GetByIpAddressAsync(IPAddress.Parse(ip), page, pageSize, criteria);
        public Task<IEnumerable<AuditTrail>> GetBySessionIdAsync(string id, int? page = null, int pageSize = Constants.MaxPageSize, Expression<Func<AuditTrail, bool>>? criteria = null)
        {
            Expression<Func<AuditTrail, bool>> predicate = e => e.SessionId == id;
            if (criteria is not null) predicate = predicate.AndAlso(criteria);
            if (page.HasValue) return GetAsync(criteria: predicate, page: page, pageSize: pageSize);
            return GetAsync(criteria: predicate);
        }
        public Task<IEnumerable<AuditTrail>> GetByUserIdAsync(Guid id, int? page = null, int pageSize = Constants.MaxPageSize, Expression<Func<AuditTrail, bool>>? criteria = null)
        {
            Expression<Func<AuditTrail, bool>> predicate = e => e.UserId == id;
            if (criteria is not null) predicate = predicate.AndAlso(criteria);
            if (page.HasValue) return GetAsync(criteria: predicate, page: page, pageSize: pageSize);
            return GetAsync(criteria: predicate);
        }
        public Task<IEnumerable<AuditTrail>> GetByUserIdAsync(string id, int? page = null, int pageSize = Constants.MaxPageSize, Expression<Func<AuditTrail, bool>>? criteria = null) => GetByUserIdAsync(Guid.Parse(id), page, pageSize, criteria);
    }
}
