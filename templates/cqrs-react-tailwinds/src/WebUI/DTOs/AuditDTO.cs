using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Utils;

namespace WebUI.DTOs
{
    public class AuditDTO : Domain.Audit
    {
        public new DateTime DateTime
        {
            get
            {
                return base.DateTime.Truncate(TimeSpan.TicksPerSecond);
            }
        }

    }
}