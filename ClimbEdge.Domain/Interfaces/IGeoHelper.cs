using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Interfaces
{
    public interface IGeoHelper
    {
        GeometryFactory GetGeometryFactory();
    }
}
