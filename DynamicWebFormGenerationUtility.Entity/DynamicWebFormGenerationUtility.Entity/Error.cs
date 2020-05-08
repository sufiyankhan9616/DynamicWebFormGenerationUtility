using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicWebFormGenerationUtility.Entity
{
    public class Error
    {
        public int ErrorId { get; set; }
        public string Message { get; set; }
        public string IpAddress { get; set; }
        public string Source { get; set; }
        public string UserName { get; set; }
        public string Browser { get; set; }
        public DateTime ErrorDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
