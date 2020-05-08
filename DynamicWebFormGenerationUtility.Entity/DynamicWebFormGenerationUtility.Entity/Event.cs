using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicWebFormGenerationUtility.Entity
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }

        public bool IsRights = true;
    }
}
