using CalorieTracker.API.Helpers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace CalorieTracker.API.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value?.ToLower();

            if (path == "/api/auth/sign-in")
            {
                await _next(context);
                return;
            }

            var token = context.Request.Headers.Authorization.FirstOrDefault();

            if (string.IsNullOrEmpty(token))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized");
                return;

            }

            var jwtToken = TokenHelper.ReadJwtToken(token);

            if (jwtToken == null)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Invalid token");
                return;
            }

            if(jwtToken.Issuer == "someone" && jwtToken.ValidTo.ToLocalTime() > DateTime.Now)
            {
               await _next(context);
               return;
            }

            context.Response.StatusCode = 401;
            await context.Response.WriteAsync(" ");
            return;
        }
    }
}
