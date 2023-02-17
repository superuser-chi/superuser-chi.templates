using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Location
    {
        public string LocationID { get; set; }
        public string Name { get; set; }

        public List<User> Users { get; set; }
        public List<OfficeAddress> Offices { get; set; }

        public List<MenuItemAvailability> Availabilities { get; set; }

        public List<Order> Orders { get; set; }

        public List<Meeting> Meetings { get; set; }

    }
}
