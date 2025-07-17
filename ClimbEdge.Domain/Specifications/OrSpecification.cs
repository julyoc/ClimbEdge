using ClimbEdge.Domain.Interfaces;
using ClimbEdge.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Specifications
{
    public class OrSpecification<T> : ISpecification<T> where T : BaseModel
    {
        private readonly IEnumerable<ISpecification<T>> _spec;
        public OrSpecification(params ISpecification<T>[] spec)
        {
            _spec = spec ?? throw new ArgumentNullException(nameof(spec), "Specifications cannot be null");
        }

        public bool IsSatisfiedBy(T entity)
        {
            return _spec.Aggregate(true, (current, specification) => current || specification.IsSatisfiedBy(entity));
        }
    }
}
