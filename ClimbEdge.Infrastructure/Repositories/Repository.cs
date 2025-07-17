using ClimbEdge.Common.Constants;
using ClimbEdge.Domain.Exceptions;
using ClimbEdge.Domain.Interfaces;
using ClimbEdge.Domain.Shared;
using ClimbEdge.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Repositories
{
    public abstract class Repository<TEntity>(ClimbEdgeContext climbEdgeContext) : IRepository<TEntity> where TEntity : BaseModel
    {
        protected readonly ClimbEdgeContext _climbEdgeContext = climbEdgeContext ?? throw new ArgumentNullException(nameof(climbEdgeContext));

        public async Task AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _climbEdgeContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task<int> CountAsync() => await _climbEdgeContext.Set<TEntity>().CountAsync();

        public Task<int> CountAsync(Func<TEntity, bool> criteria) => Task.FromResult(_climbEdgeContext.Set<TEntity>().Count(criteria));

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _climbEdgeContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Uid == id);
            if (entity == null)
            {
                throw new EntityNotFoundException(nameof(entity), id.ToString());
            }
            entity.MarkAsDeleted();
            _climbEdgeContext.Set<TEntity>().Update(entity);
        }

        public async Task DeleteAsync(string id) => await DeleteAsync(Guid.Parse(id));

        public async Task<bool> ExistsAsync(Guid id)
        {
            var entity = await _climbEdgeContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Uid == id);
            return entity != null;
        }

        public async Task<bool> ExistsAsync(string id) => await ExistsAsync(Guid.Parse(id));

        public async Task<IEnumerable<TEntity>> GetAsync() => await _climbEdgeContext.Set<TEntity>().ToArrayAsync();

        public async Task<IEnumerable<TEntity>> GetAsync(int page, int pageSize = Constants.DefaultPageSize)
        {
            if (page < 1 || pageSize < 1 || pageSize > Constants.MaxPageSize)
            {
                throw new ArgumentOutOfRangeException("Page and pageSize must be greater than 0.");
            }
            return await _climbEdgeContext.Set<TEntity>()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToArrayAsync();
        }

        public Task<IEnumerable<TEntity>> GetAsync(Func<TEntity, bool> criteria)
        {
            var data = (IEnumerable<TEntity>)_climbEdgeContext.Set<TEntity>().Where(criteria).ToArray();
            if (data == null || !data.Any())
            {
                throw new EntityNotFoundException(nameof(data), "");
            }
            return Task.FromResult(data);
        }

        public Task<IEnumerable<TEntity>> GetAsync(Func<TEntity, bool> criteria, int page, int pageSize = Constants.DefaultPageSize)
        {
            if (page < 1 || pageSize < 1 || pageSize > Constants.MaxPageSize)
            {
                throw new ArgumentOutOfRangeException("Page and pageSize must be greater than 0.");
            }
            var data = (IEnumerable<TEntity>)_climbEdgeContext.Set<TEntity>().Where(criteria)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToArray();
            if (data == null || !data.Any())
            {
                throw new EntityNotFoundException(nameof(data), "");
            }
            return Task.FromResult(data);
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            var entity = await _climbEdgeContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Uid == id);
            if (entity == null)
            {
                throw new EntityNotFoundException(nameof(entity), id.ToString());
            }
            return entity;
        }

        public Task<TEntity> GetByIdAsync(string id) => GetByIdAsync(Guid.Parse(id));

        public async Task<IEnumerable<TEntity>> GetByIdsAsync(IEnumerable<Guid> ids)
        {
            var entities = await _climbEdgeContext.Set<TEntity>()
                .Where(e => ids.Contains(e.Uid))
                .ToArrayAsync();
            if (entities == null || !entities.Any())
            {
                throw new EntityNotFoundException(nameof(entities), string.Join(", ", ids));
            }
                return entities;
        }

        public async Task<IEnumerable<TEntity>> GetByIdsAsync(IEnumerable<string> ids)
        {
            var guids = ids.Select(id => Guid.Parse(id));
            var entities = await GetByIdsAsync(guids);
            return entities;
        }

        public async Task LockAsync(Guid id, bool isLocked)
        {
            var entity = await _climbEdgeContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Uid == id);
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
            _climbEdgeContext.Set<TEntity>().Update(entity);
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

        public async Task<int> PagesNumberAsync(Func<TEntity, bool> criteria, int pageSize = Constants.DefaultPageSize)
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
            var entity = await _climbEdgeContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Uid == id);
            if (entity == null)
            {
                throw new EntityNotFoundException(nameof(entity), id.ToString());
            }
            entity.MarkAsRestored();
            _climbEdgeContext.Set<TEntity>().Update(entity);
        }

        public Task RestoreAsync(string id) => RestoreAsync(Guid.Parse(id));

        public async Task SaveChangesAsync()
        {
            await _climbEdgeContext.SaveChangesAsync();
        }

        public Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (entity.IsLocked) 
            {
                throw new EntityLockedException(nameof(entity), entity.Uid.ToString());
            }
            return Task.Run(() => _climbEdgeContext.Set<TEntity>().Update(entity));
        }
    }
}
