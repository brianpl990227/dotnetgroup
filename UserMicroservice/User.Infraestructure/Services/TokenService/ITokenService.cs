﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Infraestructure.Services.TokenService
{
    public interface ITokenService
    {
        string BuildToken(string email);
    }
}
