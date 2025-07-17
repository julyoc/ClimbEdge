using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Constants;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities;
using ClimbEdge.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Application.Commands.AppUserCommand
{
    public record RegisterAppCommand(RegisterRequestDTO entity) : IRequest<AppUser>;
    public class RegisterAppCommandHandler : IRequestHandler<RegisterAppCommand, AppUser>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IAppUserRepository _appUserRepository;
        private readonly IUserProfileRepository _userProfileRepository;
        public RegisterAppCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager, IConfiguration configuration, IAppUserRepository appUserRepository,
            IUserProfileRepository userProfileRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _appUserRepository = appUserRepository;
            _userProfileRepository = userProfileRepository;
        }
        public async Task<AppUser> Handle(RegisterAppCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.entity.Email);
            if (existingUser != null) throw new InvalidOperationException("User with this email already exists.");
            if (request.entity.Password != request.entity.ConfirmPassword)
                throw new InvalidOperationException("Passwords do not match.");
            var entity = new AppUser
            {
                UserName = request.entity.Email,
                Email = request.entity.Email,
                EmailConfirmed = false
            };
            var resul = await _userManager.CreateAsync(entity, request.entity.Password);
            if (!resul.Succeeded)
            {
                var errors = string.Join(", ", resul.Errors.Select(e => e.Description));
                throw new InvalidOperationException($"User creation failed: {errors}");
            }
            await _userManager.AddToRoleAsync(entity, Roles.User);
            await _appUserRepository.SaveChangesAsync();
            // Create user profile
            var userProfile = new UserProfile
            {
                UserId = entity.Id,
                FirstName = request.entity.FirstName,
                LastName = request.entity.LastName,
            };
            await _userProfileRepository.AddAsync(userProfile);
            await _userProfileRepository.SaveChangesAsync();
            return entity;
        }
    }
}
