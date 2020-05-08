using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicWebFormGenerationUtility.BAL
{
    public class ConfigurationHeadMastermgmt
    {
        public static int AddUpdateConfigurationHead(Entity.ConfigurationHead Entity)
        {
            return new DAL.ConfigurationHeadSQL().AddUpdateConfigurationHead(Entity);
        }
        
        public static int AddUpdateHeadName(Entity.ConfigurationHead Entity)
        {
            return new DAL.ConfigurationHeadSQL().AddUpdateHeadName(Entity);
        }
        public static DataSet   Delete_QueryMaster_Data( string Queryame)
        {
            return new DAL.ConfigurationHeadSQL().Delete_QueryMaster_Data( Queryame);
        }
        public static DataSet Delete_Summary_QueryMaster_Data(string Queryame)
        {
            return new DAL.ConfigurationHeadSQL().Delete_Summary_QueryMaster_Data(Queryame);
        }
        
        public static int Insert_Summary_Query(Entity.ConfigurationHead Entity)
        {
            return new DAL.ConfigurationHeadSQL().InsertSummary_Query_Data (Entity);
        }
        public static List<Entity.ConfigurationHead> GetConfigurationHeadData(int Id, int IsActive)
        {
            return new DAL.ConfigurationHeadSQL().GetConfigurationHeadData(Id, IsActive);
        }
        public static int DeleteConfigurationHead(string Ids, int UserId, string HostName, string IpAddr, Int64 EventId, string TransactionId)
        {
            return new DAL.ConfigurationHeadSQL().DeleteConfigurationHead(Ids, UserId, HostName, IpAddr, EventId, TransactionId);
        }
        public static List<Entity.ConfigurationHead> GetDescriptionData(string Id)
        {
            return new DAL.ConfigurationHeadSQL().GetDescriptionData(Id);
        }

        public static List<Entity.ConfigurationHead> GetHeadName(string formid)
        {
            return new DAL.ConfigurationHeadSQL().GetHeadNameAndId(formid);
        }
        public static List<Entity.ConfigurationHead> GetColumnName(int QueryMasterId)
        {
            return new DAL.ConfigurationHeadSQL().Get_ColumnNameFromQueryMaster(QueryMasterId);
        }
        public static int Refresh_QueryData(string QueryString)
        {
            return new DAL.ConfigurationHeadSQL().Refresh_QueryData(QueryString);
        }

        public static DataSet GetQueryGridData(string ddlQuery)
        {
            return new DAL.ConfigurationHeadSQL().GetGridQueryData(ddlQuery);
        }

        public static DataSet Get_Summary_Query_Builder_data(string Query_Builder_id)
        {
            return new DAL.ConfigurationHeadSQL().Get_Summary_Query_Builder_data(Query_Builder_id);
        }

        

        public static DataSet getFormFillingData(string FormID,DataTable DtFilterData)
        {
            return new DAL.ConfigurationHeadSQL().getFormFillingData(FormID, DtFilterData);
        }
    }
}
