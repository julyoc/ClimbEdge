using ClimbEdge.Application.Commands.UserProfileCommand;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Application.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services,
            IConfiguration configuration,
            bool isDev)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateUserProfileCommand>());
            return services;
        }
    }
}
