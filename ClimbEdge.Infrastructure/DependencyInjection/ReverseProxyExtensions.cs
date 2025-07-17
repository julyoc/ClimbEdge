using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.DependencyInjection
{
    public static class ReverseProxyExtensions
    {
        public static IServiceCollection AddFrontReverseProxy(
            this IServiceCollection services,
            bool isDev)
        {
            services.AddReverseProxy()
                .LoadFromMemory(new[]
                {
                    new Yarp.ReverseProxy.Configuration.RouteConfig
                    {
                        RouteId = "qwik-ui",
                        Match = new Yarp.ReverseProxy.Configuration.RouteMatch
                        {
                            Path = "/{**catch-all}"
                        },
                        ClusterId = "qwik-ui-cluster"
                    }
                },
                new[]
                {
                    new Yarp.ReverseProxy.Configuration.ClusterConfig
                    {
                        ClusterId = "qwik-ui-cluster",
                        Destinations = new Dictionary<string, Yarp.ReverseProxy.Configuration.DestinationConfig>
                        {
                            { "qwik-ui-destination", new Yarp.ReverseProxy.Configuration.DestinationConfig
                                {
                                    Address = isDev ? "http://localhost:5173/" : "http://localhost:5173/"
                                }
                            }
                        }
                    }
                });
            return services;
        }
    }
}
