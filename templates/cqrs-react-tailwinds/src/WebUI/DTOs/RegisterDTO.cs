using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.DTOs
{
    public class RegisterDTO : LoginDTO
    {
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public string Username { get; set; }
    }
}