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
    public record ChangePasswordCommand(AppUser User, string OldPassword, string NewPassword) : IRequest<IdentityResult>;
    public class ChangePasswordCommandHandler(UserManager<AppUser> userManager, IAppUserRepository appUserRepository) : IRequestHandler<ChangePasswordCommand, IdentityResult>
    {
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly IAppUserRepository _appUserRepository = appUserRepository;

        public async Task<IdentityResult> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var res = await _userManager.ChangePasswordAsync(request.User, request.OldPassword, request.NewPassword);
            await _appUserRepository.SaveChangesAsync();
            return res;
        }
    }
}
