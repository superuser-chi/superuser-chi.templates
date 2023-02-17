using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Payment
    {
        public string PaymentID { get; set; }

        public bool DebitIndicator { get; set; }
        public string Reference { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        [Display(Name = "Type Of Payment")]
        public string PaymentTypeID { get; set; }
        public PaymentType PaymentType { get; set; }
        public string AccountID { get; set; }
        public Account Account { get; set; }
        public List<Order> Orders { get; set; }
    }
}