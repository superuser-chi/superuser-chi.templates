using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$", ErrorMessage="Password must be complex")]
        public string Password { get; set; }
    }
}