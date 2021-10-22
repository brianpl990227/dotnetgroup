using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Application.Auth;
using User.API.Dto.Auth;
using User.Domain.Repositories.Auth;

namespace User.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager authManager;
        public AuthController(IAuthManager _authManager) => authManager = _authManager;
        
           

        /**
         * Endpoint para hacer login en el sistema
         * @param {string} LoginDto.Email - Es el Email que ingreso
         * @param {string} LoginDto.Password - Contraseña con la que el usuario va a hacer login
         * @return {string} token - Token de autenticación del usuario, es un Jwt (Json Web Token)
         **/
        [HttpPost]
        public ActionResult Login(LoginDto login)
        {
            try
            {
                LoginMO loginMO = new LoginMO()
                {
                    Email = login.Email,
                    Password = login.Password
                };

                var loginResult = authManager.SignInWithEmail(loginMO);

                LoginResultDto loginDtoOut = new LoginResultDto()
                {
                    UserId = loginResult.UserId,
                    Token = loginResult.Token
                };

                switch (loginResult.ResultLogin)
                {
                    case 1:
                        return Ok("ddfglkbfsrxkhvgfnskhgvdbhv");
                    case -1:
                        return BadRequest();
                    case 0:
                        return Unauthorized();
                    default:
                        return BadRequest();

                };
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
