using ClimbEdge.Common.Constants;
using ClimbEdge.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Interfaces
{
    public record OrderSelectors(string OrderKeySelector, bool orderDesc = false);
    public interface IRepository<TEntity> where TEntity : BaseModel
    {
        Task<TEntity> GetAsync(Guid id);
        Task<TEntity> GetAsync(string id);
        Task<IEnumerable<TEntity>> GetAsync(IEnumerable<Guid> ids, IEnumerable<OrderSelectors>? orderSelectors = null);
        Task<IEnumerable<TEntity>> GetAsync(IEnumerable<string> ids, IEnumerable<OrderSelectors>? orderSelectors = null);
        Task<IEnumerable<TEntity>> GetAsync(int? page = null, Expression<Func<TEntity, bool>>? criteria = null, IEnumerable<OrderSelectors>? orderSelectors = null, int pageSize = Constants.MaxPageSize);
        Task<bool> ExistsAsync(Guid id);
        Task<bool> ExistsAsync(string id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Guid id);
        Task DeleteAsync(string id);
        Task RestoreAsync(Guid id);
        Task RestoreAsync(string id);
        Task LockAsync(Guid id, bool isLocked);
        Task LockAsync(string id, bool isLocked);
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<TEntity, bool>> criteria);
        Task<int> PagesNumberAsync(int pageSize = Constants.MaxPageSize);
        Task<int> PagesNumberAsync(Expression<Func<TEntity, bool>> criteria, int pageSize = Constants.MaxPageSize);
        Task SaveChangesAsync();
    }
}
