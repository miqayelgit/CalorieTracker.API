using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace CalorieTracker.API.Helpers
{
    public static class TokenHelper
    {
        public static JwtSecurityToken ReadJwtToken(HttpContext context)
        {

            var token = context.Request.Headers.Authorization.ToString();

            if(string.IsNullOrEmpty(token))
            {
                return null;
            }

            token = token.Substring("Bearer ".Length).Trim();

            var tokenHandler = new JwtSecurityTokenHandler();

            if (!tokenHandler.CanReadToken(token))
            {
                return null;
            }
            
            return tokenHandler.ReadJwtToken(token);
        }
    }
}
