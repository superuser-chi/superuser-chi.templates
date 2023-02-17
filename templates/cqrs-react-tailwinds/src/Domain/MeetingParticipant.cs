using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class MeetingParticipant
    {
        public string MeetingParticipantID { get; set; }
        public string UserID { get; set; }
        public string MeetingID { get; set; }
        public bool HasOrdered { get; set; }
    }
}
