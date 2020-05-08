using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicWebFormGenerationUtility.DAL
{
    public class ErrorSQL : BaseSQLManager
    {
        public virtual int AddUpdateError(Entity.Error Entity)
        {
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.CommandType = CommandType.StoredProcedure;
            cmdInsert.CommandText = "AddUpdateError";
            this.FillParamsDetails(cmdInsert.Parameters, Entity);
            int res = this.ExecuteNonQuery(cmdInsert);
            base.ForceCloseConnection(cmdInsert);
            return res;

        }
        public void FillParamsDetails(SqlParameterCollection parameters, Entity.Error Entity)
        {
            parameters.AddWithValue("@ErrorId", Entity.ErrorId);
            parameters.AddWithValue("@Message", Entity.Message);
            parameters.AddWithValue("@IpAddress", Entity.IpAddress);
            parameters.AddWithValue("@Source", Entity.Source);
            parameters.AddWithValue("@UserName", Entity.UserName);
            parameters.AddWithValue("@Browser", Entity.Browser);
        }


        public virtual List<Entity.Error> GetErrorData(int Id)
        {
            List<Entity.Error> lstError = new List<Entity.Error>();
            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandType = CommandType.StoredProcedure;
            cmdSelect.CommandText = "GetErrorData";
            cmdSelect.Parameters.AddWithValue("@Id", Id);
            SqlDataReader dr = this.ExecuteDataReader(cmdSelect);
            while (dr.Read())
            {
                Entity.Error objError = new Entity.Error();
                lstError.Add(objError);
                this.FillEntityError(dr, objError, 0);
            }
            base.ForceCloseConnection(cmdSelect);
            return lstError;
        }


        protected void FillEntityError(IDataReader dr, Entity.Error ObjError, int Type)
        {

            ObjError.ErrorId = GetFieldInt(dr, "ErrorId");
            ObjError.Message = GetField(dr, "Message");
            ObjError.Source = GetField(dr, "Source");
            ObjError.UserName = GetField(dr, "UserName");
            ObjError.IpAddress = GetField(dr, "IpAddress");
            ObjError.Browser = GetField(dr, "Browser");
            ObjError.ErrorDate = GetFieldDateTime(dr, "ErrorDate");
        }
        public virtual int DeleteError(string Ids, int UserId)
        {
            List<Entity.Error> lstError = new List<Entity.Error>();

            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.CommandType = CommandType.StoredProcedure;
            cmdDelete.CommandText = "DeleteError";
            cmdDelete.Parameters.AddWithValue("@Ids", Ids);
            cmdDelete.Parameters.AddWithValue("@UserID", UserId);
            int res = this.ExecuteNonQuery(cmdDelete);
            base.ForceCloseConnection(cmdDelete);
            return res;

        }

    }
}
