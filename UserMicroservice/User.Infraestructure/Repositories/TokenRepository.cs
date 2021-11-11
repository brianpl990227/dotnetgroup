using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using User.Infraestructure.Repositories;
using User.Domain.Token;

namespace User.Infraestructure.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private IConfiguration configuration { get; }

        //Inyecto ICOnfiguration para poder acceder al appseting.json y obtener el key posteriormente
        public TokenRepository(IConfiguration config) => configuration = config;

        public TokenResult BuildToken(TokenMO TokenMO)
        {
   
            //Creo los claims con los que voy a contruir mi token
            //Un claim se compone por <propiedad, valor> como puedes ver a continuación
            var claims = new[]
            {
                new Claim("id", Guid.NewGuid().ToString()),
                new Claim("email", TokenMO.Email),

            };

            //Creo la llave de seguridad obteniendola del appsettings.json
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Key").Value));
            //Digo con que algoritmo de encriptamiento voy a encriptar la llave de seguridad
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Digo cuando va a expirar el token, esto no es obligatorio
            var expiration = DateTime.UtcNow.AddYears(1);

            //Conformo mi token
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "dotnetgroup",
                audience: "dotnetgroup",
                claims: claims,
                expires: expiration,
                signingCredentials: creds);

            //Escribo mi token, Esto devuelve un string largo y raro encriptado
            TokenResult tokenR = new TokenResult()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            }; 
            return  tokenR;
        }
    }
}
