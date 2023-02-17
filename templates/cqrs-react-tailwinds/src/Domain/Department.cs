using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Department
    {

        public string DepartmentID { get; set; }
        public long Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<User> Users { get; set; }
        public string AccountID { get; set; }
        public DepartmentalAccount Account { get; set; }
    }
}
