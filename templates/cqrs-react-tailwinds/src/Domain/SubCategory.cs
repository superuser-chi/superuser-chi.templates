using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class SubCategory
    {
        public string SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }

        public string CategoryID { get; set; }
        public Category Category { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
    }
}