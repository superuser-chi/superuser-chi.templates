using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Category
    {
        public Category()
        {
            SubCategories = new HashSet<SubCategory>();
        }
        public string CategoryID { get; set; }

        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public ICollection<SubCategory> SubCategories { get; set; }
    }
}