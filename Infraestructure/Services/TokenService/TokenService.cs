using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Infraestructure.Services.TokenService
{
    public class TokenService : ITokenService
    {
        public string BuildToken(string email)
        {
            var claims = new[]
            {
                new Claim("id", Guid.NewGuid().ToString()),
                new Claim("email", email),

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ClaveSecreta"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddYears(1);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "dotnetgroup",
                audience: "dotnetgroup",
                claims: claims,
                expires: expiration,
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
