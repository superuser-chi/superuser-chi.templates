using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class CustomerType
    {
        public string CustomerTypeID { get; set; }
        public string Name { get; set; }
        public ICollection<MenuItemPrice> MenuItemPrices { get; set; }
    }
}