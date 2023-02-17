using System.Collections.Generic;

namespace Domain
{
    public class MenuItem
    {
        public string MenuItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool Special { get; set; }

        public string OrderDetailsID { get; set; }
        public OrderDetails OrdeDetail { get; set; }
        public string SubCategoryID { get; set; }
        public SubCategory SubCategory { get; set; }
        public ICollection<MenuItemPrice> MenuItemPrices { get; set; }
        public ICollection<MenuItemAvailability> MenuItemAvailabilities { get; set; }

    }
}