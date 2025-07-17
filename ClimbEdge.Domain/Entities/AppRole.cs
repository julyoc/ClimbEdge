using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities
{
    public class AppRole : IdentityRole<long>
    {
        public AppRole() : base() { }

        public AppRole(string roleName) : base(roleName) { }
    }
}
