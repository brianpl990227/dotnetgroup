using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Infraestructure.Data.DbModels
{
    public class AppUser
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [MinLength (10)]
        public string Password { get; set; }
        public bool Blocked { get; set; }

    }
}
