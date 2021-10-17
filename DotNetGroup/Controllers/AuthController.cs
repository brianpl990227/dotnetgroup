using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DtoIn;
using Infraestructure.Services.LoginService;
using Microsoft.Extensions.Caching.Memory;
using Infraestructure.Services.CacheService;

namespace DotNetGroup.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginService loginService;
        private readonly ICacheService cache;

        public AuthController(ILoginService _loginService, ICacheService _cache)
        {
            //Proveo una instancia de LoginService mendiante una inyección de dependencia
            loginService = _loginService;

            cache = _cache;
        }

        /**
         * Endpoint para hacer login en el sistema
         * @param {string} LoginDto.Email - Es el Email que ingreso
         * @param {string} Login.Password - Contraseña con la que el usuario va a hacer login
         * @return {string} token - Token de autenticación del usuario, es un Jwt (Json Web Token)
         **/
        [HttpPost]
        public ActionResult<string> Login(LoginDto loginDtoIn)
        {
            try
            {
                //Tengo que comprobar si el Email esta bloqueado primero <-------------------

                //Se llama al servicio de login y se espera un valor de tipo string
                string token = loginService.SignIn(loginDtoIn);

                //Si tengo un token HTTPStatusCode = 200
                //Si no tengo un token HTTPStatusCode = 400
                if (token != null)
                {
                    return Ok(token);
                }
                else
                {
                    if(cache.CountLoginFailed(loginDtoIn.Email))
                    {
                        //Bloquear cuenta aqui
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
