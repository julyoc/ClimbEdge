using ClimbEdge.Domain.Interfaces;
using ClimbEdge.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Specifications
{
    public class NotSpecification<T> : ISpecification<T> where T : BaseModel
    {
        private readonly ISpecification<T> _spec;
        public NotSpecification(ISpecification<T> spec)
        {
            _spec = spec ?? throw new ArgumentNullException(nameof(spec), "Specifications cannot be null");
        }

        public bool IsSatisfiedBy(T entity)
        {
            return !_spec.IsSatisfiedBy(entity);
        }
    }
}
