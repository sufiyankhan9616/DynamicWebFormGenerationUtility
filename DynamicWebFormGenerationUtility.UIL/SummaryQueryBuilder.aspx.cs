using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DynamicWebFormGenerationUtility.Common;

namespace DynamicWebFormGenerationUtility.UIL
{
    public partial class SummaryQueryBuilder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadFormName();
             
            }

        }
        private void clear()
        {
            
            GetColumnName();
            LoadFormName();
            txtQueryName.Text = string.Empty;
            LoadColumnName();
        }
        void LoadColumnName()
        {
            BAL.FillDropdown bfd = new BAL.FillDropdown();
            bfd.LoadColumnname(ddlColumn,ddlFormname .SelectedValue );
        }
        void LoadSummaryQueryDropdown()
        {
            BAL.FillDropdown bfd = new BAL.FillDropdown();
            bfd.LoadSummaryQueryDropdown(ddlQuery);
        }

        void GetColumnName()
        {
            List<Entity.ConfigurationHead> lst = new List<Entity.ConfigurationHead>();
            lst = BAL.ConfigurationHeadMastermgmt.GetColumnName(Convert.ToInt32(ddlColumn.SelectedValue));
            BindData(lst);
        }
        void BindData(List<Entity.ConfigurationHead> lst)
        {
            lstSummaryQueryBuilder.DataSource = lst;
            lstSummaryQueryBuilder.DataBind();

        }
        public DataTable BindChildDropDownFromTemplateDropDownId(string InputTypeId)
        {
            if (InputTypeId != String.Empty)
            {

                DataTable dt = new DataTable("MyTable");
                dt.Columns.Add(new DataColumn("ParameterValue", typeof(string)));
                dt.Columns.Add(new DataColumn("ParameterName", typeof(string)));
                if (InputTypeId == "2" || InputTypeId == "3" || InputTypeId == "12")
                {


                    DataRow dr = dt.NewRow();

                    dr["ParameterValue"] = "0";
                    dr["ParameterName"] = "--select--";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["ParameterValue"] = "SUM";
                    dr["ParameterName"] = "SUM";
                    dt.Rows.Add(dr);


                    dr = dt.NewRow();
                    dr["ParameterValue"] = "MAX";
                    dr["ParameterName"] = "MAX";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["ParameterValue"] = "MIN";
                    dr["ParameterName"] = "MIN";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["ParameterValue"] = "Count";
                    dr["ParameterName"] = "Count";
                    dt.Rows.Add(dr);


                }
                else
                {
                    DataRow dr = dt.NewRow();
                    dr["ParameterValue"] = "0";
                    dr["ParameterName"] = "--select--";
                    dt.Rows.Add(dr);
                    dr = dt.NewRow();
                    dr["ParameterValue"] = "Count";
                    dr["ParameterName"] = "Count";
                    dt.Rows.Add(dr);

                }

                return dt;
            }
            else
            {
                return null;
            }
        }
        protected void ddlFormname_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetColumnName();
        }

        protected void ddlAggrigate_SelectedIndexChanged(object sender, EventArgs e)
        {
            var control = (Control)sender;
            var lvi = (ListViewItem)control.NamingContainer;
            var ddl = (DropDownList)lvi.FindControl("ddlAggrigate");
            var txt = (TextBox)lvi.FindControl("txtAliyas");
            //int selectionindex = lstSummaryQueryBuilder.SelectedIndex;
            //DropDownList ddl = (DropDownList)lstSummaryQueryBuilder.Items[selectionindex].FindControl("ddlAggrigate");
            //TextBox txt = (TextBox)lstSummaryQueryBuilder.Items[selectionindex].FindControl("txtAliyas");

            if (ddl.SelectedIndex.ToString() != "0")
            {
                txt.Visible = true;
            }
            else
            {
                txt.Visible = false;
            }
            control = (Control)sender;
            lvi = (ListViewItem)control.NamingContainer;
            ddl = (DropDownList)lvi.FindControl("ddlAggrigate");
            if (ddl.SelectedIndex.ToString() != "0")
            {
                var chk = (CheckBox)lvi.FindControl("chkIsgroupby");
                chk.Checked = false;



            }
            else
            {
                var chk = (CheckBox)lvi.FindControl("chkIsgroupby");
                chk.Checked = true;
            }

        }
        protected void tab_Click(object sender, EventArgs e)
        {
            if (sender.Equals(lnkDetails))
            {
                //Clrscr();
                btnSave.Text = "Submit";
                //hfPKEdit.Value = "0";
                GetSetClass(true, false);
            }
            else if (sender.Equals(lnklist))
            {
                //Clrscr();
                btnSave.Text = "Submit";
                //hfPKEdit.Value = "0";
                GetSetClass(false, true);
                
                LoadSummaryQueryDropdown();
            }
        }
        void LoadFormName()
        {
            BAL.FillDropdown bfd = new BAL.FillDropdown();
            bfd.LoadFormname(ddlFormname);
        }
        void GetSetClass(bool IsAdd, bool IsList)
        {
            if (IsAdd)
            {
                Details.Attributes["class"] = "";
                list.Attributes["class"] = "";
                Details.Attributes.Add("class", "tab-pane fade in active");
                list.Attributes.Add("class", "tab-pane fade in");
                lnklist.Visible = true;
                lnkDetails.Visible = false;
                //btnDeleteSelected.Visible = false;
                //btnExportExcel.Visible = false;
                Details.Visible = true;
                list.Visible = false;

            }
            if (IsList)
            {
                Details.Attributes["class"] = "";
                list.Attributes["class"] = "";
                Details.Attributes.Add("class", "tab-pane fade in");
                list.Attributes.Add("class", "tab-pane fade in active");
                lnklist.Visible = false;
                lnkDetails.Visible = true;
                //btnDeleteSelected.Visible = true;
                //btnExportExcel.Visible = true;
                Details.Visible = false;
                list.Visible = true;
            }
        }
        protected void lstSummaryQueryBuilder_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void chkIsgroupby_CheckedChanged(object sender, EventArgs e)
        {


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string Querystr = string.Empty;
            string Groupby = string.Empty;
            string FinalQuery = string.Empty;
            string SelectedColumn = string.Empty;
            string SelectedAggrigate = string.Empty;
            string SelectedIsGroupby = string.Empty;
            string strLeftJoin = string.Empty;
            if (Page.IsValid)
            {


                if (dt.Rows.Count == 0)
                {
                    dt.Columns.Add("ColumnName");
                    dt.Columns.Add("Aggrigate");
                    dt.Columns.Add("Alias");
                    dt.Columns.Add("Isgroupby");
                }

                int i = 0;
                foreach (ListViewItem item in lstSummaryQueryBuilder.Items)
                {
                    i = i + 1;
                    CheckBox cb = (CheckBox)item.FindControl("Chk_select");
                    Label lblcol = (Label)item.FindControl("lblColumnName");
                    Label lblinputtypid = (Label)item.FindControl("lblinputtypid");
                    DropDownList ddlaggri = (DropDownList)item.FindControl("ddlAggrigate");
                    TextBox txtAliyas = (TextBox)item.FindControl("txtAliyas");
                    CheckBox chkgroup = (CheckBox)item.FindControl("chkIsgroupby");
                    if (lblinputtypid.Text == "5" || lblinputtypid.Text == "14" || lblinputtypid.Text == "15")
                    {
                        strLeftJoin = strLeftJoin + "  LEFT JOIN dbo.ParameterMaster pm" + i + "  ON t.[" + lblcol.Text + "]  = pm" + i + ".ParameterId";

                    }

                    if (cb.Checked)
                    {
                        //AddColumn in Table
                        DataRow dr = dt.NewRow();
                        dr["ColumnName"] = lblcol.Text;
                        if (ddlaggri.SelectedIndex > 0)
                        {
                            dr["Aggrigate"] = ddlaggri.SelectedItem.ToString();
                        }
                        else
                        {
                            dr["Aggrigate"] = "";

                        }
                        dr["Alias"] = txtAliyas.Text;
                        dr["Isgroupby"] = chkgroup.Checked;
                        dt.Rows.Add(dr);


                        SelectedColumn = "pm" + i + ".ParameterName ";

                        SelectedAggrigate = SelectedAggrigate + ',' + ddlaggri.SelectedItem.ToString();


                        SelectedIsGroupby = SelectedIsGroupby + ',' + chkgroup.Checked;
                        string CoumnName = lblcol.Text;

                        string AggrigateFunName = ddlaggri.SelectedItem.ToString();
                        string aliyas = txtAliyas.Text;
                        Boolean IsGroupBy = chkgroup.Checked;
                        //adding column with aggrigate function
                        if (ddlaggri.SelectedIndex.ToString() != "0")
                        {
                            if (Querystr == string.Empty)
                            {
                                if (AggrigateFunName == "Count")
                                {
                                    Querystr = AggrigateFunName + "(seqid) as " + aliyas;

                                }
                                else if (AggrigateFunName == "SUM")
                                {

                                    Querystr = AggrigateFunName + "( cast([" + CoumnName + "] as decimal(18,3))) as " + aliyas;
                                }

                                else
                                {
                                    Querystr = AggrigateFunName + "([" + CoumnName + "]) as " + aliyas;
                                }


                            }
                            else
                            {
                                if (AggrigateFunName == "Count")
                                {
                                    Querystr = Querystr + " , " + AggrigateFunName + "([seqid]) as " + aliyas;
                                }
                                else if (AggrigateFunName == "SUM")
                                {

                                    Querystr = Querystr + " , " + AggrigateFunName + "( cast([" + CoumnName + "] as decimal(18,3))) as " + aliyas;
                                }
                                else
                                {
                                    Querystr = Querystr + " , " + AggrigateFunName + "([" + CoumnName + "]) as " + aliyas;
                                }

                            }

                        }
                        //adding column only
                        else
                        {
                            if (lblinputtypid.Text == "5" || lblinputtypid.Text == "14" || lblinputtypid.Text == "15")
                            {
                                if (Querystr == string.Empty)
                                {
                                    Querystr = Querystr + SelectedColumn + "as " + CoumnName.Replace(" ", "") + " ";
                                }
                                else
                                {
                                    Querystr = Querystr + " , " + SelectedColumn + "as " + CoumnName.Replace(" ", "") + " ";
                                }


                            }
                            else
                            {
                                if (Querystr == string.Empty)
                                {
                                    Querystr = Querystr + "[" + CoumnName + "]";
                                }
                                else
                                {
                                    Querystr = Querystr + " , " + "[" + CoumnName + "]";
                                }
                            }
                            //for ggroupby to add coloumn in var
                            if (chkgroup.Checked == true)
                            {
                                if (lblinputtypid.Text == "5" || lblinputtypid.Text == "14" || lblinputtypid.Text == "15")
                                {
                                    if (Groupby == string.Empty)
                                    {
                                        Groupby = SelectedColumn;
                                    }
                                    else
                                    {
                                        Groupby = Groupby + " ," + SelectedColumn;
                                    }
                                }
                                else
                                {
                                    if (Groupby == string.Empty)
                                    {
                                        Groupby = "[" + CoumnName + "]"; ;
                                    }
                                    else
                                    {
                                        Groupby = Groupby + " ," + "[" + CoumnName + "]";
                                    }
                                }

                            }

                        }


                    }


                }
                if (Groupby != string.Empty)
                {
                    Groupby = " Group by " + Groupby;

                }
                FinalQuery = "Select " + Querystr + " from " + ddlFormname .SelectedItem.ToString() + " t " + strLeftJoin+ " Where IsDeleted=0 " + Groupby;


            }


            Entity.ConfigurationHead objConfigurationHead = new Entity.ConfigurationHead();
            objConfigurationHead.TableName = ddlColumn.SelectedValue.ToString();
            objConfigurationHead.QueryMasterId = ddlColumn.SelectedValue.ToString(); 
            objConfigurationHead.dtQuerydata = dt;
            objConfigurationHead.QueryName = FinalQuery;
            objConfigurationHead.QueryDisplayText = txtQueryName.Text.Trim();
            int check = BAL.ConfigurationHeadMastermgmt.Insert_Summary_Query(objConfigurationHead);
            if (check > 0)
            {
                msg.GetMsg(this.Page, "Record Inserted Successfully.", "");
                clear();
            }
        }
        protected void ddlFormMaster_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadColumnName();
        }
        void GetGridData()
        {
            QueryGrid.DataSource = BAL.ConfigurationHeadMastermgmt.Get_Summary_Query_Builder_data(ddlQuery.SelectedValue.ToString()).Tables[0];
            QueryGrid.DataBind();

        }
       
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            if (ddlQuery.SelectedIndex > 0)
            {
                GetGridData();
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (ddlQuery.SelectedValue.ToString() != string.Empty)
            {
                if (Convert.ToInt32(ddlQuery.SelectedValue) > 0)
                {
                    DataSet dsResult = BAL.ConfigurationHeadMastermgmt.Delete_Summary_QueryMaster_Data(ddlQuery.SelectedValue.ToString());
                    msg.GetMsg(this.Page, dsResult.Tables[0].Rows[0]["RetMsg"].ToString(), "");
                    LoadSummaryQueryDropdown();
                    QueryGrid.DataSource = null;
                    QueryGrid.DataBind();
                }
            }
        }

        //protected void QueryGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    DataSet dsResult = BAL.ConfigurationHeadMastermgmt.Delete_Summary_QueryMaster_Data(ddlQuery.SelectedValue.ToString());
        //    msg.GetMsg(this.Page, dsResult.Tables[0].Rows[0]["RetMsg"].ToString(), "");
        //    LoadSummaryQueryDropdown();
        //    QueryGrid.DataSource = null;
        //    QueryGrid.DataBind();
        //}
    }
}