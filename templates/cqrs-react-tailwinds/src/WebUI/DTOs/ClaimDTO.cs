using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebUI.DTOs
{
    public class ClaimDTO
    {
        public string Type { get; set; }
        public string Module
        {
            get
            {
                string[] modules = Value.Split(".");
                return modules.Count() >= 1 ? modules[1] : modules[modules.Count()];
            }
        }
        public string Action
        {
            get
            {
                string[] modules = Value.Split(".");
                string action = modules.Count() > 0 ? modules[modules.Count() - 1] : modules[0];

                return Regex.Replace(action, "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", " $1");
            }
        }
        public string Value { get; set; }
    }
}