using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class OfficeAddress
    {
        public string OfficeAddressID { get; set; }
        public string Name { get; set; }
        public string LocationID { get; set; }
        public Location Location { get; set; }
        public List<User> Users { get; set; }
    }
}
