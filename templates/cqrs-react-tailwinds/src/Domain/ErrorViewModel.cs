using System;

namespace Domain
{
    public class ErrorViewModel
    {
        public string RequestID { get; set; }

        public bool ShowRequestID => !string.IsNullOrEmpty(RequestID);
    }
}
