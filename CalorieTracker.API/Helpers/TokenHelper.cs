using System.IdentityModel.Tokens.Jwt;

namespace CalorieTracker.API.Helpers
{
    public static class TokenHelper
    {
        public static JwtSecurityToken ReadJwtToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            if (!tokenHandler.CanReadToken(token))
            {
                return null;
            }
            return tokenHandler.ReadJwtToken(token);
        }
    }
}
