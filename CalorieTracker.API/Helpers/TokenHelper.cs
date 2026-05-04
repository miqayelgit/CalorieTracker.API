using System.IdentityModel.Tokens.Jwt;

namespace CalorieTracker.API.Helpers
{
    public static class TokenHelper
    {
        public static JwtSecurityToken ReadJwtToken(string token)
        {

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
