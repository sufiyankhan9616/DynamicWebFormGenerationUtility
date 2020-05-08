using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicWebFormGenerationUtility.Entity
{
    public class ParameterMaster
    {
        public string TamplateDropDownText { get; set; }
        public Int64 TamplateDropDownId { get; set; }
        public Int64 BaseParameterId { get; set; }
        public String  DropdownValue { get; set; }
        public Int64 UserId { get; set; }
        public string HostName { get; set; }
        public string IpAddr { get; set; }
        public Int64 EventId { get; set; }
        public Int32 ParameterId { get; set; }
        public Int32 MainParameter { get; set; }
        public String ParameterName { get; set; }
        public String BaseParameterName { get; set; }
        public String CreateDate { get; set; }
        
        public string TransactionId = Guid.NewGuid().ToString();
    }
}
