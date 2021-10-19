using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Domain.DtoIn;
using User.Infraestructure.Services.LoginService;
using Microsoft.Extensions.Caching.Memory;
using User.Infraestructure.Services.CacheService;
using User.Infraestructure.Services.UserService;

namespace User.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginService loginService;
        private readonly ICacheService cache;
        private readonly IUserService userService;

        public AuthController(ILoginService _loginService, ICacheService _cache, IUserService _userService)
        {
            //Proveo una instancias mendiante una inyecciones de dependencia
            loginService = _loginService;
            userService = _userService;
            cache = _cache;
        }

        /**
         * Endpoint para hacer login en el sistema
         * @param {string} LoginDto.Email - Es el Email que ingreso
         * @param {string} LoginDto.Password - Contraseña con la que el usuario va a hacer login
         * @return {string} token - Token de autenticación del usuario, es un Jwt (Json Web Token)
         **/
        [HttpPost]
        public IActionResult Login(LoginDto loginDtoIn)
        {
            try
            {
                bool blocked = userService.isItBlocked(loginDtoIn.Email);
                if (blocked)
                {
                    return Unauthorized();
                }

                //Se llama al servicio de login y se espera un valor de tipo string
                string token = loginService.SignIn(loginDtoIn);

                //Si tengo un token HTTPStatusCode = 200
                if(token != "")
                {
                    return Ok(token);
                }
                else
                {
                    //Si el intento de login fue fallido (no tengo token), cuento un intento fallido
                    //si son 3 entra dentro del if y bloquea la cuenta
                    if(cache.CountLoginFailed(loginDtoIn.Email))
                    {
                        //Bloqueo la cuenta
                        userService.BlockUser(loginDtoIn.Email);
                        return Unauthorized();
                    }
                    return BadRequest();
                }

               
            }
            catch(Exception e)
            {
                //Si paso algo, capturo la excepción y le mando el mensaje de la excepción al cliente
               return BadRequest(e.Message);
            }
           
 
        }

    }
}
