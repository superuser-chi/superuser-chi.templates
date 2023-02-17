using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class OrderDetails
    {
        public int OrderDetailsID { get; set; }
        public int Quantity { get; set; }
        public string MenuItemID { get; set; }
        public MenuItem MenuItem { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }

    }
}