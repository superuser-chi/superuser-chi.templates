using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Order
    {
        public int OrderID { get; set; }
        [Display(Name = "Ref")]
        // [PrintAttribute(1)]
        public int OrderRef { get; set; }
        [Display(Name = "Date")]
        public DateTime OrderDate { get; set; }
        [Display(Name = "Total")]
        // [PrintAttribute(3)]
        public decimal OrderTotal { get; set; }
        public DateTime PickUpTime { get; set; }
        public OrderStatus Status { get; set; }
        public string PaymentStatus { get; set; }
        public string Comment { get; set; }
        public string PickupName { get; set; }
        public bool IsTenant { get; set; }

        [Display(Name = "TakeAway")]
        public bool SitIn { get; set; }
        public string LocationID { get; set; }
        public string DiscriminatorValue
        {
            get
            {
                if (this.GetType().Name == "Order") return "Cash Order";
                return "Online Order";
            }
        }
        public Location Location { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }
    public class OnlineOrder : Order
    {
        public string PaymentID { get; set; }
        public Payment Payment { get; set; }
        public string MeetingID { get; set; }
        public Meeting Meeting { get; set; }
        public bool IsIndividualOrder { get { return String.IsNullOrEmpty(MeetingID); } }
    }

    public enum OrderType
    {
        CashOrder,
        OnlineOrder
    }
    public enum OrderStatus
    {
        Submitted,
        Preparing,
        Ready,
        Finished,
    }
}