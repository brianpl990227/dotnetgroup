using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Repositories.Auth;

namespace User.Domain.Auth.User
{
    public interface IUserRepository
    {
        Task<bool> IsItBlockedAsync(LoginMO Mo);
        void BlockUser(LoginMO Mo);
        Task<bool> ExistAsync(LoginMO Mo);
    }
}
