using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DynamicWebFormGenerationUtility.Entity
{
    public class FormFilling
    {
        public Int64 ConfigurationHeadId { get; set; }
        public string ConfigurationHeadName { get; set; }
        public string HeadNote { get; set; }
        public int InputTypeId { get; set; }
        public string InputType { get; set; }
        public string MinInputValue { get; set; }
        public string MaxInputValue { get; set; }
        public Int64 SeqId { get; set; }
        public bool IsCompulsaryEntry { get; set; }
        public Int64 TemplateDropdownMasterId { get; set; }
        public string TemplateDropdownName { get; set; }
        public int FormId { get; set; }
        public DataTable dt { get; set; }

        public Int64 UserId { get; set; }

        public string HostName { get; set; }
        public string IpAddr { get; set; }
        public bool Isupdate { get; set; }
        public Int64 EventId { get; set; }
        public string TransactionId = Guid.NewGuid().ToString();
        public string DistCode { get; set; }
        public string TalCode { get; set; }
        public string OfficeId { get; set; }
        public string OtherSession { get; set; }



    }
}
