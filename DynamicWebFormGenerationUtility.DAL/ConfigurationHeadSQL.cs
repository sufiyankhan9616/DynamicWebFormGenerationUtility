using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicWebFormGenerationUtility.DAL
{
    public class ConfigurationHeadSQL : BaseSQLManager
    {
        public virtual int AddUpdateConfigurationHead(Entity.ConfigurationHead Entity)
        {
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.CommandType = CommandType.StoredProcedure;
            cmdInsert.CommandTimeout = 0;
            cmdInsert.CommandText = "dbo.AddUpdateConfigurationHead";
            this.FillParamsDetails(cmdInsert.Parameters, Entity);
            int res = this.ExecuteNonQuery(cmdInsert);
            base.ForceCloseConnection(cmdInsert);
            return res;

        }
        public virtual   DataSet  Delete_QueryMaster_Data(string  QueryMasterId )
        {
           
            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.CommandType = CommandType.StoredProcedure;
            cmdDelete.CommandTimeout = 0;
            cmdDelete.CommandText = "dbo.Delete_QueryMaster_Data";
            cmdDelete.Parameters.AddWithValue("@QueryMaster_id", QueryMasterId);
            DataSet  res = BaseSQLManager.ExecuteDataset(cmdDelete);
            base.ForceCloseConnection(cmdDelete);
            return res;

        }
        public virtual DataSet Delete_Summary_QueryMaster_Data(string QueryMasterId)
        {

            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.CommandType = CommandType.StoredProcedure;
            cmdDelete.CommandTimeout = 0;
            cmdDelete.CommandText = "dbo.Delete_SummaryQueryMaster_Data";
            cmdDelete.Parameters.AddWithValue("@Query_Summary_Builder_id", QueryMasterId);
            DataSet res = BaseSQLManager.ExecuteDataset(cmdDelete);
            base.ForceCloseConnection(cmdDelete);
            return res;

        }

        public void FillParamsDetails(SqlParameterCollection parameters, Entity.ConfigurationHead Entity)
        {
            parameters.AddWithValue("@ConfigurationHeadId", Entity.ConfigurationHeadId);
            parameters.AddWithValue("@ConfigurationHeadName", Entity.ConfigurationHeadName);
            parameters.AddWithValue("@HeadNote", Entity.HeadNote);
            parameters.AddWithValue("@DisplayPreferenceNo", Entity.DisplayPreferenceNo);
            parameters.AddWithValue("@InputTypeId", Entity.InputTypeId);
            parameters.AddWithValue("@MinInputValue", Entity.MinInputValue);
            parameters.AddWithValue("@MaxInputValue", Entity.MaxInputValue);
            parameters.AddWithValue("@IsCompulsaryEntry", Entity.IsCompulsaryEntry);
            parameters.AddWithValue("@TemplateDropdownMasterId", Entity.TemplateDropdownMasterId);
            parameters.AddWithValue("@Remark", Entity.Remark);
            parameters.AddWithValue("@UserId", Entity.UserId);
            parameters.AddWithValue("@HostName", Entity.HostName);
            parameters.AddWithValue("@IpAddr", Entity.IpAddr);
            parameters.AddWithValue("@EventId", Entity.EventId);
            parameters.AddWithValue("@TransactionId", Entity.TransactionId);
            parameters.AddWithValue("@ChildDBId", Entity.ChildDBId);
            parameters.AddWithValue("@MaxLength", Entity.MaxLength);
            parameters.AddWithValue("@FormId", Entity.FormId);
            parameters.AddWithValue("@IsUniqueKey", Entity.IsUniqueKey);
            parameters.AddWithValue("@IsCompositeUniqueKey", Entity.IsCompositeUniqueKey);
            parameters.AddWithValue("@FormComponentMasterId", Entity.FormComponentMasterId);
            parameters.AddWithValue("@RegexMasterId", Entity.RegexMasterId);
            parameters.AddWithValue("@IsSearchableDropDown", Entity.IsSearchableDropdown );


        }


        public virtual List<Entity.ConfigurationHead> GetConfigurationHeadData(int Id, int IsActive)
        {
            List<Entity.ConfigurationHead> lstConfigurationHead = new List<Entity.ConfigurationHead>();

            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandType = CommandType.StoredProcedure;
            cmdSelect.CommandTimeout = 0;
            cmdSelect.CommandText = "dbo.GetConfigurationHeadData";
            cmdSelect.Parameters.AddWithValue("@Id", Id);
            cmdSelect.Parameters.AddWithValue("@IsActive", IsActive);
            SqlDataReader dr = this.ExecuteDataReader(cmdSelect);
            while (dr.Read())
            {
                Entity.ConfigurationHead objConfigurationHead = new Entity.ConfigurationHead();
                lstConfigurationHead.Add(objConfigurationHead);
                this.FillEntityConfigurationHead(dr, objConfigurationHead, 0);
            }
            base.ForceCloseConnection(cmdSelect);
            return lstConfigurationHead;
        }


        protected void FillEntityConfigurationHead(IDataReader dr, Entity.ConfigurationHead ObjConfigurationHead, int Type)
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
            ObjConfigurationHead.Remark = GetField(dr, "Remark");
            ObjConfigurationHead.DisplayPreferenceNo = GetFieldDecimal(dr, "DisplayPreferenceNo");
            ObjConfigurationHead.FormId = GetFieldInt(dr, "FormId");
            ObjConfigurationHead.FormTitle = GetField(dr, "FormTitle");
            ObjConfigurationHead.MaxLength = GetFieldInt(dr, "MaxLength");
            ObjConfigurationHead.ChildDBId = GetFieldInt64(dr, "ChildDBId");
            ObjConfigurationHead.FormComponentMasterId = GetFieldInt64(dr, "FormComponentMasterId");
            ObjConfigurationHead.RegexMasterId = GetFieldInt(dr, "RegexMasterId");
             ObjConfigurationHead.FormName  = GetField(dr, "FormName");
            ObjConfigurationHead.IsUniqueKey = GetFieldBool(dr, "IsUniqueKey");
            ObjConfigurationHead.IsCompositeUniqueKey = GetFieldBool(dr, "IsCompositeUniqueKey");
            ObjConfigurationHead.IsSearchableDropdown  = GetFieldBool(dr, "IsSearchableDropDown");

        }
        public virtual int DeleteConfigurationHead(string Ids, int UserId, string HostName, string IpAddr, Int64 EventId, string TransactionId)
        {
            List<Entity.ConfigurationHead> lstConfigurationHead = new List<Entity.ConfigurationHead>();
            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.CommandType = CommandType.StoredProcedure;
            cmdDelete.CommandTimeout = 0;
            cmdDelete.CommandText = "dbo.DeleteConfigurationHead";
            cmdDelete.Parameters.AddWithValue("@Ids", Ids);
            cmdDelete.Parameters.AddWithValue("@UserID", UserId);
            cmdDelete.Parameters.AddWithValue("@HostName", HostName);
            cmdDelete.Parameters.AddWithValue("@IpAddr", IpAddr);
            cmdDelete.Parameters.AddWithValue("@EventId", EventId);
            cmdDelete.Parameters.AddWithValue("@TransactionId", TransactionId);
            int res = this.ExecuteNonQuery(cmdDelete);
            base.ForceCloseConnection(cmdDelete);
            return res;

        }
        public virtual List<Entity.ConfigurationHead> GetDescriptionData(string Id)
        {
            List<Entity.ConfigurationHead> lstDescription = new List<Entity.ConfigurationHead>();
            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandType = CommandType.StoredProcedure;
            cmdSelect.CommandTimeout = 0;
            cmdSelect.CommandText = "dbo.GetDescriptionData";
            cmdSelect.Parameters.AddWithValue("@Id", Id);

            SqlDataReader dr = this.ExecuteDataReader(cmdSelect);
            while (dr.Read())
            {
                Entity.ConfigurationHead objConfigurationHead = new Entity.ConfigurationHead();
                lstDescription.Add(objConfigurationHead);
                this.FillDescriptionData(dr, objConfigurationHead, 0);
            }
            base.ForceCloseConnection(cmdSelect);
            return lstDescription;
        }
        protected void FillDescriptionData(IDataReader dr, Entity.ConfigurationHead ObjConfigurationHead, int Type)
        {

            ObjConfigurationHead.Description = GetField(dr, "Description");

        }
        public virtual int AddUpdateHeadName(Entity.ConfigurationHead Entity)
        {
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.CommandType = CommandType.StoredProcedure;
            cmdInsert.CommandTimeout = 0;
            cmdInsert.CommandText = "dbo.Insert_ms_NewQueryGenerationForm";
            this.HeadParamsDetails(cmdInsert.Parameters, Entity);
            int res = this.ExecuteNonQuery(cmdInsert);
            base.ForceCloseConnection(cmdInsert);
            return res;

        }
        public virtual int InsertSummary_Query_Data(Entity.ConfigurationHead Entity)
        {
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.CommandType = CommandType.StoredProcedure;
            cmdInsert.CommandTimeout = 0;
            cmdInsert.CommandText = "dbo.Inert_Ms_Summary_Query_Builder";
            this.Summary_QueryDetails(cmdInsert.Parameters, Entity);
            int res = this.ExecuteNonQuery(cmdInsert);
            base.ForceCloseConnection(cmdInsert);
            return res;

        }
        public void Summary_QueryDetails(SqlParameterCollection parameters, Entity.ConfigurationHead Entity)
        {
            parameters.AddWithValue("@TableName", Entity.TableName);
            parameters.AddWithValue("@Summary_Query_Data", Entity.dtQuerydata);
            parameters.AddWithValue("@Query", Entity.QueryName);
            parameters.AddWithValue("@QueryDisplayText", Entity.QueryDisplayText);
            parameters.AddWithValue("@QueryMasterid", Entity.QueryMasterId );
        }

        public void HeadParamsDetails(SqlParameterCollection parameters, Entity.ConfigurationHead Entity)
        {
            parameters.AddWithValue("@QueryName", Entity.QueryName);
            parameters.AddWithValue("@FormID", Entity.FormName);
            parameters.AddWithValue("@StrColumnsid", Entity.ColumnsId);
            parameters.AddWithValue("@StrColumnsName", Entity.ColumnsName);
            parameters.AddWithValue("@HostName", Entity.HostName);
            parameters.AddWithValue("@IpAddr", Entity.IpAddr);
            //parameters.AddWithValue("@EventId", Entity.EventId );
            parameters.AddWithValue("@ConditionString", Entity.ConditionString);
            parameters.AddWithValue("@UserId", Entity.UserId);

        }

        public virtual List<Entity.ConfigurationHead> GetHeadNameAndId(string formid)
        {
            List<Entity.ConfigurationHead> lstConfigurationHead = new List<Entity.ConfigurationHead>();

            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandType = CommandType.StoredProcedure;
            cmdSelect.CommandTimeout = 0;
            cmdSelect.CommandText = "dbo.GetHeaderName_ID";
            cmdSelect.Parameters.AddWithValue("@formid", formid);
            SqlDataReader dr = this.ExecuteDataReader(cmdSelect);
            while (dr.Read())
            {
                Entity.ConfigurationHead objConfigurationHead = new Entity.ConfigurationHead();
                lstConfigurationHead.Add(objConfigurationHead);
                this.FillEntityHeadName_ID(dr, objConfigurationHead, 0);
            }
            base.ForceCloseConnection(cmdSelect);
            return lstConfigurationHead;
        }
        public virtual List<Entity.ConfigurationHead> Get_ColumnNameFromQueryMaster(Int32 QueryMasterId)
        {
            List<Entity.ConfigurationHead> lstConfigurationHead = new List<Entity.ConfigurationHead>();

            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandType = CommandType.StoredProcedure;
            cmdSelect.CommandTimeout = 0;
            cmdSelect.CommandText = "dbo.Get_ColumnNameFromQueryMaster";
            cmdSelect.Parameters.AddWithValue("@QueryMasterId", QueryMasterId);
            SqlDataReader dr = this.ExecuteDataReader(cmdSelect);
            while (dr.Read())
            {
                Entity.ConfigurationHead objConfigurationHead = new Entity.ConfigurationHead();
                lstConfigurationHead.Add(objConfigurationHead);
                this.FillEntityHeadName_ID(dr, objConfigurationHead, 0);
            }
            base.ForceCloseConnection(cmdSelect);
            return lstConfigurationHead;
        }
        public virtual int Refresh_QueryData(string QueryName)
        {
            List<Entity.ConfigurationHead> lstConfigurationHead = new List<Entity.ConfigurationHead>();

            SqlCommand cmdQuery = new SqlCommand();
            cmdQuery.CommandType = CommandType.StoredProcedure;
            cmdQuery.CommandTimeout = 0;
            cmdQuery.CommandText = "dbo.Refresh_QueryGenerated";
            cmdQuery.Parameters.AddWithValue("@QueryName", QueryName);
            int res = this.ExecuteNonQuery(cmdQuery);
            base.ForceCloseConnection(cmdQuery);
            return res;
        }
        protected void FillEntityHeadName_ID(IDataReader dr, Entity.ConfigurationHead ObjConfigurationHead, int Type)
        {
            ObjConfigurationHead.ConfigurationHeadName = GetField(dr, "ConfigurationHeadName");
            ObjConfigurationHead.ConfigurationHeadId = GetFieldInt64(dr, "ConfigurationHeadId");
            ObjConfigurationHead.InputTypeId = GetFieldInt(dr, "InputTypeId");
        }

        public virtual DataSet GetGridQueryData(string ddlQueryName)
        {
            List<Entity.ConfigurationHead> lstConfigurationHead = new List<Entity.ConfigurationHead>();

            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandType = CommandType.StoredProcedure;
            cmdSelect.CommandTimeout = 0;
            cmdSelect.CommandText = "dbo.GetQueryFormData";
            cmdSelect.Parameters.AddWithValue("@QueryMasterName", ddlQueryName);
            return BaseSQLManager.ExecuteDataset(cmdSelect);

        }

        public virtual DataSet Get_Summary_Query_Builder_data(string Query_Builder_id)
        {
            List<Entity.ConfigurationHead> lstConfigurationHead = new List<Entity.ConfigurationHead>();

            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandType = CommandType.StoredProcedure;
            cmdSelect.CommandTimeout = 0;
            cmdSelect.CommandText = "dbo.Get_Summary_Query_Builder";
            cmdSelect.Parameters.AddWithValue("@table_id ", Query_Builder_id);
            return BaseSQLManager.ExecuteDataset(cmdSelect);
        }

        public virtual DataSet getFormFillingData(string FormID, DataTable DtFilterData)
        {
            List<Entity.ConfigurationHead> lstConfigurationHead = new List<Entity.ConfigurationHead>();

            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandType = CommandType.StoredProcedure;
            cmdSelect.CommandTimeout = 0;
            cmdSelect.CommandText = "dbo.getFormFillingData";
            cmdSelect.Parameters.AddWithValue("@FormID", FormID);
            cmdSelect.Parameters.AddWithValue("@Udt_FilterFormFillingTable", DtFilterData);
            return BaseSQLManager.ExecuteDataset(cmdSelect);

        }


    }
}
