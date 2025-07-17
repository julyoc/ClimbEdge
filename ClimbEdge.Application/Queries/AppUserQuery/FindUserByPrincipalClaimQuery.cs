using ClimbEdge.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Application.Queries.AppUserQuery
{
    public record FindUserByPrincipalClaimQuery(ClaimsPrincipal user) : IRequest<AppUser?>;
    public class FindUserByPrincipalClaimQueryHandler(UserManager<AppUser> userManager) : IRequestHandler<FindUserByPrincipalClaimQuery, AppUser?>
    {
        private readonly UserManager<AppUser> _userManager = userManager;

        public Task<AppUser?> Handle(FindUserByPrincipalClaimQuery request, CancellationToken cancellationToken)
        {
            return _userManager.GetUserAsync(request.user);
        }
    }
}
