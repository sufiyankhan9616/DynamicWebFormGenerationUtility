using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicWebFormGenerationUtility.DAL
{
    public class SMTPConfigSQL : BaseSQLManager
    {
        public DataTable GetSMTPSetting()
        {
            DataTable dt = new DataTable();
            SqlCommand cmdselect = new SqlCommand();
            cmdselect.CommandType = CommandType.StoredProcedure;
            cmdselect.CommandText = "GetSMTPSetting";
            dt = ExecuteDataTable(cmdselect);
            return dt;
        }
    }
}
