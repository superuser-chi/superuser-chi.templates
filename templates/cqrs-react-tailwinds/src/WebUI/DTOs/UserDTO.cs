using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.DTOs
{
    public class UserDTO
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }
        public string Image { get; set; }
        public bool Locked { get; set; }
        public string Id { get; set; }

        public List<string> Roles { get; set; }
    }
}