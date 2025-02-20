using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using APICore.AppSettings;
using Microsoft.IdentityModel.Tokens;

namespace APICore.Factoty.Token
{
    public class JwtTokenProvider : ITokenProvider
    {
        private readonly TokenSettings _tokenSettings;
        public JwtTokenProvider(TokenSettings tokenSettings=null)
        {
            _tokenSettings = tokenSettings;
        }

        public async Task<string> GenerateTokenAsync(string userId, IEnumerable<string> roles)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, userId));

            if (roles != null)
            {
                claims.Add(new Claim(ClaimTypes.Role, string.Join(",", roles)));              
            };  

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
            issuer: _tokenSettings.Issuer,
            audience: _tokenSettings.Audience,
            claims: claims,
            expires: DateTime.Now.Add(_tokenSettings.ExpirationTime),
            signingCredentials: credentials
        );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> RefreshTokenAsync(string token)
        {
            // Logic for refreshing the token (could return a new token with an extended expiration)
            if (await ValidateTokenAsync(token))
            {
                var userId = "extractedFromToken";  // This would be extracted from the token
                var roles = new List<string> { "User" }; // Extract roles as well if needed
                return await GenerateTokenAsync(userId, roles);
            }
            return null;
        }

        public async Task<bool> ValidateTokenAsync(string token)
        {
            try
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.SecretKey));
                var handler = new JwtSecurityTokenHandler();
                var principal = handler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _tokenSettings.Issuer,
                    ValidAudience = _tokenSettings.Audience,
                    IssuerSigningKey = key
                }, out var validatedToken);

                return validatedToken != null;
            }
            catch
            {
                return false;
            }
        }
    }
}
