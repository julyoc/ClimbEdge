using ClimbEdge.Common.Constants;
using ClimbEdge.Domain.Entities;
using ClimbEdge.Domain.Exceptions;
using ClimbEdge.Domain.Interfaces;
using ClimbEdge.Domain.Repositories;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Repositories
{
    public class AppUserRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService) : IAppUserRepository
    {
        private readonly ClimbEdgeContext _climbEdgeContext = climbEdgeContext ?? throw new ArgumentNullException(nameof(climbEdgeContext));
        private readonly ICacheService _cacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));

        public async Task AddAsync(AppUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _climbEdgeContext.Set<AppUser>().AddAsync(entity);
        }

        public async Task<int> CountAsync() => await _climbEdgeContext.Set<AppUser>().CountAsync();

        public Task<int> CountAsync(Func<AppUser, bool> criteria) => Task.FromResult(_climbEdgeContext.Set<AppUser>().Count(criteria));

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _climbEdgeContext.Set<AppUser>().FirstOrDefaultAsync(e => e.Uid == id);
            if (entity == null)
            {
                throw new EntityNotFoundException(nameof(entity), id.ToString());
            }
            entity.MarkAsDeleted();
            _climbEdgeContext.Set<AppUser>().Update(entity);
        }

        public async Task DeleteAsync(string id) => await DeleteAsync(Guid.Parse(id));

        public async Task<bool> ExistsAsync(Guid id)
        {
            var entity = await _climbEdgeContext.Set<AppUser>().FirstOrDefaultAsync(e => e.Uid == id);
            return entity != null;
        }

        public async Task<bool> ExistsAsync(string id) => await ExistsAsync(Guid.Parse(id));

        public async Task<IEnumerable<AppUser>> GetAsync() => await _climbEdgeContext.Set<AppUser>().ToArrayAsync();

        public async Task<IEnumerable<AppUser>> GetAsync(int page, int pageSize = Constants.DefaultPageSize)
        {
            if (page < 1 || pageSize < 1 || pageSize > Constants.MaxPageSize)
            {
                throw new ArgumentOutOfRangeException("Page and pageSize must be greater than 0.");
            }
            return await _climbEdgeContext.Set<AppUser>()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToArrayAsync();
        }

        public Task<IEnumerable<AppUser>> GetAsync(Func<AppUser, bool> criteria)
        {
            var data = (IEnumerable<AppUser>)_climbEdgeContext.Set<AppUser>().Where(criteria).ToArray();
            if (data == null || !data.Any())
            {
                throw new EntityNotFoundException(nameof(data), "");
            }
            return Task.FromResult(data);
        }

        public Task<IEnumerable<AppUser>> GetAsync(Func<AppUser, bool> criteria, int page, int pageSize = Constants.DefaultPageSize)
        {
            if (page < 1 || pageSize < 1 || pageSize > Constants.MaxPageSize)
            {
                throw new ArgumentOutOfRangeException("Page and pageSize must be greater than 0.");
            }
            var data = (IEnumerable<AppUser>)_climbEdgeContext.Set<AppUser>().Where(criteria)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToArray();
            if (data == null || !data.Any())
            {
                throw new EntityNotFoundException(nameof(data), "");
            }
            return Task.FromResult(data);
        }

        public async Task<AppUser> GetByIdAsync(Guid id)
        {
            var entity = await _climbEdgeContext.Set<AppUser>().FirstOrDefaultAsync(e => e.Uid == id);
            if (entity == null)
            {
                throw new EntityNotFoundException(nameof(entity), id.ToString());
            }
            return entity;
        }

        public Task<AppUser> GetByIdAsync(string id) => GetByIdAsync(Guid.Parse(id));

        public async Task<IEnumerable<AppUser>> GetByIdsAsync(IEnumerable<Guid> ids)
        {
            var entities = await _climbEdgeContext.Set<AppUser>()
                .Where(e => ids.Contains(e.Uid))
                .ToArrayAsync();
            if (entities == null || !entities.Any())
            {
                throw new EntityNotFoundException(nameof(entities), string.Join(", ", ids));
            }
            return entities;
        }

        public async Task<IEnumerable<AppUser>> GetByIdsAsync(IEnumerable<string> ids)
        {
            var guids = ids.Select(id => Guid.Parse(id));
            var entities = await GetByIdsAsync(guids);
            return entities;
        }

        public async Task LockAsync(Guid id, bool isLocked)
        {
            var entity = await _climbEdgeContext.Set<AppUser>().FirstOrDefaultAsync(e => e.Uid == id);
            if (entity == null)
            {
                throw new EntityNotFoundException(nameof(entity), id.ToString());
            }
            if (isLocked)
            {
                entity.Lock();
            }
            else
            {
                entity.Unlock();
            }
            _climbEdgeContext.Set<AppUser>().Update(entity);
        }

        public Task LockAsync(string id, bool isLocked) => LockAsync(Guid.Parse(id), isLocked);

        public async Task<int> PagesNumberAsync(int pageSize = Constants.DefaultPageSize)
        {
            if (pageSize > Constants.MaxPageSize)
            {
                throw new ArgumentOutOfRangeException("Page and pageSize must be greater than 0.");
            }
            var count = await CountAsync();
            return count / pageSize + (count % pageSize > 0 ? 1 : 0);
        }

        public async Task<int> PagesNumberAsync(Func<AppUser, bool> criteria, int pageSize = Constants.DefaultPageSize)
        {
            if (pageSize > Constants.MaxPageSize)
            {
                throw new ArgumentOutOfRangeException("Page and pageSize must be greater than 0.");
            }
            var count = await CountAsync(criteria);
            return count / pageSize + (count % pageSize > 0 ? 1 : 0);
        }

        public async Task RestoreAsync(Guid id)
        {
            var entity = await _climbEdgeContext.Set<AppUser>().FirstOrDefaultAsync(e => e.Uid == id);
            if (entity == null)
            {
                throw new EntityNotFoundException(nameof(entity), id.ToString());
            }
            entity.MarkAsRestored();
            _climbEdgeContext.Set<AppUser>().Update(entity);
        }

        public Task RestoreAsync(string id) => RestoreAsync(Guid.Parse(id));

        public async Task SaveChangesAsync()
        {
            await _climbEdgeContext.SaveChangesAsync();
        }

        public Task UpdateAsync(AppUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (entity.IsLocked)
            {
                throw new EntityLockedException(nameof(entity), entity.Uid.ToString());
            }
            return Task.Run(() => _climbEdgeContext.Set<AppUser>().Update(entity));
        }
    }
}
