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
    public record LogInWithPasswordQuery(AppUser user, string password) : IRequest<SignInResult>;
    public class LogInWithPasswordQueryHandler : IRequestHandler<LogInWithPasswordQuery, SignInResult>
    {
        private readonly SignInManager<AppUser> _signInManager;
        public LogInWithPasswordQueryHandler(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public async Task<SignInResult> Handle(LogInWithPasswordQuery request, CancellationToken cancellationToken)
        {
            return await _signInManager.PasswordSignInAsync(request.user, request.password, false, false);
        }
    }
}
