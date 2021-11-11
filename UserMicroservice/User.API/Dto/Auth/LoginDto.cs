using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.API.Dto.Auth
{
    public class LoginDto
    {
        [Required (ErrorMessage = "Necesitas un email")]
        [EmailAddress (ErrorMessage = "No es una dirección email válida")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}


/*
 * 
 * 
 * 
 * 
 * 
 * */