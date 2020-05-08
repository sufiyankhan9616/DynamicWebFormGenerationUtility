using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicWebFormGenerationUtility.DAL
{
    public class FormMasterSQL : BaseSQLManager
    {
        public virtual int AddUpdateFormMaster(Entity.FormMaster Entity)
        {
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.CommandType = CommandType.StoredProcedure;
            cmdInsert.CommandTimeout = 0;
            cmdInsert.CommandText = "dbo.AddUpdateFormMaster";
            this.FillParamsDetails(cmdInsert.Parameters, Entity);
            int res = this.ExecuteNonQuery(cmdInsert);
            base.ForceCloseConnection(cmdInsert);
            return res;
        }
       
        public virtual int AddUpdateRegexMaster(Entity.RegexMasterEntitycs  Entity)
        {
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.CommandType = CommandType.StoredProcedure;
            cmdInsert.CommandTimeout = 0;
            cmdInsert.CommandText = "dbo.Insert_Update_RegexMasterDetails";
            this.FillRegexParamsDetails(cmdInsert.Parameters, Entity);
            int res = this.ExecuteNonQuery(cmdInsert);
            base.ForceCloseConnection(cmdInsert);
            return res;
        }
        public virtual DataSet FreezFormMaster(Entity.FormMaster Entity)
        {
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.CommandType = CommandType.StoredProcedure;
            cmdInsert.CommandTimeout = 0;
            cmdInsert.CommandText = "dbo.UpdateFreezdata";
            this.FillParamsFreezDetails(cmdInsert.Parameters, Entity);
            DataSet res = this.ExecuteDataSet1(cmdInsert);
            base.ForceCloseConnection(cmdInsert);
            return res;
        }
        public void FillParamsFreezDetails(SqlParameterCollection parameters, Entity.FormMaster Entity)
        {
            parameters.AddWithValue("@IsFreez", Entity.Is_Freez );
            parameters.AddWithValue("@Form_id", Entity.FormId);

        }
        public void FillRegexParamsDetails(SqlParameterCollection parameters, Entity.RegexMasterEntitycs  Entity)
        {
            parameters.AddWithValue("@RegexMasterId", Entity.RegexId );
            parameters.AddWithValue("@ValidationName", Entity.ValidationName);
            parameters.AddWithValue("@ErrMsg", Entity.ErrMsg );
            parameters.AddWithValue("@ValidationExp", Entity.ValidationExp );
            parameters.AddWithValue("@IpAddr", Entity.IpAddr );
            parameters.AddWithValue("@HostName", Entity.HostName);
            parameters.AddWithValue("@UserId", Entity.UserId);
            parameters.AddWithValue("@TransactionId", Entity.TransactionId );
            parameters.AddWithValue("@EventId", Entity.EventId );
            parameters.AddWithValue("@IsDeleted", Entity.Isdelete );
     
        }
        public void FillParamsDetails(SqlParameterCollection parameters, Entity.FormMaster Entity)
        {
            parameters.AddWithValue("@FormId", Entity.FormId);
            parameters.AddWithValue("@FormName", Entity.FormName);
            parameters.AddWithValue("@FormTitle", Entity.FormTitle);
            parameters.AddWithValue("@Remarks", Entity.Remarks);
            parameters.AddWithValue("@UserId", Entity.UserId);
            parameters.AddWithValue("@HostName", Entity.HostName);
            parameters.AddWithValue("@IpAddr", Entity.IpAddr);
            parameters.AddWithValue("@EventId", Entity.EventId);
            parameters.AddWithValue("@TransactionId", Entity.TransactionId);
            parameters.AddWithValue("@RefFormId", Entity.RefFormId);
            parameters.AddWithValue("@DtComponent", Entity.DtComponent );
        }

        public virtual List<Entity.FormMaster> GetFormMasterData(int Id, int IsActive)
        {
            List<Entity.FormMaster> lstConfigurationHead = new List<Entity.FormMaster>();

            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandType = CommandType.StoredProcedure;
            cmdSelect.CommandTimeout = 0;
            cmdSelect.CommandText = "dbo.GetFormMasterData";
            cmdSelect.Parameters.AddWithValue("@Id", Id);
            cmdSelect.Parameters.AddWithValue("@IsActive", IsActive);
            SqlDataReader dr = this.ExecuteDataReader(cmdSelect);
            while (dr.Read())
            {
                Entity.FormMaster objConfigurationHead = new Entity.FormMaster();
                lstConfigurationHead.Add(objConfigurationHead);
                this.FillEntityFormData(dr, objConfigurationHead, 0);
            }
            base.ForceCloseConnection(cmdSelect);
            return lstConfigurationHead;
        }
        public virtual List<Entity.RegexMasterEntitycs > GetRegexMasterData(int Id)
        {
            List<Entity.RegexMasterEntitycs > lstConfigurationHead = new List<Entity.RegexMasterEntitycs>();

            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandType = CommandType.StoredProcedure;
            cmdSelect.CommandTimeout = 0;
            cmdSelect.CommandText = "dbo.GetRegexMasterData";
            cmdSelect.Parameters.AddWithValue("@Id", Id);
            SqlDataReader dr = this.ExecuteDataReader(cmdSelect);
            while (dr.Read())
            {
                Entity.RegexMasterEntitycs objConfigurationHead = new Entity.RegexMasterEntitycs();
                lstConfigurationHead.Add(objConfigurationHead);
                this.FillEntityRegexData(dr, objConfigurationHead, 0);
            }
            base.ForceCloseConnection(cmdSelect);
            return lstConfigurationHead;
        }
        public virtual DataTable  GetFormComponentData(int Id, int IsActive)
        {
            DataTable dt = new DataTable();

            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandType = CommandType.StoredProcedure;
            cmdSelect.CommandTimeout = 0;
            cmdSelect.CommandText = "dbo.GetComponentMasterData";
            cmdSelect.Parameters.AddWithValue("@Id", Id);
            cmdSelect.Parameters.AddWithValue("@IsActive", IsActive);
            return BaseSQLManager.ExecuteDataTable (cmdSelect);
        }
        protected void FillEntityComponentData(IDataReader dr, Entity.FormMaster ObjConfigurationHead, int Type)
        {
            ObjConfigurationHead.FormComponentMasterId  = GetFieldInt(dr, "id");
            ObjConfigurationHead.ComponentName  = GetField(dr, "ComponentName");
            ObjConfigurationHead.ComponentSeqNo   = GetFieldDecimal (dr, "ComponentSeqNo");
           
        }
        protected void FillEntityRegexData(IDataReader dr, Entity.RegexMasterEntitycs ObjRegex, int Type)
        {
            ObjRegex.RegexId   = GetFieldInt(dr, "regexMasterId");
            ObjRegex.ValidationName  = GetField(dr, "RegexValidationName");
            ObjRegex.ValidationExp  = GetField(dr, "RegexvalidationExpression");
            ObjRegex.ErrMsg  = GetField(dr, "ErrorMessage");
        }
        protected void FillEntityFormData(IDataReader dr, Entity.FormMaster ObjConfigurationHead, int Type)
        {
            ObjConfigurationHead.FormId = GetFieldInt(dr, "FormId");
            ObjConfigurationHead.FormTitle = GetField(dr, "FormTitle");
            ObjConfigurationHead.FormName = GetField(dr, "FormName");
            ObjConfigurationHead.Remarks = GetField(dr, "Remarks");
            ObjConfigurationHead.Is_Freez = GetField(dr, "IsFreez");
        }

        public virtual int DeleteFormMaster(string Ids, int UserId, string HostName, string IpAddr, Int64 EventId, string TransactionId)
        {
            List<Entity.ConfigurationHead> lstConfigurationHead = new List<Entity.ConfigurationHead>();

            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.CommandType = CommandType.StoredProcedure;
            cmdDelete.CommandTimeout = 0;
            cmdDelete.CommandText = "dbo.DeleteFormMaster";
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
        public virtual int DeleteRegexMaster(string Ids, int UserId, string HostName, string IpAddr, Int64 EventId, string TransactionId)
        {

            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.CommandType = CommandType.StoredProcedure;
            cmdDelete.CommandTimeout = 0;
            cmdDelete.CommandText = "dbo.DeleteRegexMaster";
            cmdDelete.Parameters.AddWithValue("@RegexIds", Ids);
            cmdDelete.Parameters.AddWithValue("@UserID", UserId);
            cmdDelete.Parameters.AddWithValue("@HostName", HostName);
            cmdDelete.Parameters.AddWithValue("@IpAddr", IpAddr);
            cmdDelete.Parameters.AddWithValue("@EventId", EventId);
            cmdDelete.Parameters.AddWithValue("@TransactionId", TransactionId);
            int res = this.ExecuteNonQuery(cmdDelete);
            base.ForceCloseConnection(cmdDelete);
            return res;

        }
        public virtual int AddSessionLog(Entity.FormMaster Entity)
        {
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.CommandType = CommandType.StoredProcedure;
            cmdInsert.CommandTimeout = 0;
            cmdInsert.CommandText = "dbo.Sp_Insert_Session_Login";
            this.FillSessionLogParamsDetails(cmdInsert.Parameters, Entity);
            int res = this.ExecuteNonQuery(cmdInsert);
            base.ForceCloseConnection(cmdInsert);
            return res;
        }
        public void FillSessionLogParamsDetails(SqlParameterCollection parameters, Entity.FormMaster Entity)
        {
            parameters.AddWithValue("@FormId", Entity.FormId);
            parameters.AddWithValue("@DistName", Entity.DistName);
            parameters.AddWithValue("@TalName", Entity.TalName);
            parameters.AddWithValue("@OfficeName", Entity.OfficeName);
            parameters.AddWithValue("@OtherSession", Entity.OtherSession);
            parameters.AddWithValue("@HostName", Entity.HostName);
            parameters.AddWithValue("@IpAddr", Entity.IpAddr);
            parameters.AddWithValue("@userName", Entity.UserName  );
            parameters.AddWithValue("@userid", Entity.UserId);
            parameters.AddWithValue("@RoleName", Entity.RoleName);
            parameters.AddWithValue("@RoleId", Entity.Roleid);
        }
    }
}
