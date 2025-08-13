namespace ClimbEdge.API.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder AddMiddlewares(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiKeyMiddleware>();
        }
    }
}
