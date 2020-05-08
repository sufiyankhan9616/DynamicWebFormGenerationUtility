using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DynamicWebFormGenerationUtility.DAL
{
    public class TemplateMasterSQL : BaseSQLManager
    {
        public virtual int AddUpdateTemplateMaster(Entity.TemplateMaster Entity)
        {
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.CommandType = CommandType.StoredProcedure;
            cmdInsert.CommandTimeout = 0;
            cmdInsert.CommandText = "dbo.AddUpdateTemplateMaster";
            this.FillTemplateMasterParams(cmdInsert.Parameters, Entity);
            int res = this.ExecuteNonQuery(cmdInsert);
            base.ForceCloseConnection(cmdInsert);
            return res;
        }

        public void FillTemplateMasterParams(SqlParameterCollection parameters, Entity.TemplateMaster Entity)
        {
            parameters.AddWithValue("@TemplateDropDownId", Entity.TemplateDropDownId);
            parameters.AddWithValue("@TemplateDropdownName", Entity.TemplateDropdownName);
            //parameters.AddWithValue("@CreatedBy", Entity.CreatedBy);
            parameters.AddWithValue("@UserId", Entity.UserId);
            parameters.AddWithValue("@HostName", Entity.HostName);
            parameters.AddWithValue("@IpAddr", Entity.IpAddr);
            parameters.AddWithValue("@EventId", Entity.EventId);
            parameters.AddWithValue("@TransactionId", Entity.TransactionId);
        }

        public virtual List<Entity.TemplateMaster> GetTemplateMasterData(int Id, int IsActive)
        {
            List<Entity.TemplateMaster> lstConfigurationHead = new List<Entity.TemplateMaster>();

            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandType = CommandType.StoredProcedure;
            cmdSelect.CommandTimeout = 0;
            cmdSelect.CommandText = "dbo.Get_TemplateMasterData";
            cmdSelect.Parameters.AddWithValue("@Id", Id);
            cmdSelect.Parameters.AddWithValue("@IsActive", IsActive);
            SqlDataReader dr = this.ExecuteDataReader(cmdSelect);
            while (dr.Read())
            {
                Entity.TemplateMaster objConfigurationHead = new Entity.TemplateMaster();
                lstConfigurationHead.Add(objConfigurationHead);
                this.FillEntityTemplateData(dr, objConfigurationHead, 0);
            }
            base.ForceCloseConnection(cmdSelect);
            return lstConfigurationHead;
        }

        protected void FillEntityTemplateData(IDataReader dr, Entity.TemplateMaster ObjConfigurationHead, int Type)
        {
            ObjConfigurationHead.TemplateDropDownId = GetFieldInt(dr, "TemplateDropDownId");
            ObjConfigurationHead.TemplateDropdownName = GetField(dr, "TemplateDropdownName");
        }

        public virtual int DeleteTemplateMaster(string TemplateDropDownId, int EventId, String transactionId,string IpAddress,String MacAddress)
        {
            List<Entity.ConfigurationHead> lstConfigurationHead = new List<Entity.ConfigurationHead>();
            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.CommandType = CommandType.StoredProcedure;
            cmdDelete.CommandTimeout = 0;
            cmdDelete.CommandText = "dbo.DeleteTemplateMaster";
            cmdDelete.Parameters.AddWithValue("@TemplateDropDownIds", TemplateDropDownId);
            cmdDelete.Parameters.AddWithValue("@HostName", MacAddress);
            cmdDelete.Parameters.AddWithValue("@IpAddr", IpAddress);
            cmdDelete.Parameters.AddWithValue("@EventId", EventId);
            cmdDelete.Parameters.AddWithValue("@TransactionId", transactionId);
            int res = this.ExecuteNonQuery(cmdDelete);
            base.ForceCloseConnection(cmdDelete);
            return res;

        }
    }
}
