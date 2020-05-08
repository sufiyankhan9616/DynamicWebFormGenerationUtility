using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicWebFormGenerationUtility.DAL
{
  public   class InsertParameterMaster : BaseSQLManager
    {
       
        public  System.Data.DataSet InsertFormFillingMaster(Entity.ParameterMaster obj)
        {
            List<Entity.FormFilling> lstConfigurationHead = new List<Entity.FormFilling>();

            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandType = CommandType.StoredProcedure;
            cmdSelect.CommandTimeout = 0;
            cmdSelect.CommandText = "Insert_ms_FormFillingMaster";
            cmdSelect.Parameters.AddWithValue("@TemplateDropDownId", obj.TamplateDropDownId );
            cmdSelect.Parameters.AddWithValue("@BaseParameterId", obj.BaseParameterId );
            cmdSelect.Parameters.AddWithValue("@DropdownValue", obj.DropdownValue );
            cmdSelect.Parameters.AddWithValue("@CreatedBy", obj.UserId );
            cmdSelect.Parameters.AddWithValue("@TransactionId", obj.TransactionId);
            cmdSelect.Parameters.AddWithValue("@EventId", obj.EventId );
            cmdSelect.Parameters.AddWithValue("@IpAddr", obj.IpAddr );
            cmdSelect.Parameters.AddWithValue("@ParameterId", obj.ParameterId );
            return BaseSQLManager.ExecuteDataset(cmdSelect);

        }

        public virtual  List<Entity.ParameterMaster > GetFormFillingMaster(int parameterId)
        {
            List<Entity.ParameterMaster> lstConfigurationHead = new List<Entity.ParameterMaster>();
            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandType = CommandType.StoredProcedure;
            cmdSelect.CommandTimeout = 0;
            cmdSelect.CommandText = "Get_Ms_DropdownBindingData";
            cmdSelect.Parameters.AddWithValue("@ParameterId", parameterId);
            SqlDataReader dr = this.ExecuteDataReader(cmdSelect);
            while (dr.Read())
            {
                Entity.ParameterMaster objConfigurationHead = new Entity.ParameterMaster();
                lstConfigurationHead.Add(objConfigurationHead);
                this.FillEntityTemplateData(dr, objConfigurationHead, 0);
            }
            base.ForceCloseConnection(cmdSelect);
            return lstConfigurationHead;

        }
        protected void FillEntityTemplateData(IDataReader dr, Entity.ParameterMaster ObjConfigurationHead, int Type)
        {
            ObjConfigurationHead.ParameterId  = GetFieldInt(dr, "ParameterId");
            ObjConfigurationHead.ParameterName  = GetField(dr, "ParameterName");
            ObjConfigurationHead.BaseParameterName  = GetField(dr, "BaseParameterName");
            ObjConfigurationHead.CreateDate  = GetField(dr, "CreateDate");
            ObjConfigurationHead.TamplateDropDownId  = GetFieldInt(dr, "TamplateDropDownId");
            ObjConfigurationHead.BaseParameterId  = GetFieldInt(dr, "BaseParameterId");
            ObjConfigurationHead.MainParameter  = GetFieldInt(dr, "MainTemplateParameter");
        }
    }
}
