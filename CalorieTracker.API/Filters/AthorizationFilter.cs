using CalorieTracker.API.Helpers;
using CalorieTracker.Application.Options;
using CalorieTracker.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CalorieTracker.API.Filters;

public class AuthorizationFilter : Attribute, IAuthorizationFilter
{
    private readonly IOptions<JwtOptions> _jwtOptions;

    public AuthorizationFilter(IOptions<JwtOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions;
    }
    public async void OnAuthorization(AuthorizationFilterContext context)
    {
        var jwtToken = TokenHelper.ReadJwtToken(context.HttpContext);

        try
        {
            ValidateTokenValidity(jwtToken.RawData, _jwtOptions.Value.Secret);
        }

        catch (Exception ex)
        {

            context.HttpContext.Response.StatusCode = 401;
            await context.HttpContext.Response.WriteAsync(ex.Message);
            return;
        }
    }
    private static void ValidateTokenValidity(string token, string secretKey)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var parameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true
        };

        tokenHandler.ValidateToken(token, parameters, out SecurityToken validatedToken);
    }
}
