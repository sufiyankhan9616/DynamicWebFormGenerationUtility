using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DynamicWebFormGenerationUtility.Entity
{
    public class FormMaster
    {
        public Int32 FormId { get; set; }
        public string Is_Freez { get; set; }
        public string FormName { get; set; }
        public string FormTitle { get; set; }
        public string Remarks { get; set; }
        public Int64 UserId { get; set; }
        public string HostName { get; set; }
        public string IpAddr { get; set; }
        public bool Isupdate { get; set; }
        public Int64 EventId { get; set; }

        public string TransactionId = Guid.NewGuid().ToString();
        public int RefFormId { get; set; }
        public DataTable DtComponent { get; set; }
        public int FormComponentMasterId { get; set; }
        public string ComponentName { get; set; }
        public Decimal ComponentSeqNo { get; set; }

        public string DistName { get; set; }
        public string TalName { get; set; }
        public string OfficeName { get; set; }
        public string OtherSession { get; set; }
        public string RoleName { get; set; }
        public string Roleid { get; set; }
        public string UserName { get; set; }
    }
}
