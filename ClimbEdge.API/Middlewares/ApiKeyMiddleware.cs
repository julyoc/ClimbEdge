namespace ClimbEdge.API.Middlewares
{
    public class ApiKeyMiddleware : IMiddleware
    {
        private const string API_KEY_HEADER = "X-API-Key";
        private readonly string _apiKey;
        private static readonly PathString[] _blacklist = [ "/api" ];
        public ApiKeyMiddleware(IConfiguration config)
        {
            _apiKey = config["ApiSettings:ApiKey"]; // Desde appsettings.json o variables de entorno
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (_blacklist.Any(path => context.Request.Path.StartsWithSegments(path)))
            {
                if (!context.Request.Headers.TryGetValue(API_KEY_HEADER, out var apiKey) || apiKey != _apiKey)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized; // Unauthorized
                    await context.Response.WriteAsync("Unauthorized");
                    return;
                }
            }
            // Si la clave es correcta, continúa con la siguiente middleware
            await next(context);
        }
    }
}
