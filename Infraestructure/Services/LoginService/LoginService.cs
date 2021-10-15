using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DtoIn;
using Infraestructure.Data;
using Infraestructure.Services.TokenService;

namespace Infraestructure.Services.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly AppDbContext db;
        private readonly ITokenService tokenService;

        public LoginService(AppDbContext _db, ITokenService _tokenService)
        {
            db = _db;
            tokenService = _tokenService;
        }

        public string SignIn(LoginDto loginDto)
        {
            var result = db.AppUsers.Where(x => x.Email == loginDto.Email && x.Password == loginDto.Password).FirstOrDefault();

            return result != null ? tokenService.BuildToken(result.Email) : null;
        }


    }
}
