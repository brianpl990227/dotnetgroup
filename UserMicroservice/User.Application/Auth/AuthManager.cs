using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Auth.Login;
using User.Domain.Auth.Token;
using User.Domain.Auth.User;
using User.Domain.Repositories.Auth;


namespace User.Application.Auth
{
    public class AuthManager : IAuthManager
    {
        private readonly ILoginRepository login;
        private readonly ITokenRepository token;
        private readonly IUserRepository user;

 
        public AuthManager(ILoginRepository _login, ITokenRepository _token, IUserRepository _user)
        {
            login = _login;
            token = _token;
            user = _user;
        }

        public LoginResultMO SignInWithEmail(LoginMO loginMO)
        {
            if(!user.Exist(loginMO))
            {
                return new LoginResultMO() { ResultLogin = -1 };
            }

            if(user.IsItBlocked(loginMO))
            {
                return new LoginResultMO() { ResultLogin = 0 };
            }

            var loginResult = login.SignIn(loginMO);
            
            switch(loginResult.ResultLogin)
            {
                case 1:
                    TokenMO tokenMO = new TokenMO()
                    {
                        Email = loginMO.Email
                    };

                    var tokenResult = token.BuildToken(tokenMO);
                    loginResult.Token = tokenResult.Token;
                    break;

                case -1:
                    var loginFailResult = login.AddFail(loginMO);

                    if(loginFailResult.Blocked)
                    {
                        user.BlockUser(loginMO);
                    }
                    break;

                default:
                    return loginResult;
            }                               
            return loginResult;
        }

       
    }
}
