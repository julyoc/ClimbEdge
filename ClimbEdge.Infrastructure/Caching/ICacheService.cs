using ClimbEdge.Common.Constants;
using ClimbEdge.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Caching
{
    public interface ICacheService
    {
        /// <summary>
        /// Setea un valor en la caché con una clave específica y un tiempo de expiración.
        /// </summary>
        /// <typeparam name="T">Tipo del valor a almacenar en la caché, debe heredar de BaseModel.</typeparam>
        /// <param name="key">Clave única para identificar el valor en la caché.</param>
        /// <param name="value">Valor a almacenar en la caché. Debe ser una instancia de BaseModel o un tipo que herede de BaseModel.</param>
        /// <param name="expiration">Tiempo de expiración en segundos para el valor en la caché.</param>
        /// <returns>Un Task que representa la operación asíncrona.</returns>
        Task SetAsync<T>(string key, T value, int expiration = Constants.CachingExpiration) where T : BaseModel;
        /// <summary>
        /// Obtiene un valor de la caché utilizando una clave específica.
        /// </summary>
        /// <typeparam name="T">Tipo del valor a almacenar en la caché, debe heredar de BaseModel.</typeparam>
        /// <param name="key">Clave única para identificar el valor en la caché.</param>
        /// <returns>Un Task que representa la operación asíncrona. El resultado es el valor almacenado en la caché, o null si no se encuentra.</returns>
        Task<T?> GetAsync<T>(string key) where T : BaseModel;
    }
}
