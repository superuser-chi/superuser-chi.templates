using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Meeting : IValidatableObject
    {
        public string MeetingID { get; set; }

        public string Comments { get; set; }
        [Display(Name = "Start")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Quantity")]
        public int NumberOfParticipants { get; set; }
        public MeetingTypes MeetingType { get; set; }
        public Boolean Approved { get; set; }
        public Boolean Rejected { get; set; }
        [Display(Name = "Approver")]
        public string ApproverID { get; set; }
        public string InitiatorID { get; set; }
        public string Address { get; set; }

        // [AtleastOneCheckBoxCheked]
        public Boolean Breakfast { get; set; }

        // [AtleastOneCheckBoxCheked]
        public Boolean Lunch { get; set; }
        public ICollection<OnlineOrder> Orders { get; set; }

        public string LocationID { get; set; }
        public Location Location { get; set; }

        [NotMapped]
        public string StartDateFormatted
        {
            get
            {
                return StartDate.ToString("d");
            }
        }
        [NotMapped]
        public string EndDateFormatted
        {
            get
            {
                return EndDate.ToString("d");
            }
        }
        [NotMapped]
        public string Status
        {
            get
            {
                if (Approved)
                {
                    return "Approved";
                }
                else if (Rejected)
                {
                    return "Rejected by manager";
                }
                else
                {
                    return "Waiting for manager's approval";
                }
            }
        }
        public string OrderTypes
        {
            get
            {

                if (Lunch && Breakfast)
                    return "breakfast and lunch";
                else if (Breakfast)
                    return "breakfast only";
                else if (Lunch)
                    return "lunch only";
                else
                    return "nothing";

            }
        }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            if (StartDate > EndDate)
            {
                yield return new ValidationResult("EndDate must be greater than StartDate", new[] { nameof(EndDate) });
            }
            if (!(Breakfast || Lunch))
            {
                yield return new ValidationResult("Must check atleast one between breakfast or lunch", new[] { nameof(Breakfast), nameof(Lunch) });
            }
            if (MeetingType == MeetingTypes.Planned && NumberOfParticipants <= 0)
            {
                yield return new ValidationResult("Participants must be atleast 1", new[] { nameof(NumberOfParticipants) });
            }
            if (MeetingType == MeetingTypes.Planned && StartDate.Date == DateTime.Now.Date)
            {
                yield return new ValidationResult("Start date must not be equal to today's date", new[] { nameof(StartDate) });
            }
        }
    }
    public enum MeetingTypes
    {
        Planned,
        Adhoc
    }
}
