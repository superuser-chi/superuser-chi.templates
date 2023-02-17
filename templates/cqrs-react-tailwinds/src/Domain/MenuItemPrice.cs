using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class MenuItemPrice
    {
        public string MenuItemPriceID { get; set; }

        [Required(ErrorMessage = "Required Decimal Number")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,100})$", ErrorMessage = "Valid Decimal number with maximum  decimal places.")]
        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string MenuItemID { get; set; }
        public MenuItem MenuItem { get; set; }
        public bool IsExternal { get; set; }

        public string CustomerTypeID { get; set; }
        public CustomerType CustomerType { get; set; }
        public PortionType PortionType { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}