using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class PortionType
    {
        public string PortionTypeID { get; set; }
        public ICollection<MenuItemPrice> MenuItemPrices { get; set; }
    }
}