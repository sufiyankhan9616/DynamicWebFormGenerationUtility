using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicWebFormGenerationUtility.Entity
{
   public  class RegexMasterEntitycs
    {
        public Int64 RegexId { get; set; }
        public string ValidationName { get; set; }
        public string ErrMsg { get; set; }
        public string ValidationExp { get; set; }
        public string HostName { get; set; }
        public string IpAddr { get; set; }
        public string TransactionId = Guid.NewGuid().ToString();
        public Int64 UserId { get; set; }
        public Int64 EventId { get; set; }
        public bool  Isdelete { get; set; }
    }
}
