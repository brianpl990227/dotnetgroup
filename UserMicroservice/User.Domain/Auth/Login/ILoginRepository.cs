using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Repositories.Auth;

namespace User.Domain.Auth.Login
{
    public interface ILoginRepository
    {
        LoginResultMO SignIn(LoginMO Mo);
        LoginFailResultMO AddFail(LoginMO Mo);
    }
}
