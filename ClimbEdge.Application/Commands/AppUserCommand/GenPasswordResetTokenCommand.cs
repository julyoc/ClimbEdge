using ClimbEdge.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Application.Commands.AppUserCommand
{
    public record GenPasswordResetTokenCommand (AppUser user) : IRequest<string?>;
    public class GenPasswordResetTokenCommandHandler(UserManager<AppUser> userManager) : IRequestHandler<GenPasswordResetTokenCommand, string?>
    {
        private readonly UserManager<AppUser> _userManager = userManager;
        public async Task<string?> Handle(GenPasswordResetTokenCommand request, CancellationToken cancellationToken)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(request.user);
        }
    }
}
