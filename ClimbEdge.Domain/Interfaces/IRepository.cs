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
        /// <summary>
        /// Gets an entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <returns>The entity if found; otherwise, null.</returns>
        Task<TEntity> GetAsync(Guid id);
        /// <summary>
        /// Gets an entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <returns>The entity if found; otherwise, null.</returns>
        Task<TEntity> GetAsync(string id);
        /// <summary>
        /// Gets entities by their unique identifiers.
        /// </summary>
        /// <param name="ids">The unique identifiers of the entities.</param>
        /// <param name="orderSelectors">Optional order selectors.</param>
        /// <returns>A collection of entities.</returns>
        Task<IEnumerable<TEntity>> GetAsync(IEnumerable<Guid> ids, IEnumerable<OrderSelectors>? orderSelectors = null);
        /// <summary>
        /// Gets entities by their unique identifiers.
        /// </summary>
        /// <param name="ids">The unique identifiers of the entities.</param>
        /// <param name="orderSelectors">Optional order selectors.</param>
        /// <returns>A collection of entities.</returns>
        Task<IEnumerable<TEntity>> GetAsync(IEnumerable<string> ids, IEnumerable<OrderSelectors>? orderSelectors = null);
        /// <summary>
        /// Gets list of entities.
        /// </summary>
        /// <param name="page">Optional page number.</param>
        /// <param name="criteria">Optional filter criteria.</param>
        /// <param name="orderSelectors">Optional order selectors.</param>
        /// <param name="pageSize">Optional number of items per page.</param>
        /// <returns>A collection of entities.</returns>
        Task<IEnumerable<TEntity>> GetAsync(int? page = null, Expression<Func<TEntity, bool>>? criteria = null, IEnumerable<OrderSelectors>? orderSelectors = null, int pageSize = Constants.MaxPageSize);
        /// <summary>
        /// Checks if an entity exists.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <returns>True if the entity exists; otherwise, false.</returns>
        Task<bool> ExistsAsync(Guid id);
        /// <summary>
        /// Checks if an entity exists.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <returns>True if the entity exists; otherwise, false.</returns>
        Task<bool> ExistsAsync(string id);
        /// <summary>
        /// Adds a new entity.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        Task AddAsync(TEntity entity);
        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        Task UpdateAsync(TEntity entity);
        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        Task DeleteAsync(Guid id);
        /// <param name="id">The unique identifier of the entity.</param>
        Task DeleteAsync(string id);
        /// <summary>
        /// Restores a deleted entity.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        Task RestoreAsync(Guid id);
        /// <summary>
        /// Restores a deleted entity.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <returns></returns>
        Task RestoreAsync(string id);
        /// <summary>
        /// Locks or unlocks an entity.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <param name="isLocked">True to lock the entity; otherwise, false.</param>
        Task LockAsync(Guid id, bool isLocked);
        /// <summary>
        /// Locks or unlocks an entity.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <param name="isLocked">True to lock the entity; otherwise, false.</param>
        Task LockAsync(string id, bool isLocked);
        /// <summary>
        /// Counts the total number of entities.
        /// </summary>
        /// <param name="criteria">Optional filter criteria.</param>
        /// <returns>The total number of entities.</returns>
        Task<int> CountAsync(Expression<Func<TEntity, bool>>? criteria = null);
        /// <summary>
        /// Gets the total number of pages for a given set of criteria.
        /// </summary>
        /// <param name="criteria">Optional filter criteria.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <returns>The total number of pages.</returns>
        Task<int> PagesNumberAsync(Expression<Func<TEntity, bool>>? criteria = null, int pageSize = Constants.MaxPageSize);
        Task SaveChangesAsync();
    }
}
