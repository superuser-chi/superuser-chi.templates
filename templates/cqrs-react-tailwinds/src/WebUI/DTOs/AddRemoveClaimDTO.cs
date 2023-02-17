using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.DTOs
{
    public class AddRemoveClaimDTO
    {
        public List<ClaimDTO> ClaimsToBeRemoved { get; set; }
        public List<ClaimDTO> ClaimsToBeAdded { get; set; }
    }
}