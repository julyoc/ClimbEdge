namespace ClimbEdge.API.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IServiceCollection RegisterMiddlewares(this IServiceCollection services)
        {
            services.AddTransient<ApiKeyMiddleware>();
            return services;
        }
        public static IApplicationBuilder AddMiddlewares(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ApiKeyMiddleware>();
            return builder;
        }
    }
}
