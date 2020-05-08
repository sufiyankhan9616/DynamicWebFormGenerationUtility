namespace DynamicWebFormGenerationUtility.DAL
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Configuration;
    using System.Web;


    public abstract class BaseSQLManager
    {
        internal static readonly string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        private static CultureInfo SqlServerCulture = new CultureInfo(ConfigurationManager.AppSettings["DBSQLServerLocaleSetting"]);

        protected BaseSQLManager()
        {
        }

        protected virtual void checkConnection(SqlCommand command)
        {
            command.Connection = this.getConnection();
            command.CommandTimeout = 0;
        }

        protected virtual SqlDataReader ExecuteDataReader(SqlCommand command)
        {
            this.checkConnection(command);
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        protected virtual void ExecuteDataReader(SqlCommand command, out SqlDataReader dr)
        {
            SqlParameter returnParam = new SqlParameter();
            returnParam.ParameterName = "@return";
            returnParam.Direction = ParameterDirection.ReturnValue;
            returnParam.Value = 0;
            command.Parameters.Add(returnParam);
            this.checkConnection(command);
            dr = command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public static DataSet ExecuteDataset(SqlCommand cmd)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            cmd.Connection = con;
            DataSet ds = new DataSet();
            new SqlDataAdapter(cmd).Fill(ds);
            con.Close();
            return ds;
        }

        public static DataTable ExecuteDataTable(SqlCommand cmd)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            cmd.Connection = con;
            DataTable dt = new DataTable();
            new SqlDataAdapter(cmd).Fill(dt);
            con.Close();
            return dt;
        }
        public virtual  DataSet ExecuteDataSet1(SqlCommand cmd)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            cmd.Connection = con;
            DataSet dt = new DataSet();
            new SqlDataAdapter(cmd).Fill(dt);
            con.Close();
            return dt;
        }

        protected virtual int ExecuteNonQuery(SqlCommand command)
        {
            return this.ExecuteNonQuery(command, false);
        }


        protected virtual int ExecuteNonQuery(SqlCommand command, bool blnTransaction)
        {
            SqlParameter returnParam = new SqlParameter();
            returnParam.ParameterName = "@return";
            returnParam.Direction = ParameterDirection.ReturnValue;
            returnParam.Value = 0;
            command.Parameters.Add(returnParam);
            try
            {
                this.checkConnection(command);
                if (blnTransaction)
                {
                    command.Transaction = command.Connection.BeginTransaction();
                }
                command.ExecuteNonQuery();
            }
            finally
            {
                if (((command != null) && (command.Connection != null)) && (!blnTransaction && (command.Connection.State == ConnectionState.Open)))
                {
                    command.Connection.Close();
                }
            }
            return Convert.ToInt32(command.Parameters["@return"].Value);
        }

        protected virtual object ExecuteScaler(SqlCommand command)
        {
            object objReturnValue = null;
            try
            {
                this.checkConnection(command);
                objReturnValue = command.ExecuteScalar();
            }
            //// Added By Krunal Vyas For Trial
            //catch (Exception e)
            //{
            //    objReturnValue = e.Message;
            //}
            finally
            {
                if (command.Connection.State == ConnectionState.Open)
                {
                    command.Connection.Close();
                }
            }
            return objReturnValue;
        }

        protected void ForceCloseConnection(SqlCommand command)
        {
            if (((command != null) && (command.Connection != null)) && (command.Connection.State == ConnectionState.Open))
            {
                command.Connection.Close();
            }
        }

        private SqlConnection getConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public static string GetField(IDataReader rs, string fieldname)
        {
            int idx = rs.GetOrdinal(fieldname);
            if (rs.IsDBNull(idx))
            {
                return string.Empty;
            }

            return rs.GetString(idx);
        }

        public static bool GetFieldBool(IDataReader rs, string fieldname)
        {
            int idx = rs.GetOrdinal(fieldname);
            if (rs.IsDBNull(idx))
            {
                return false;
            }
            string s = rs[fieldname].ToString();
            return ((s.Equals("TRUE", StringComparison.InvariantCultureIgnoreCase) || s.Equals("YES", StringComparison.InvariantCultureIgnoreCase)) || s.Equals("1", StringComparison.InvariantCultureIgnoreCase));
        }

        public static byte GetFieldByte(IDataReader rs, string fieldname)
        {
            int idx = rs.GetOrdinal(fieldname);
            if (rs.IsDBNull(idx))
            {
                return 0;
            }
            return rs.GetByte(idx);
        }

        public static DateTime GetFieldDateTime(IDataReader rs, string fieldname)
        {
            int idx = rs.GetOrdinal(fieldname);
            if (rs.IsDBNull(idx))
            {
                return DateTime.MinValue;
            }
            return Convert.ToDateTime(rs[idx], SqlServerCulture);
        }

        public static decimal GetFieldDecimal(IDataReader rs, string fieldname)
        {
            int idx = rs.GetOrdinal(fieldname);
            if (rs.IsDBNull(idx))
            {
                return 0M;
            }
            return rs.GetDecimal(idx);
        }

        public static double GetFieldDouble(IDataReader rs, string fieldname)
        {
            int idx = rs.GetOrdinal(fieldname);
            if (rs.IsDBNull(idx))
            {
                return 0.0;
            }
            return rs.GetDouble(idx);
        }

        public static string GetFieldGUID(IDataReader rs, string fieldname)
        {
            int idx = rs.GetOrdinal(fieldname);
            if (rs.IsDBNull(idx))
            {
                return string.Empty;
            }
            return rs.GetGuid(idx).ToString();
        }

        public static Guid GetFieldGUID2(IDataReader rs, string fieldname)
        {
            int idx = rs.GetOrdinal(fieldname);
            if (rs.IsDBNull(idx))
            {
                return new Guid("00000000000000000000000000000000");
            }
            return rs.GetGuid(idx);
        }

        public static int GetInt16(IDataReader rs, string fieldname)
        {
            int idx = rs.GetOrdinal(fieldname);
            if (rs.IsDBNull(idx))
            {
                return 0;
            }
            return rs.GetInt16(idx);
        }

        public static int GetFieldInt(IDataReader rs, string fieldname)
        {
            int idx = rs.GetOrdinal(fieldname);
            if (rs.IsDBNull(idx))
            {
                return 0;
            }
            return rs.GetInt32(idx);
        }

        public static long GetFieldInt64(IDataReader rs, string fieldname)
        {
            int idx = rs.GetOrdinal(fieldname);
            if (rs.IsDBNull(idx))
            {
                return 0L;
            }
            return rs.GetInt64(idx);
        }

        public static long GetFieldLong(IDataReader rs, string fieldname)
        {
            int idx = rs.GetOrdinal(fieldname);
            if (rs.IsDBNull(idx))
            {
                return 0L;
            }
            return rs.GetInt64(idx);
        }

        public static float GetFieldSingle(IDataReader rs, string fieldname)
        {
            int idx = rs.GetOrdinal(fieldname);
            if (rs.IsDBNull(idx))
            {
                return 0f;
            }
            return (float)rs.GetDouble(idx);
        }

        public static int GetFieldTinyInt(IDataReader rs, string fieldname)
        {
            int ni;
            int idx = rs.GetOrdinal(fieldname);
            if (rs.IsDBNull(idx))
            {
                return 0;
            }
            int.TryParse(rs[idx].ToString(), NumberStyles.Integer, Thread.CurrentThread.CurrentUICulture, out ni);
            return ni;
        }

        public static string GetTextonly(string details)
        {
            return Regex.Replace(details, @"<(.|\n)*?>", string.Empty).Replace("\r", "").Replace("\n", "").Replace("<", "").Replace("&nbsp;", "");
        }
    }
}
