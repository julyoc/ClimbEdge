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
    public record LogOutCommand(AppUser user) : IRequest;
    public class LogOutCommandHandler(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IAppUserRepository appUserRepository) : IRequestHandler<LogOutCommand>
    {
        private readonly SignInManager<AppUser> _signInManager = signInManager;
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly IAppUserRepository _appUserRepository = appUserRepository;

        public async Task Handle(LogOutCommand request, CancellationToken cancellationToken)
        {
            var user = request.user;
            user.SecurityStamp = Guid.NewGuid().ToString();
            await _userManager.UpdateAsync(user);
            await _signInManager.SignOutAsync();
            await _appUserRepository.SaveChangesAsync();
        }
    }
}
