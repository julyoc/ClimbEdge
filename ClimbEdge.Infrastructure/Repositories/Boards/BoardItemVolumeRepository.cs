using ClimbEdge.Domain.Entities.Boards;
using ClimbEdge.Domain.Repositories.Boards;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Repositories.Boards
{
    public class BoardItemVolumeRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService) : Repository<BoardItemVolume>(climbEdgeContext, cacheService), IBoardItemVolumeRepository
    {
    }
}
