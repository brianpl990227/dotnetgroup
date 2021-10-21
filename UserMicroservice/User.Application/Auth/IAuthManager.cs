using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Auth.Login;
using User.Domain.Repositories.Auth;

namespace User.Application.Auth
{
    public interface IAuthManager
    {
        LoginResultMO SignInWithEmail(LoginMO loginMO);
    }
}
