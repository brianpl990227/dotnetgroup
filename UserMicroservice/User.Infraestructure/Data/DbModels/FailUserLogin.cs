using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Infraestructure.Data.DbModels
{
    public class FailUserLogin
    {
        public int Id { get; set; }
        public string appUserEmail { get; set; }
        public int Time { get; set; }
    }
}
