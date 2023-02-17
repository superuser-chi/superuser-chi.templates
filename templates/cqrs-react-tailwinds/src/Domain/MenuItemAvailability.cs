using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class MenuItemAvailability
    {
        public string MenuItemAvailabilityID { get; set; }
        public int Quantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime AvailableDate { get; set; }
        public string MenuItemID { get; set; }
        public MenuItem MenuItem { get; set; }

        public string LocationID { get; set; }
        public Location Location { get; set; }

    }
}