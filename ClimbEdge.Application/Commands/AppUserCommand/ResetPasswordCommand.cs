using ClimbEdge.Domain.Entities;
using ClimbEdge.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Application.Commands.AppUserCommand
{
    public record ResetPasswordCommand(AppUser user, string Token, string NewPassword) : IRequest<IdentityResult>;
    public class ResetPasswordCommandHandler(UserManager<AppUser> userManager, IAppUserRepository appUserRepository) : IRequestHandler<ResetPasswordCommand, IdentityResult>
    {
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly IAppUserRepository _appUserRepository = appUserRepository;

        public async Task<IdentityResult> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await _userManager.ResetPasswordAsync(request.user, request.Token, request.NewPassword);
            await _appUserRepository.SaveChangesAsync();
            return result;
        }
    }
}
