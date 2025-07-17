using ClimbEdge.Common.Constants;
using ClimbEdge.Domain.Entities;
using ClimbEdge.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Repositories
{
    public interface IUserProfileRepository : IRepository<UserProfile>
    {
        Task<UserProfile> GetUserProfileAsync(long userId);
        Task<UserProfile> GetUserProfileAsync(string userId);
    }
}
