using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class PaymentType
    {
        public string PaymentTypeID { get; set; }
        public string Name { get; set; }

        public ICollection<Payment> Payments { get; set; }
    }
}