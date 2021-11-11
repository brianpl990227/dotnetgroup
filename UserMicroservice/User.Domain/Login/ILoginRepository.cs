using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Login;

namespace User.Domain.Login
{
    public interface ILoginRepository
    {
        Task<LoginResultMO> SignInAsync(LoginMO Mo);
        Task<LoginFailResultMO> AddFailAsync(LoginMO Mo);
        void RemoveFail(LoginMO Mo);
    }
}
