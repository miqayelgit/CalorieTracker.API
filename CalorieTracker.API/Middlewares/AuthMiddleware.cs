using CalorieTracker.API.Attributes;
using CalorieTracker.API.Helpers;
using CalorieTracker.Application.Options;
using Microsoft.Extensions.Options;

namespace CalorieTracker.API.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IOptions<JwtOptions> jwtOptions)
        {

            var endpoint = context.GetEndpoint();

            if (endpoint?.Metadata.GetMetadata<CustomAuthAttribute>() != null)
            {
                var jwtToken = TokenHelper.ReadJwtToken(context);

                if (jwtToken == null)
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Invalid token");
                    return;
                }

            }

            await _next(context);
       
        }
    }
}
