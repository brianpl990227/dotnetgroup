using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DtoIn;
using Infraestructure.Services.LoginService;

namespace DotNetGroup.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginService loginService;

        public AuthController(ILoginService _loginService)
        {
            loginService = _loginService;
        }

        [HttpPost("login")]
        public ActionResult<string> Login(LoginDto loginDtoIn)
        {
            string token = loginService.SignIn(loginDtoIn);

            return token != null ? Ok(token) : BadRequest();   
        }
        
    }
}
