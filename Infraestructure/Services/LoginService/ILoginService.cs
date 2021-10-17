using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DtoIn;

namespace Infraestructure.Services.LoginService
{
    public interface ILoginService
    {
        string SignIn(LoginDto dto);
    }
}
