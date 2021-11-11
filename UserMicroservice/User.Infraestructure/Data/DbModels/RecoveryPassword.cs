using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Infraestructure.Data.DbModels
{
    public class RecoveryPassword
    {
        public string Email { get; set; }
        public int RecoveryCode { get; set; }
    }
}
