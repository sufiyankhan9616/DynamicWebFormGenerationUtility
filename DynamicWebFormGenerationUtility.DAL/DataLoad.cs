using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace DynamicWebFormGenerationUtility.DAL
{
    public class DataLoad : BaseSQLManager
    {
        public SqlCommand cmd;

        public void FillingDropDown(string strProc, DropDownList objDrp, ParameterCollection parCollection, string initialmsg = "--Please Select--")
        {
            try
            {

                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = strProc;
                cmd.CommandTimeout = 0;

                List<Entity.FillDropDownList> fdl = new List<Entity.FillDropDownList>();
                //loop through all properties of the ParameterCollection and add parameters for each properties into procedure   

                if (parCollection != null)
                {
                    foreach (Parameter par in parCollection)
                    {
                        cmd.Parameters.AddWithValue(par.Name, par.DefaultValue);
                    }
                }

                SqlDataReader dr = this.ExecuteDataReader(cmd);
                while (dr.Read())
                {
                    Entity.FillDropDownList objCity = new Entity.FillDropDownList();
                    fdl.Add(objCity);
                    this.FillEntityDRP(dr, objCity, 0);
                }
                base.ForceCloseConnection(cmd);
                objDrp.Items.Clear();
                objDrp.DataSource = fdl;
                objDrp.DataTextField = "ParameterText";
                objDrp.DataValueField = "ParameterValue";
                objDrp.DataBind();
                //   objDrp.SelectedIndex = 0;
                objDrp.Items.Insert(0, new ListItem(initialmsg, "0"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }

        }
        public void FillingDropDownCBL(string strProc, CheckBoxList objDrp, ParameterCollection parCollection)
        {
            try
            {

                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = strProc;
                cmd.CommandTimeout = 0;


                List<Entity.FillDropDownList> fdl = new List<Entity.FillDropDownList>();
                //loop through all properties of the ParameterCollection and add parameters for each properties into procedure   

                if (parCollection != null)
                {
                    foreach (Parameter par in parCollection)
                    {
                        cmd.Parameters.AddWithValue(par.Name, par.DefaultValue);
                    }
                }

                SqlDataReader dr = this.ExecuteDataReader(cmd);
                while (dr.Read())
                {
                    Entity.FillDropDownList objCity = new Entity.FillDropDownList();
                    fdl.Add(objCity);
                    this.FillEntityDRP(dr, objCity, 0);
                }
                base.ForceCloseConnection(cmd);
                objDrp.Items.Clear();
                objDrp.DataSource = fdl;
                objDrp.DataTextField = "ParameterText";
                objDrp.DataValueField = "ParameterValue";
                objDrp.DataBind();
                //   objDrp.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }

        }
        public void FillEntityDRP(IDataReader dr, Entity.FillDropDownList ObjCity, int Type)
        {
            ObjCity.ParameterText = GetField(dr, "ParameterText");
            ObjCity.ParameterValue = GetField(dr, "ParameterValue");

        }
        public void FillingDropDownListBox(string strProc, ListBox objDrp, ParameterCollection parCollection, string initialmsg = "--Please Select--")
        {
            try
            {

                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = strProc;
                cmd.CommandTimeout = 0;


                List<Entity.FillDropDownList> fdl = new List<Entity.FillDropDownList>();
                //loop through all properties of the ParameterCollection and add parameters for each properties into procedure   

                if (parCollection != null)
                {
                    foreach (Parameter par in parCollection)
                    {
                        cmd.Parameters.AddWithValue(par.Name, par.DefaultValue);
                    }
                }

                SqlDataReader dr = this.ExecuteDataReader(cmd);
                while (dr.Read())
                {
                    Entity.FillDropDownList objCity = new Entity.FillDropDownList();
                    fdl.Add(objCity);
                    this.FillEntityDRP(dr, objCity, 0);
                }
                base.ForceCloseConnection(cmd);
                objDrp.Items.Clear();
                objDrp.DataSource = fdl;
                objDrp.DataTextField = "ParameterText";
                objDrp.DataValueField = "ParameterValue";
                objDrp.DataBind();
                //   objDrp.SelectedIndex = 0;
                //objDrp.Items.Insert(0, new ListItem("-Please Select-", "0"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }

        }
        public DataTable GetDataTable(string strProc, ParameterCollection parCollection)
        {
            DataTable dt = new DataTable();
            try
            {

                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = strProc;
                cmd.CommandTimeout = 0;


                List<Entity.FillDropDownList> fdl = new List<Entity.FillDropDownList>();
                //loop through all properties of the ParameterCollection and add parameters for each properties into procedure   

                if (parCollection != null)
                {
                    foreach (Parameter par in parCollection)
                    {
                        cmd.Parameters.AddWithValue(par.Name, par.DefaultValue);
                    }
                }

                SqlDataReader dr = this.ExecuteDataReader(cmd);
                while (dr.Read())
                {

                    dt.Load(dr);
                }
                base.ForceCloseConnection(cmd);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }

        }

    }
}
