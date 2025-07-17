using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string entityName, string entityUid) : base($"La entidad '{entityName}' con uid '{entityUid}' no fue encontrada.") {}
    }
}
