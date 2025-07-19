using ClimbEdge.Common.Constants;
using ClimbEdge.Domain.Exceptions;
using ClimbEdge.Domain.Interfaces;
using ClimbEdge.Domain.Shared;
using ClimbEdge.Infrastructure.Caching;
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
    public abstract class Repository<TEntity>(ClimbEdgeContext climbEdgeContext, ICacheService cacheService) : IRepository<TEntity> where TEntity : BaseModel
    {
        protected readonly ClimbEdgeContext _climbEdgeContext = climbEdgeContext ?? throw new ArgumentNullException(nameof(climbEdgeContext));
        protected readonly ICacheService _cacheService = cacheService ?? throw new ArgumentNullException(nameof(climbEdgeContext));
        protected async Task InvalidateCache()
        {
            await _cacheService.RemoveByPrefixAsync($"{nameof(TEntity)}_");
        }
        public async Task AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _climbEdgeContext.Set<TEntity>().AddAsync(entity);
            await _climbEdgeContext.SaveChangesAsync();
            await InvalidateCache();
            await _cacheService.SetAsync($"{nameof(TEntity)}_{entity.Uid}", entity);
        }
        public async Task<int> CountAsync()
        {
            int? count = await _cacheService.GetAsync<int?>($"{nameof(TEntity)}_Count");
            if (count != null) return count.Value;
            count = await _climbEdgeContext.Set<TEntity>().CountAsync();
            await _cacheService.SetAsync($"{nameof(TEntity)}_Count", count);
            return (int)count;
        }
        public async Task<int> CountAsync(Func<TEntity, bool> criteria)
        {
            int? count = await _cacheService.GetAsync<int?>($"{nameof(TEntity)}_Count_Criteria");
            if (count != null) return count.Value;
            count = _climbEdgeContext.Set<TEntity>().Count(criteria);
            await _cacheService.SetAsync($"{nameof(TEntity)}_Count_Criteria", count);
            return (int)count;
        }
        public async Task DeleteAsync(Guid id)
        {
            var entity = await _climbEdgeContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Uid == id);
            if (entity == null)
            {
                throw new EntityNotFoundException(nameof(entity), id.ToString());
            }
            entity.MarkAsDeleted();
            _climbEdgeContext.Set<TEntity>().Update(entity);
            await _climbEdgeContext.SaveChangesAsync();
            await InvalidateCache();
            await _cacheService.SetAsync($"{nameof(TEntity)}_{entity.Uid}", entity);
        }
        public async Task DeleteAsync(string id) => await DeleteAsync(Guid.Parse(id));
        public async Task<bool> ExistsAsync(Guid id)
        {
            var cachedEntity = await _cacheService.GetAsync<bool?>($"{nameof(TEntity)}_{id}_Exists");
            if (cachedEntity != null) return cachedEntity.Value;
            var entity = await _climbEdgeContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Uid == id);
            await _cacheService.SetAsync($"{nameof(TEntity)}_{id}_Exists", entity != null);
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
            var cachedEntities = await _cacheService.GetAsync<IEnumerable<TEntity>>($"{nameof(TEntity)}_Page_{page}_Size_{pageSize}");
            if (cachedEntities != null) return cachedEntities;
            var entities = await _climbEdgeContext.Set<TEntity>()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToArrayAsync();
            await _cacheService.SetAsync($"{nameof(TEntity)}_Page_{page}_Size_{pageSize}", entities);
            return entities;
        }
        public async Task<IEnumerable<TEntity>> GetAsync(Func<TEntity, bool> criteria)
        {
            var cachedEntities = await _cacheService.GetAsync<IEnumerable<TEntity>>($"{nameof(TEntity)}_Criteria_{criteria.GetHashCode()}");
            if (cachedEntities != null) return cachedEntities;
            var data = (IEnumerable<TEntity>)_climbEdgeContext.Set<TEntity>().Where(criteria).ToArray();
            if (data == null || !data.Any())
            {
                throw new EntityNotFoundException(nameof(data), "");
            }
            await _cacheService.SetAsync($"{nameof(TEntity)}_Criteria_{criteria.GetHashCode()}", data);
            return data;
        }
        public async Task<IEnumerable<TEntity>> GetAsync(Func<TEntity, bool> criteria, int page, int pageSize = Constants.DefaultPageSize)
        {
            if (page < 1 || pageSize < 1 || pageSize > Constants.MaxPageSize)
            {
                throw new ArgumentOutOfRangeException("Page and pageSize must be greater than 0.");
            }
            var cachedEntities = await _cacheService.GetAsync<IEnumerable<TEntity>>($"{nameof(TEntity)}_Criteria_{criteria.GetHashCode()}_Page_{page}_Size_{pageSize}");
            if (cachedEntities != null) return cachedEntities;
            var data = (IEnumerable<TEntity>)_climbEdgeContext.Set<TEntity>().Where(criteria)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToArray();
            if (data == null || !data.Any())
            {
                throw new EntityNotFoundException(nameof(data), "");
            }
            await _cacheService.SetAsync($"{nameof(TEntity)}_Criteria_{criteria.GetHashCode()}_Page_{page}_Size_{pageSize}", data);
            return data;
        }
        public async Task<TEntity> GetAsync(Guid id)
        {
            var cachedEntity = await _cacheService.GetAsync<TEntity>($"{nameof(TEntity)}_{id}");
            if (cachedEntity != null) return cachedEntity;
            var entity = await _climbEdgeContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Uid == id);
            if (entity == null)
            {
                throw new EntityNotFoundException(nameof(entity), id.ToString());
            }
            await _cacheService.SetAsync($"{nameof(TEntity)}_{id}", entity);
            return entity;
        }
        public Task<TEntity> GetAsync(string id) => GetAsync(Guid.Parse(id));
        public async Task<IEnumerable<TEntity>> GetAsync(IEnumerable<Guid> ids)
        {
            var cachedEntities = await _cacheService.GetAsync<IEnumerable<TEntity>>($"{nameof(TEntity)}_Ids_{string.Join("_", ids)}");
            if (cachedEntities != null) return cachedEntities;
            var entities = await _climbEdgeContext.Set<TEntity>()
                .Where(e => ids.Contains(e.Uid))
                .ToArrayAsync();
            if (entities == null || !entities.Any())
            {
                throw new EntityNotFoundException(nameof(entities), string.Join(", ", ids));
            }
            await _cacheService.SetAsync($"{nameof(TEntity)}_Ids_{string.Join("_", ids)}", entities);
            return entities;
        }
        public async Task<IEnumerable<TEntity>> GetAsync(IEnumerable<string> ids)
        {
            var guids = ids.Select(id => Guid.Parse(id));
            var entities = await GetAsync(guids);
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
            await InvalidateCache();
            await _climbEdgeContext.SaveChangesAsync();
            await _cacheService.SetAsync($"{nameof(TEntity)}_{entity.Uid}", entity);
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
            await InvalidateCache();
            await _climbEdgeContext.SaveChangesAsync();
            await _cacheService.SetAsync($"{nameof(TEntity)}_{entity.Uid}", entity);
        }
        public Task RestoreAsync(string id) => RestoreAsync(Guid.Parse(id));
        public async Task SaveChangesAsync()
        {
            await _climbEdgeContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (entity.IsLocked)
            {
                throw new EntityLockedException(nameof(entity), entity.Uid.ToString());
            }
            _climbEdgeContext.Set<TEntity>().Update(entity);
            await InvalidateCache();
            await _climbEdgeContext.SaveChangesAsync();
            await _cacheService.SetAsync($"{nameof(TEntity)}_{entity.Uid}", entity);
        }
    }
}
