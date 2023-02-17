using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Settings
{
    public class AppSettings
    {
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public bool Authenticate { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPass { get; set; }
    }
}