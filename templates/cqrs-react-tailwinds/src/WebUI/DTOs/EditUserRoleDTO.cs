using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.DTOs
{
    public class EditUserRoleDTO
    {
        public List<RoleDTO> RolesToBeRemoved { get; set; }
        public List<RoleDTO> RolesToBeAdded { get; set; }
    }
}