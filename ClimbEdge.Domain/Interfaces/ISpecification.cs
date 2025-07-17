using ClimbEdge.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Estos speficications son usados para validar las entidades del dominio se puede usar dentro del dominio (entities) o en la capa de aplicación (Services) pero nunca en controladores ni repositories
namespace ClimbEdge.Domain.Interfaces
{
    public interface ISpecification<T> where T : BaseModel
    {
        bool IsSatisfiedBy(T entity);
    }
}
