using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Login;


namespace User.Application.Auth
{
    public interface IAuthManager
    {
        Task<LoginResultMO> SignInWithEmailAsync(LoginMO loginMO);
        
    }
}
