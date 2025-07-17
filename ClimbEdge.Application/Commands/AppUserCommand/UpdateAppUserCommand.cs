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
    public record UpdateAppUserCommand (AppUser user) : IRequest;
    public class UpdateAppUserCommandHandler : IRequestHandler<UpdateAppUserCommand>
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly UserManager<AppUser> _userManager;
        public UpdateAppUserCommandHandler(IAppUserRepository appUserRepository, UserManager<AppUser> userManager)
        {
            _appUserRepository = appUserRepository;
            _userManager = userManager;
        }
        public async Task Handle(UpdateAppUserCommand request, CancellationToken cancellationToken)
        {
            await _userManager.UpdateAsync(request.user);
            await _appUserRepository.SaveChangesAsync();
        }
    }
}
