using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicWebFormGenerationUtility.DAL
{
    public class FormFillingSQL : BaseSQLManager
    {
        public virtual System.Data.DataSet GetControlByForm(int FormId,Int64 SeqId, Int64 FormComponentMasterId)
        {
            List<Entity.FormFilling> lstConfigurationHead = new List<Entity.FormFilling>();

            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandType = CommandType.StoredProcedure;
            cmdSelect.CommandTimeout = 0;
            cmdSelect.CommandText = "dbo.GetControlByForm";
            cmdSelect.Parameters.AddWithValue("@FormId", FormId);
            cmdSelect.Parameters.AddWithValue("@SeqId", SeqId);
            cmdSelect.Parameters.AddWithValue("@FormComponentMasterId", FormComponentMasterId);
            return BaseSQLManager.ExecuteDataset(cmdSelect);

        }

        public virtual System.Data.DataSet GetSearchingControlByForm(int FormId)
        {
            List<Entity.FormFilling> lstConfigurationHead = new List<Entity.FormFilling>();

            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandType = CommandType.StoredProcedure;
            cmdSelect.CommandTimeout = 0;
            cmdSelect.CommandText = "dbo.GetSearchingControlByForm";
            cmdSelect.Parameters.AddWithValue("@FormId", FormId);
            return BaseSQLManager.ExecuteDataset(cmdSelect);

        }
        public virtual System.Data.DataSet GetComponantControlByForm(int FormId, Int64 UserId)
        {
            List<Entity.FormFilling> lstConfigurationHead = new List<Entity.FormFilling>();

            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandType = CommandType.StoredProcedure;
            cmdSelect.CommandTimeout = 0;
            cmdSelect.CommandText = "dbo.GetComponantControlByForm";
            cmdSelect.Parameters.AddWithValue("@FormId", FormId);
            cmdSelect.Parameters.AddWithValue("@UserId", UserId);
            return BaseSQLManager.ExecuteDataset(cmdSelect);

        }
        public virtual System.Data.DataSet GetMaxUserIDByFormId(Int64 FormId)
        {
            List<Entity.FormFilling> lstConfigurationHead = new List<Entity.FormFilling>();

            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandType = CommandType.StoredProcedure;
            cmdSelect.CommandTimeout = 0;
            cmdSelect.CommandText = "dbo.GetMaxUserIDByFormId";
            cmdSelect.Parameters.AddWithValue("@FormId", FormId);
            return BaseSQLManager.ExecuteDataset(cmdSelect);

        }

        public virtual System.Data.DataSet GetCascadingDropdown(string TamplateDropDownId  )
        {
            List<Entity.FormFilling> lstConfigurationHead = new List<Entity.FormFilling>();

            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandType = CommandType.StoredProcedure;
            cmdSelect.CommandTimeout = 0;
            cmdSelect.CommandText = "dbo.GetCascadingDropDownData";
            cmdSelect.Parameters.AddWithValue("@TamplateDropDownId", TamplateDropDownId);
            return BaseSQLManager.ExecuteDataset(cmdSelect);

        }
        public virtual DataSet AddUpdateFormFilling(Entity.FormFilling Entity)
        {
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.CommandType = CommandType.StoredProcedure;
            cmdInsert.CommandTimeout = 0;
            cmdInsert.CommandText = "dbo.AddUpdateFormFilling";
            this.FillParamsDetails(cmdInsert.Parameters, Entity);
            DataSet res = BaseSQLManager.ExecuteDataset(cmdInsert);
            base.ForceCloseConnection(cmdInsert);
            return res;

        }
        public void FillParamsDetails(SqlParameterCollection parameters, Entity.FormFilling Entity)
        {
            parameters.AddWithValue("@FormId", Entity.FormId);
            parameters.AddWithValue("@dt", Entity.dt);
            parameters.AddWithValue("@UserId", Entity.UserId);
            parameters.AddWithValue("@HostName", Entity.HostName);
            parameters.AddWithValue("@IpAddr", Entity.IpAddr);
            parameters.AddWithValue("@EventId", Entity.EventId);
            parameters.AddWithValue("@TransactionId", Entity.TransactionId);
            parameters.AddWithValue("@Isupdate", Entity.Isupdate);
            parameters.AddWithValue("@SeqId", Entity.SeqId);
            parameters.AddWithValue("@DistCode", Entity.DistCode );
            parameters.AddWithValue("@TalCode", Entity.TalCode );
            parameters.AddWithValue("@OfficeId", Entity.OfficeId);
            parameters.AddWithValue("@OtherSession", Entity.OtherSession );


        }

        public virtual System.Data.DataSet BindDropDownFromTemplateDropDownId(string TemplateDropDownId)
        {
            List<Entity.FormFilling> lstConfigurationHead = new List<Entity.FormFilling>();

            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandType = CommandType.StoredProcedure;
            cmdSelect.CommandTimeout = 0;
            cmdSelect.CommandText = "dbo.LoadDropDownTemplateMasterId";
            cmdSelect.Parameters.AddWithValue("@TemplateDropDownId", TemplateDropDownId);
            return BaseSQLManager.ExecuteDataset(cmdSelect);

        }

        public virtual System.Data.DataSet LoadChildDropDownTemplateMasterId(string TemplateDropDownId,string UserId,string ConfigurationHeadId)
        {
            List<Entity.FormFilling> lstConfigurationHead = new List<Entity.FormFilling>();

            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandType = CommandType.StoredProcedure;
            cmdSelect.CommandTimeout = 0;
            cmdSelect.CommandText = "dbo.LoadChildDropDownTemplateMasterId";
            cmdSelect.Parameters.AddWithValue("@TemplateDropDownId", TemplateDropDownId);
            cmdSelect.Parameters.AddWithValue("@UserId", UserId);
            cmdSelect.Parameters.AddWithValue("@ConfigurationHeadId", ConfigurationHeadId);
            return BaseSQLManager.ExecuteDataset(cmdSelect);

        }

        public virtual System.Data.DataSet BindDropDownFromTemplateDropDownIdAndPara1(string TemplateDropDownId,string Para1)
        {
            List<Entity.FormFilling> lstConfigurationHead = new List<Entity.FormFilling>();

            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandType = CommandType.StoredProcedure;
            cmdSelect.CommandTimeout = 0;
            cmdSelect.CommandText = "dbo.BindDropDownFromTemplateDropDownIdAndPara1";
            cmdSelect.Parameters.AddWithValue("@TemplateDropDownId", TemplateDropDownId);
            cmdSelect.Parameters.AddWithValue("@Para1", Para1);
            return BaseSQLManager.ExecuteDataset(cmdSelect);

        }

        protected void FillEntityControlByForm(IDataReader dr, Entity.FormFilling ObjConfigurationHead, int Type)
        {
            ObjConfigurationHead.ConfigurationHeadName = GetField(dr, "ConfigurationHeadName");
            ObjConfigurationHead.ConfigurationHeadId = GetFieldInt64(dr, "ConfigurationHeadId");
            ObjConfigurationHead.HeadNote = GetField(dr, "HeadNote");
            ObjConfigurationHead.InputTypeId = GetFieldInt(dr, "InputTypeId");
            ObjConfigurationHead.InputType = GetField(dr, "InputType");
            ObjConfigurationHead.MinInputValue = GetField(dr, "MinInputValue");
            ObjConfigurationHead.MaxInputValue = GetField(dr, "MaxInputValue");
            ObjConfigurationHead.IsCompulsaryEntry = GetFieldBool(dr, "IsCompulsaryEntry");
            ObjConfigurationHead.TemplateDropdownMasterId = GetFieldInt64(dr, "TemplateDropdownMasterId");
            ObjConfigurationHead.TemplateDropdownName = GetField(dr, "TemplateDropdownName");
         
        }

        public virtual int DeleteFormFilling(Int32 FormID,Int32 Seqid, Int64 UserId, string HostName, string IpAddr, Int64 EventId, string TransactionId)
        {
            List<Entity.ConfigurationHead> lstConfigurationHead = new List<Entity.ConfigurationHead>();

            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.CommandType = CommandType.StoredProcedure;
            cmdDelete.CommandTimeout = 0;
            cmdDelete.CommandText = "dbo.DeleteFormFilling";
            cmdDelete.Parameters.AddWithValue("@FormID", FormID);
            cmdDelete.Parameters.AddWithValue("@UserID", UserId);
            cmdDelete.Parameters.AddWithValue("@HostName", HostName);
            cmdDelete.Parameters.AddWithValue("@IpAddr", IpAddr);
            cmdDelete.Parameters.AddWithValue("@EventId", EventId);
            cmdDelete.Parameters.AddWithValue("@TransactionId", TransactionId);
            cmdDelete.Parameters.AddWithValue("@SeqId", Seqid);
            int res = this.ExecuteNonQuery(cmdDelete);
            base.ForceCloseConnection(cmdDelete);
            return res;

        }
    }

 
}
