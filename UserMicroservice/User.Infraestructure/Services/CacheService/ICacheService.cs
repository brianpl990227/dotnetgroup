﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Infraestructure.Services.CacheService
{
    public interface ICacheService
    {
        bool CountLoginFailed(string email);
    }
}
