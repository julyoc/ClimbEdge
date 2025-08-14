using ClimbEdge.Common.Constants;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Exceptions;
using ClimbEdge.Domain.Interfaces;
using ClimbEdge.Domain.Shared;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Repositories
{
    public abstract class Repository<TEntity>(ClimbEdgeContext climbEdgeContext, ICacheService cacheService, bool activeCache = true) : IRepository<TEntity> where TEntity : BaseModel
    {
        protected readonly ClimbEdgeContext _climbEdgeContext = climbEdgeContext ?? throw new ArgumentNullException(nameof(climbEdgeContext));
        protected readonly ICacheService _cacheService = cacheService ?? throw new ArgumentNullException(nameof(climbEdgeContext));
        protected async Task InvalidateCache()
        {
            await _cacheService.RemoveByPrefixAsync($"{typeof(TEntity).Name}_");
        }
        public async Task AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _climbEdgeContext.Set<TEntity>().AddAsync(entity);
            await _climbEdgeContext.SaveChangesAsync();
            if (activeCache)
            {
                await InvalidateCache();
                await _cacheService.SetAsync($"{typeof(TEntity).Name}_{entity.Uid}", entity);
            }
        }
        public async Task<int> CountAsync()
        {
            int? count = null;
            if (activeCache) count = await _cacheService.GetAsync<int?>($"{typeof(TEntity).Name}_Count");
            if (count != null) return count.Value;
            count = await _climbEdgeContext.Set<TEntity>().AsNoTracking().CountAsync();
            if (activeCache) await _cacheService.SetAsync($"{typeof(TEntity).Name}_Count", count);
            return (int)count;
        }
        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> criteria)
        {
            int? count = null;
            if (activeCache) count = await _cacheService.GetAsync<int?>($"{typeof(TEntity).Name}_Count_Criteria");
            if (count != null) return count.Value;
            count = _climbEdgeContext.Set<TEntity>().AsNoTracking().Count(criteria);
            if (activeCache) await _cacheService.SetAsync($"{typeof(TEntity).Name}_Count_Criteria", count);
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
            if (activeCache)
            {
                await InvalidateCache();
                await _cacheService.SetAsync($"{typeof(TEntity).Name}_{entity.Uid}", entity);
            }
        }
        public async Task DeleteAsync(string id) => await DeleteAsync(Guid.Parse(id));
        public async Task<bool> ExistsAsync(Guid id)
        {
            bool? entity = null;
            if (activeCache) entity = await _cacheService.GetAsync<bool?>($"{typeof(TEntity).Name}_{id}_Exists");
            if (entity != null) return entity.Value;
            entity = await _climbEdgeContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(e => e.Uid == id) != null;
            if (activeCache) await _cacheService.SetAsync($"{typeof(TEntity).Name}_{id}_Exists", entity);
            return entity.Value;
        }
        public async Task<bool> ExistsAsync(string id) => await ExistsAsync(Guid.Parse(id));
        public async Task<IEnumerable<TEntity>> GetAsync(int? page = null, Expression<Func<TEntity, bool>>? criteria = null, IEnumerable<OrderSelectors>? orderSelectors = null, int pageSize = 100)
        {
            var orderFirst = orderSelectors!.FirstOrDefault();
            var cachekey = null as string;
            var query = null as IOrderedQueryable<TEntity>;
            if (page == null && criteria == null && orderSelectors == null)
            {
                return await _climbEdgeContext.Set<TEntity>().AsNoTracking().ToArrayAsync();
            }
            IEnumerable<TEntity>? entities = null;
            if (page == null && criteria != null && orderSelectors == null)
            {
                if (activeCache) entities = await _cacheService.GetAsync<IEnumerable<TEntity>>($"{typeof(TEntity).Name}_Criteria_{CriteriaCacheKey.For(criteria)}");
                if (entities != null) return entities;
                entities = _climbEdgeContext.Set<TEntity>().AsNoTracking().Where(criteria).ToArray();
                if (activeCache) await _cacheService.SetAsync($"{typeof(TEntity).Name}_Criteria_{CriteriaCacheKey.For(criteria)}", entities);
                return entities;
            }
            if (page != null && criteria == null && orderSelectors == null)
            {
                if (page < 1 || pageSize < 1 || pageSize > Constants.MaxPageSize)
                {
                    throw new ArgumentOutOfRangeException("Page and pageSize must be greater than 0.");
                }
                if (activeCache) entities = await _cacheService.GetAsync<IEnumerable<TEntity>>($"{typeof(TEntity).Name}_Page_{page}_Size_{pageSize}");
                if (entities != null) return entities;
                entities = await _climbEdgeContext.Set<TEntity>().AsNoTracking()
                    .Skip((page.Value - 1) * pageSize)
                    .Take(pageSize)
                    .ToArrayAsync();
                if (activeCache) await _cacheService.SetAsync($"{typeof(TEntity).Name}_Page_{page}_Size_{pageSize}", entities);
                return entities;
            }
            if (page != null && criteria != null && orderSelectors == null)
            {
                if (page < 1 || pageSize < 1 || pageSize > Constants.MaxPageSize)
                {
                    throw new ArgumentOutOfRangeException("Page and pageSize must be greater than 0.");
                }
                if (activeCache) entities = await _cacheService.GetAsync<IEnumerable<TEntity>>($"{typeof(TEntity).Name}_Criteria_{CriteriaCacheKey.For(criteria)}_Page_{page}_Size_{pageSize}");
                if (entities != null) return entities;
                entities = _climbEdgeContext.Set<TEntity>().AsNoTracking()
                    .Where(criteria)
                    .Skip((page.Value - 1) * pageSize)
                    .Take(pageSize)
                    .ToArray();
                if (activeCache) await _cacheService.SetAsync($"{typeof(TEntity).Name}_Criteria_{CriteriaCacheKey.For(criteria)}_Page_{page}_Size_{pageSize}", entities);
                return entities;
            }
            if (page == null && criteria == null && orderSelectors != null)
            {
                cachekey = null as string;
                query = null as IOrderedQueryable<TEntity>;
                if (orderFirst!.orderDesc)
                {
                    cachekey = $"{typeof(TEntity).Name}_order_{orderFirst.OrderKeySelector}_desc";
                    foreach (var orderSelector in orderSelectors!.Skip(1))
                    {
                        if (orderSelector.orderDesc) cachekey += $"_{orderSelector.OrderKeySelector}_desc";
                        else cachekey += $"_{orderSelector.OrderKeySelector}";
                    }
                    if (activeCache) entities = await _cacheService.GetAsync<IEnumerable<TEntity>>(cachekey);
                    if (entities != null) return entities;
                    query = _climbEdgeContext.Set<TEntity>().AsNoTracking()
                        .OrderBy(orderFirst.OrderKeySelector + " desc");
                    foreach (var orderSelector in orderSelectors!.Skip(1))
                    {
                        if (orderSelector.orderDesc) query = query.ThenBy(orderSelector.OrderKeySelector + " desc");
                        else query = query.ThenBy(orderSelector.OrderKeySelector);
                    }
                    entities = await query.ToArrayAsync();
                    if (activeCache) await _cacheService.SetAsync(cachekey, entities);
                    return entities;
                }
                cachekey = $"{typeof(TEntity).Name}_order_{orderFirst.OrderKeySelector}";
                foreach (var orderSelector in orderSelectors!.Skip(1))
                {
                    if (orderSelector.orderDesc) cachekey += $"_{orderSelector.OrderKeySelector}_desc";
                    else cachekey += $"_{orderSelector.OrderKeySelector}";
                }
                if (activeCache) entities = await _cacheService.GetAsync<IEnumerable<TEntity>>(cachekey);
                if (entities != null) return entities;
                query = _climbEdgeContext.Set<TEntity>().AsNoTracking()
                    .OrderBy(orderFirst.OrderKeySelector);
                foreach (var orderSelector in orderSelectors!.Skip(1))
                {
                    if (orderSelector.orderDesc) query = query.ThenBy(orderSelector.OrderKeySelector + " desc");
                    else query = query.ThenBy(orderSelector.OrderKeySelector);
                }
                entities = await query.ToArrayAsync();
                if (activeCache) await _cacheService.SetAsync(cachekey, entities);
                return entities;
            }
            if (page == null && criteria != null && orderSelectors != null)
            {
                cachekey = null as string;
                query = null as IOrderedQueryable<TEntity>;
                if (orderFirst!.orderDesc)
                {
                    cachekey = $"{typeof(TEntity).Name}_Criteria_{CriteriaCacheKey.For(criteria)}_order_{orderFirst.OrderKeySelector}_desc";
                    foreach (var orderSelector in orderSelectors!.Skip(1))
                    {
                        if (orderSelector.orderDesc) cachekey += $"_{orderSelector.OrderKeySelector}_desc";
                        else cachekey += $"_{orderSelector.OrderKeySelector}";
                    }
                    if (activeCache) entities = await _cacheService.GetAsync<IEnumerable<TEntity>>(cachekey);
                    if (entities != null) return entities;
                    query = _climbEdgeContext.Set<TEntity>().AsNoTracking()
                        .Where(criteria)
                        .OrderBy(orderFirst.OrderKeySelector + " desc");
                    foreach (var orderSelector in orderSelectors!.Skip(1))
                    {
                        if (orderSelector.orderDesc) query = query.ThenBy(orderSelector.OrderKeySelector + " desc");
                        else query = query.ThenBy(orderSelector.OrderKeySelector);
                    }
                    entities = await query.ToArrayAsync();
                    if (activeCache) await _cacheService.SetAsync(cachekey, entities);
                    return entities;
                }
                cachekey = $"{typeof(TEntity).Name}_Criteria_{CriteriaCacheKey.For(criteria)}_order_{orderFirst.OrderKeySelector}";
                foreach (var orderSelector in orderSelectors!.Skip(1))
                {
                    if (orderSelector.orderDesc) cachekey += $"_{orderSelector.OrderKeySelector}_desc";
                    else cachekey += $"_{orderSelector.OrderKeySelector}";
                }
                if (activeCache) entities = await _cacheService.GetAsync<IEnumerable<TEntity>>(cachekey);
                if (entities != null) return entities;
                query = _climbEdgeContext.Set<TEntity>().AsNoTracking()
                    .Where(criteria)
                    .OrderBy(orderFirst.OrderKeySelector);
                foreach (var orderSelector in orderSelectors!.Skip(1))
                {
                    if (orderSelector.orderDesc) query = query.ThenBy(orderSelector.OrderKeySelector + " desc");
                    else query = query.ThenBy(orderSelector.OrderKeySelector);
                }
                entities = await query.ToArrayAsync();
                if (activeCache) await _cacheService.SetAsync(cachekey, entities);
                return entities;
            }
            if (page != null && criteria == null && orderSelectors != null)
            {
                if (page < 1 || pageSize < 1 || pageSize > Constants.MaxPageSize)
                {
                    throw new ArgumentOutOfRangeException("Page and pageSize must be greater than 0.");
                }
                cachekey = null as string;
                query = null as IOrderedQueryable<TEntity>;
                if (orderFirst!.orderDesc)
                {
                    cachekey = $"{typeof(TEntity).Name}_Page_{page}_Size_{pageSize}_order_{orderFirst.OrderKeySelector}_desc";
                    foreach (var orderSelector in orderSelectors!.Skip(1))
                    {
                        if (orderSelector.orderDesc) cachekey += $"_{orderSelector.OrderKeySelector}_desc";
                        else cachekey += $"_{orderSelector.OrderKeySelector}";
                    }
                    if (activeCache) entities = await _cacheService.GetAsync<IEnumerable<TEntity>>(cachekey);
                    if (entities != null) return entities;
                    query = _climbEdgeContext.Set<TEntity>().AsNoTracking()
                        .OrderBy(orderFirst.OrderKeySelector + " desc");
                    foreach (var orderSelector in orderSelectors!.Skip(1))
                    {
                        if (orderSelector.orderDesc) query = query.ThenBy(orderSelector.OrderKeySelector + " desc");
                        else query = query.ThenBy(orderSelector.OrderKeySelector);
                    }
                    entities = await query.Skip((page!.Value - 1) * pageSize)
                        .Take(pageSize).ToArrayAsync();
                    if (activeCache) await _cacheService.SetAsync(cachekey, entities);
                    return entities;
                }
                cachekey = $"{typeof(TEntity).Name}_Page_{page}_Size_{pageSize}_order_{orderFirst.OrderKeySelector}";
                foreach (var orderSelector in orderSelectors!.Skip(1))
                {
                    if (orderSelector.orderDesc) cachekey += $"_{orderSelector.OrderKeySelector}_desc";
                    else cachekey += $"_{orderSelector.OrderKeySelector}";
                }
                if (activeCache) entities = await _cacheService.GetAsync<IEnumerable<TEntity>>(cachekey);
                if (entities != null) return entities;
                query = _climbEdgeContext.Set<TEntity>().AsNoTracking()
                    .OrderBy(orderFirst.OrderKeySelector);
                foreach (var orderSelector in orderSelectors!.Skip(1))
                {
                    if (orderSelector.orderDesc) query = query.ThenBy(orderSelector.OrderKeySelector + " desc");
                    else query = query.ThenBy(orderSelector.OrderKeySelector);
                }
                entities = await query.Skip((page!.Value - 1) * pageSize)
                        .Take(pageSize).ToArrayAsync();
                if (activeCache) await _cacheService.SetAsync(cachekey, entities);
                return entities;
            }
            if (page < 1 || pageSize < 1 || pageSize > Constants.MaxPageSize)
            {
                throw new ArgumentOutOfRangeException("Page and pageSize must be greater than 0.");
            }
            if (orderFirst!.orderDesc)
            {
                cachekey = $"{typeof(TEntity).Name}_Page_{page}_Size_{pageSize}_Criteria_{CriteriaCacheKey.For(criteria!)}_order_{orderFirst.OrderKeySelector}_desc";
                foreach (var orderSelector in orderSelectors!.Skip(1))
                {
                    if (orderSelector.orderDesc) cachekey += $"_{orderSelector.OrderKeySelector}_desc";
                    else cachekey += $"_{orderSelector.OrderKeySelector}";
                }
                if (activeCache) entities = await _cacheService.GetAsync<IEnumerable<TEntity>>(cachekey);
                if (entities != null) return entities;
                query = _climbEdgeContext.Set<TEntity>().AsNoTracking()
                    .Where(criteria!)
                    .OrderBy(orderFirst.OrderKeySelector + " desc");
                foreach (var orderSelector in orderSelectors!.Skip(1))
                {
                    if (orderSelector.orderDesc) query = query.ThenBy(orderSelector.OrderKeySelector + " desc");
                    else query = query.ThenBy(orderSelector.OrderKeySelector);
                }
                entities = await query.Skip((page!.Value - 1) * pageSize)
                    .Take(pageSize).ToArrayAsync();
                if (activeCache) await _cacheService.SetAsync(cachekey, entities);
                return entities;
            }
            cachekey = $"{typeof(TEntity).Name}_Page_{page}_Size_{pageSize}_Criteria_{CriteriaCacheKey.For(criteria!)}_order_{orderFirst.OrderKeySelector}";
            foreach (var orderSelector in orderSelectors!.Skip(1))
            {
                if (orderSelector.orderDesc) cachekey += $"_{orderSelector.OrderKeySelector}_desc";
                else cachekey += $"_{orderSelector.OrderKeySelector}";
            }
            if (activeCache) entities = await _cacheService.GetAsync<IEnumerable<TEntity>>(cachekey);
            if (entities != null) return entities;
            query = _climbEdgeContext.Set<TEntity>().AsNoTracking()
                .Where(criteria!)
                .OrderBy(orderFirst.OrderKeySelector);
            foreach (var orderSelector in orderSelectors!.Skip(1))
            {
                if (orderSelector.orderDesc) query = query.ThenBy(orderSelector.OrderKeySelector + " desc");
                else query = query.ThenBy(orderSelector.OrderKeySelector);
            }
            entities = await query.Skip((page!.Value - 1) * pageSize)
                    .Take(pageSize).ToArrayAsync();
            if (activeCache) await _cacheService.SetAsync(cachekey, entities);
            return entities;
        }
        public async Task<TEntity> GetAsync(Guid id)
        {
            TEntity? entity = null;
            if (activeCache) entity = await _cacheService.GetAsync<TEntity>($"{typeof(TEntity).Name}_{id}");
            if (entity != null) return entity;
            entity = await _climbEdgeContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(e => e.Uid == id);
            if (activeCache) await _cacheService.SetAsync($"{typeof(TEntity).Name}_{id}", entity);
            return entity!;
        }
        public Task<TEntity> GetAsync(string id) => GetAsync(Guid.Parse(id));
        public async Task<IEnumerable<TEntity>> GetAsync(IEnumerable<Guid> ids, IEnumerable<OrderSelectors>? orderSelectors = null)
        {
            IEnumerable<TEntity>? entities = null;
            if (orderSelectors != null && orderSelectors!.Any())
            {
                var orderFirst = orderSelectors!.FirstOrDefault();
                var cachekey = null as string;
                var query = null as IOrderedQueryable<TEntity>;
                if (orderFirst!.orderDesc)
                {
                    cachekey = $"{typeof(TEntity).Name}_Ids_{string.Join("_", ids)}_order_{orderFirst.OrderKeySelector}_desc";
                    foreach (var orderSelector in orderSelectors!.Skip(1))
                    {
                        if (orderSelector.orderDesc) cachekey += $"_{orderSelector.OrderKeySelector}_desc";
                        else cachekey += $"_{orderSelector.OrderKeySelector}";
                    }
                    if (activeCache) entities = await _cacheService.GetAsync<IEnumerable<TEntity>>(cachekey);
                    if (entities != null) return entities;
                    query = _climbEdgeContext.Set<TEntity>().AsNoTracking()
                        .Where(e => ids.Contains(e.Uid))
                        .OrderBy(orderFirst.OrderKeySelector + " desc");
                    foreach (var orderSelector in orderSelectors!.Skip(1))
                    {
                        if (orderSelector.orderDesc) query = query.ThenBy(orderSelector.OrderKeySelector + " desc");
                        else query = query.ThenBy(orderSelector.OrderKeySelector);
                    }
                    entities = await query.ToArrayAsync();
                    if (activeCache) await _cacheService.SetAsync(cachekey, entities);
                    return entities;
                }
                cachekey = $"{typeof(TEntity).Name}_Ids_{string.Join("_", ids)}_order_{orderFirst.OrderKeySelector}";
                foreach (var orderSelector in orderSelectors!.Skip(1))
                {
                    if (orderSelector.orderDesc) cachekey += $"_{orderSelector.OrderKeySelector}_desc";
                    else cachekey += $"_{orderSelector.OrderKeySelector}";
                }
                if (activeCache) entities = await _cacheService.GetAsync<IEnumerable<TEntity>>(cachekey);
                if (entities != null) return entities;
                query = _climbEdgeContext.Set<TEntity>().AsNoTracking()
                    .Where(e => ids.Contains(e.Uid))
                    .OrderBy(orderFirst.OrderKeySelector);
                foreach (var orderSelector in orderSelectors!.Skip(1))
                {
                    if (orderSelector.orderDesc) query = query.ThenBy(orderSelector.OrderKeySelector + " desc");
                    else query = query.ThenBy(orderSelector.OrderKeySelector);
                }
                entities = await query.ToArrayAsync();
                if (activeCache) await _cacheService.SetAsync(cachekey, entities);
                return entities;
            }
            if (activeCache) entities = await _cacheService.GetAsync<IEnumerable<TEntity>>($"{typeof(TEntity).Name}_Ids_{string.Join("_", ids)}");
            if (entities != null) return entities;
            entities = await _climbEdgeContext.Set<TEntity>().AsNoTracking()
                .Where(e => ids.Contains(e.Uid))
                .ToArrayAsync();
            if (activeCache) await _cacheService.SetAsync($"{typeof(TEntity).Name}_Ids_{string.Join("_", ids)}", entities);
            return entities;
        }
        public async Task<IEnumerable<TEntity>> GetAsync(IEnumerable<string> ids, IEnumerable<OrderSelectors>? orderSelectors = null)
        {
            var guids = ids.Select(id => Guid.Parse(id));
            var entities = await GetAsync(guids, orderSelectors);
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
            if (activeCache) await InvalidateCache();
            await _climbEdgeContext.SaveChangesAsync();
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
        public async Task<int> PagesNumberAsync(Expression<Func<TEntity, bool>> criteria, int pageSize = Constants.DefaultPageSize)
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
            if (activeCache) await InvalidateCache();
            await _climbEdgeContext.SaveChangesAsync();
            if (activeCache) await _cacheService.SetAsync($"{typeof(TEntity).Name}_{entity.Uid}", entity);
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
            if (activeCache) await InvalidateCache();
            await _climbEdgeContext.SaveChangesAsync();
            if (activeCache) await _cacheService.SetAsync($"{typeof(TEntity).Name}_{entity.Uid}", entity);
        }
    }
}
