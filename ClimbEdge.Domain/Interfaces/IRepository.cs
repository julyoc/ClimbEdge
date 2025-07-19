using ClimbEdge.Common.Constants;
using ClimbEdge.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseModel
    {
        Task<TEntity> GetAsync(Guid id);
        Task<TEntity> GetAsync(string id);
        Task<IEnumerable<TEntity>> GetAsync(IEnumerable<Guid> ids);
        Task<IEnumerable<TEntity>> GetAsync(IEnumerable<string> ids);
        Task<IEnumerable<TEntity>> GetAsync();
        Task<IEnumerable<TEntity>> GetAsync(int page, int pageSize = Constants.MaxPageSize);
        Task<IEnumerable<TEntity>> GetAsync(Func<TEntity, bool> criteria);
        Task<IEnumerable<TEntity>> GetAsync(Func<TEntity, bool> criteria, int page, int pageSize = Constants.MaxPageSize);
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
        Task<int> CountAsync(Func<TEntity, bool> criteria);
        Task<int> PagesNumberAsync(int pageSize = Constants.MaxPageSize);
        Task<int> PagesNumberAsync(Func<TEntity, bool> criteria, int pageSize = Constants.MaxPageSize);
        Task SaveChangesAsync();
    }
}
