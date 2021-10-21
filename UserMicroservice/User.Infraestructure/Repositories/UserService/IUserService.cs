using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Infraestructure.Services.UserService
{
    public interface IUserService
    {
        void BlockUser(string email);
       
    }
}
