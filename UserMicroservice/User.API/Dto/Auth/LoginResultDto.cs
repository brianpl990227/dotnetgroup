using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.API.Dto.Auth
{
    public class LoginResultDto
    {
        public int UserId { get; set; }
        public string Token { get; set; }
    }
}
