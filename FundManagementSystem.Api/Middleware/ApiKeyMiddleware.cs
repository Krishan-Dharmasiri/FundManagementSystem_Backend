namespace FundManagementSystem.Api.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string _ApiKeyName = "XApiKey";

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next= next;
        }

        public async Task InvokeAsync(HttpContext context, IConfiguration config)
        {
            var isApiKeyPresentInHeader = context.Request.Headers.TryGetValue(_ApiKeyName, out var extractedApiKey);
            var apiKey = config[_ApiKeyName];

            if(isApiKeyPresentInHeader && apiKey == extractedApiKey
                || context.Request.Path.StartsWithSegments("/swagger"))
            {
                await _next(context);
                return;
            }

            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Invalid Api Key");
        }
    }
}
