using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DtoIn;
using Infraestructure.Data;
using Infraestructure.Services.TokenService;
using Domain.DbModel;

namespace Infraestructure.Services.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly AppDbContext db;
        private readonly ITokenService tokenService;

        public LoginService(AppDbContext _db, ITokenService _tokenService)
        {
            //Se obtienen una instancia de AppDbContext y TokenService mediante inyecciones de dependencias
            db = _db; 
            tokenService = _tokenService;
        }

        public string SignIn(LoginDto loginDto)
        {
            //Se devuelve el usuario que coincida con las credenciales de loginDto y se guarda en result
            var result = db.AppUsers.Where(x => x.Email == loginDto.Email && x.Password == loginDto.Password).Select(x => x.Email).FirstOrDefault();

            //Si result tiene el correo lo paso como parametro a tokenService para construir el token, si no lo tiene retorno null
            return result != null ? tokenService.BuildToken(result) : null;
        }


    }
}
