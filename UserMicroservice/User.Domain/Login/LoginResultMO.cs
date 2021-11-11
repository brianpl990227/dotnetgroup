using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Domain.Login
{
    public class LoginResultMO
    {
        public int UserId { get; set; }
        public int ResultLogin { get; set; }
        public string Token { get; set; }
        


    }
}
