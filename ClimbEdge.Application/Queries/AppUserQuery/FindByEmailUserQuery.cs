using ClimbEdge.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Application.Queries.AppUserQuery
{
    public record FindByEmailUserQuery(string Email) : IRequest<AppUser?>;
    public class FindByEmailUserQueryHandler : IRequestHandler<FindByEmailUserQuery, AppUser?>
    {
        private readonly UserManager<AppUser> _userManager;
        public FindByEmailUserQueryHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<AppUser?> Handle(FindByEmailUserQuery request, CancellationToken cancellationToken)
        {
            return await _userManager.FindByEmailAsync(request.Email);
        }
    }
}
