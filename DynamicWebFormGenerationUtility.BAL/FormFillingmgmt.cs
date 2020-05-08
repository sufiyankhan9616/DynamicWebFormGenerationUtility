using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DynamicWebFormGenerationUtility.DAL;

namespace DynamicWebFormGenerationUtility.BAL
{
    public class FormFillingmgmt
    {
        public static System.Data.DataSet GetControlByForm(int Id, Int64 SeqId, Int64 FormComponentMasterId)
        {
            return new DAL.FormFillingSQL().GetControlByForm(Id, SeqId, FormComponentMasterId);
        }
        public static System.Data.DataSet GetSearchingControlByForm(int Id)
        {
            return new DAL.FormFillingSQL().GetSearchingControlByForm(Id);
        }
        
        public static System.Data.DataSet GetComponantControlByForm(int Id, Int64 UserId)
        {
            return new DAL.FormFillingSQL().GetComponantControlByForm(Id, UserId);
        }
        public static System.Data.DataSet GetMaxUserIDByFormId(Int64 FormId)
        {
            return new DAL.FormFillingSQL().GetMaxUserIDByFormId(FormId);
        }
        public static System.Data.DataSet GetCascadingDropdown(string TemplateMasterId)
        {
            return new DAL.FormFillingSQL().GetCascadingDropdown(TemplateMasterId);
        }
        

        public static System.Data.DataSet BindDropDownFromTemplateDropDownId(string TemplateId)
        {
            return new DAL.FormFillingSQL().BindDropDownFromTemplateDropDownId(TemplateId);
        }

        public static System.Data.DataSet LoadChildDropDownTemplateMasterId(string TemplateDropDownId, string UserId, string ConfigurationHeadId)
        {
            return new DAL.FormFillingSQL().LoadChildDropDownTemplateMasterId(TemplateDropDownId, UserId, ConfigurationHeadId);
        }

        public static System.Data.DataSet BindDropDownFromTemplateDropDownIdAndPara1(string TemplateDropDownId, string Para1)
        {
            return new DAL.FormFillingSQL().BindDropDownFromTemplateDropDownIdAndPara1(TemplateDropDownId, Para1);
        }
        public static System.Data.DataSet AddUpdateFormFilling(Entity.FormFilling Entity)
        {
            return new DAL.FormFillingSQL().AddUpdateFormFilling(Entity);
        }
        public static int DeleteFormFilling(int FormId,Int32 SeqId, Int64 UserId, string HostName, string IpAddr, Int64 EventId, string TransactionId)
        {
            return new DAL.FormFillingSQL().DeleteFormFilling(FormId, SeqId, UserId, HostName, IpAddr, EventId, TransactionId);
        }

        //public static System.Data.DataSet BindDropDownFromTemplateDropDownId(string TemplateId)
        //{
        //    return new DAL.FormFillingSQL().BindDropDownFromTemplateDropDownId(TemplateId);
        //}

    }
}
