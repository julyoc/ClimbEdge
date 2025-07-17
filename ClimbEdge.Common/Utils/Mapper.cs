using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Common.Utils
{
    public class Mapper
    {
        /// <summary>
        /// Mapea un objeto de tipo TSource a un objeto de tipo TDestination.
        /// </summary>
        /// <typeparam name="TSource">Tipo del objeto fuente.</typeparam>
        /// <typeparam name="TDestination">Tipo del objeto destino.</typeparam>
        /// <param name="source">Objeto fuente a mapear.</param>
        /// <returns>Un nuevo objeto de tipo TDestination con los valores mapeados desde el objeto fuente.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        public static TDestination Map<TSource, TDestination>(TSource source)
            where TDestination : new()
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "El objeto fuente no puede ser nulo.");
            }
            var destination = new TDestination();
            var sourceProperties = typeof(TSource).GetProperties();
            var destinationProperties = typeof(TDestination).GetProperties();
            foreach (var sourceProperty in sourceProperties)
            {
                var destinationProperty = destinationProperties.FirstOrDefault(p => p.Name == sourceProperty.Name && p.PropertyType == sourceProperty.PropertyType);
                if (destinationProperty != null && destinationProperty.CanWrite)
                {
                    destinationProperty.SetValue(destination, sourceProperty.GetValue(source));
                }
            }
            return destination;
        }
        /// <summary>
        /// Copies property values from the source object to the destination object where properties have matching names
        /// and types.
        /// </summary>
        /// <remarks>Only properties with matching names and types in both the source and destination
        /// objects are copied. The destination properties must be writable.</remarks>
        /// <typeparam name="TSource">The type of the source object.</typeparam>
        /// <typeparam name="TDestination">The type of the destination object.</typeparam>
        /// <param name="source">The source object from which property values are copied. Cannot be <see langword="null"/>.</param>
        /// <param name="destination">The destination object to which property values are copied. Cannot be <see langword="null"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="destination"/> is <see langword="null"/>.</exception>
        public static void MapUpdate<TSource, TDestination>(TSource source, TDestination destination)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

            var sourceProperties = typeof(TSource).GetProperties();
            var destinationProperties = typeof(TDestination).GetProperties();

            foreach (var sourceProp in sourceProperties)
            {
                var destProp = destinationProperties.FirstOrDefault(p => p.Name == sourceProp.Name && p.PropertyType == sourceProp.PropertyType);
                if (destProp != null && destProp.CanWrite)
                {
                    destProp.SetValue(destination, sourceProp.GetValue(source));
                }
            }
        }
    }
}
