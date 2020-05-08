using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DynamicWebFormGenerationUtility.Entity
{

    public class ConfigurationHead
    {
        public Int64 ConfigurationHeadId { get; set; }
        public string ConfigurationHeadName { get; set; }
        public Int32 FormId { get; set; }
        public string FormTitle { get; set; }
        public string HeadNote { get; set; }
        public int InputTypeId { get; set; }
        public string InputType { get; set; }
        public string MinInputValue { get; set; }
        public string MaxInputValue { get; set; }

        public int MaxLength { get; set; }

        public Decimal DisplayPreferenceNo { get; set; }
        public bool IsCompulsaryEntry { get; set; }
        public Int64 TemplateDropdownMasterId { get; set; }
        public string TemplateDropdownName { get; set; }
        public string Remark { get; set; }
        public Boolean  IsSearchableDropdown {  get; set; }
        public Int64 UserId { get; set; }
        public string HostName { get; set; }
        public string IpAddr { get; set; }
        public Int64 EventId { get; set; }
        public string TransactionId = Guid.NewGuid().ToString();
        public string Description { get; set; }
        public Int64     ChildDBId { get; set; }

        public string QueryName { get; set; }
        public string QueryMasterId { get; set; }
        public string FormName { get; set; }
        public string ColumnsName { get; set; }
        public string ConditionString { get; set; }
        public string ColumnsId { get; set; }
        public string TableName { get; set; }
        public string Agrigatevar { get; set; }
        public string Alias { get; set; }
        public Boolean  IsGroupBy { get; set; }
        public DataTable dtQuerydata { get; set; }
        public string QueryDisplayText { get; set; }
        public bool IsCompositeUniqueKey { get; set; }
        public bool IsUniqueKey { get; set; }
        public Int64 FormComponentMasterId { get; set; }
        public Int64 RegexMasterId { get; set; }
    }
}
