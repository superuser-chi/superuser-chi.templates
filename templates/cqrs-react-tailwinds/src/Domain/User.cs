using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    [Table("AspNetUsers")]
    public class User : IdentityUser
    {

        [PersonalData]
        public string Name { get; set; }

        [PersonalData]
        public string Surname { get; set; }

        [PersonalData]
        public string OfficeAddressID { get; set; }
        public OfficeAddress OfficeAddress { get; set; }

        public string LocationID { get; set; }

        public Location Location { get; set; }

        [PersonalData]
        public bool? IsNewUser { get; set; }

        [PersonalData]
        public DateTime RegisterDate { get; set; }
        public string AccountID { get; set; }
        public IndividualAccount Account { get; set; }

        public string DepartmentID { get; set; }
        public Department Department { get; set; }


        [NotMapped]
        public string DepartmentName { get; set; }
        [NotMapped]
        public IdentityRole CurrentRole { get; set; }
    }
}