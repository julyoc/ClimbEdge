using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using ClimbEdge.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Repositories.Mountains.Itinerary
{
    public interface IExpeditionRepository : IRepository<Expedition>, IGeoHelper
    {
    }
}
