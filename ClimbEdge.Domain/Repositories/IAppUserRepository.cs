using ClimbEdge.Common.Constants;
using ClimbEdge.Domain.Entities;
using ClimbEdge.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Repositories
{
    public interface IAppUserRepository 
    {
        Task<AppUser> GetByIdAsync(Guid id);
        Task<AppUser> GetByIdAsync(string id);
        Task<IEnumerable<AppUser>> GetByIdsAsync(IEnumerable<Guid> ids);
        Task<IEnumerable<AppUser>> GetByIdsAsync(IEnumerable<string> ids);
        Task<IEnumerable<AppUser>> GetAsync();
        Task<IEnumerable<AppUser>> GetAsync(int page, int pageSize = Constants.MaxPageSize);
        Task<IEnumerable<AppUser>> GetAsync(Func<AppUser, bool> criteria);
        Task<IEnumerable<AppUser>> GetAsync(Func<AppUser, bool> criteria, int page, int pageSize = Constants.MaxPageSize);
        Task<bool> ExistsAsync(Guid id);
        Task<bool> ExistsAsync(string id);
        Task AddAsync(AppUser entity);
        Task UpdateAsync(AppUser entity);
        Task DeleteAsync(Guid id);
        Task DeleteAsync(string id);
        Task RestoreAsync(Guid id);
        Task RestoreAsync(string id);
        Task LockAsync(Guid id, bool isLocked);
        Task LockAsync(string id, bool isLocked);
        Task<int> CountAsync();
        Task<int> CountAsync(Func<AppUser, bool> criteria);
        Task<int> PagesNumberAsync(int pageSize = Constants.MaxPageSize);
        Task<int> PagesNumberAsync(Func<AppUser, bool> criteria, int pageSize = Constants.MaxPageSize);
        Task SaveChangesAsync();
    }
}
