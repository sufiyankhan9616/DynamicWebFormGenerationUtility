using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicWebFormGenerationUtility.Entity
{
    public class TemplateMaster
    {
        public Int32 TemplateDropDownId { get; set; }
        public string TemplateDropdownName { get; set; }
        public string IsActive { get; set; }
        public string IsDeleted { get; set; }
        public Int64 UserId { get; set; }
        public string ModifiedBy { get; set; }
        public string HostName { get; set; }
        public string IpAddr { get; set; }
        public Int64 EventId { get; set; }

        public string TransactionId = Guid.NewGuid().ToString();
        public int RefFormId { get; set; }
    }
}
