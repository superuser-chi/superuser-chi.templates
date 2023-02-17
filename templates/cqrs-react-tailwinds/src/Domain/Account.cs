using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Account
    {

        public string AccountID { get; set; }
        [Display(Name = "Name")]
        public string AccountName { get; set; }
        [Display(Name = "Balance")]
        public decimal AccountBalance { get; set; }
        [Display(Name = "Account number")]
        public long AccountNumber { get; set; }
        public ICollection<Payment> Payments { get; set; }

    }

    public class IndividualAccount : Account
    {
        // for individual accounts
        [Display(Name = "Holder")]
        public string Id { get; set; }
        public User User { get; set; }
    }

    public class DepartmentalAccount : Account
    {
        // for individual accounts
        [Display(Name = "Holder")]
        public string DepartmentID { get; set; }
        public Department Department { get; set; }
    }

    public enum AccountTypes
    {
        [Description("Individual Account")]
        IndividualAccount,
        [Description("Departmental Account")]
        DepartmentalAccount,
    }
}
