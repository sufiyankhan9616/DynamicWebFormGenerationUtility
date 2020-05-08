using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DynamicWebFormGenerationUtility.Common;
using DynamicWebFormGenerationUtility.BAL;
using System.Data;

namespace DynamicWebFormGenerationUtility.UIL
{
    public partial class NewQueryGeneratedForm : root
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadFormName();

                //GetGridData();
            }
        }
        void LoadFormName()
        {
            BAL.FillDropdown bfd = new BAL.FillDropdown();
            bfd.LoadFormname(ddlFormname);
        }
       
        void LoadQueryName()
        {
            BAL.FillDropdown bfd = new BAL.FillDropdown();
            bfd.LoadQueryName(ddlQuery);
        }
        void GetListData()
        {
            List<Entity.ConfigurationHead> lst = new List<Entity.ConfigurationHead>();
            lst = BAL.ConfigurationHeadMastermgmt.GetHeadName(ddlFormname.SelectedValue);
            BindData(lst);
        }
        
        
        void BindData(List<Entity.ConfigurationHead> lst)
        {
            lstvQualifyingHeadMaster.DataSource = lst;
            lstvQualifyingHeadMaster.DataBind();
        }

        void RefreshQueryData()
        {
            
          int  GetResult = BAL.ConfigurationHeadMastermgmt.Refresh_QueryData(ddlQuery.SelectedItem.ToString());
            if (GetResult > 0)
            {
                msg.GetMsg(this, "Record Refreshed. ", "");
            }
        }

        void GetGridData(string ddlQuery)
        {
            QueryGrid.DataSource = BAL.ConfigurationHeadMastermgmt.GetQueryGridData(ddlQuery).Tables[0];
            QueryGrid.DataBind();
          
        }

        protected void Clear()
        {
            txtQueryName.Text = string.Empty;
            LoadFormName();
            lstvQualifyingHeadMaster.DataSource = null;
            lstvQualifyingHeadMaster.DataBind();
            //GetGridData();
        }
        void clrscr()
        {

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
                LoadQueryName();
                Details.Visible = false;
                list.Visible = true;

            }
        }
        protected void tab_Click(object sender, EventArgs e)
        {
            if (sender.Equals(lnkDetails))
            {
                clrscr();
                GetSetClass(true, false);
            }
            else if (sender.Equals(lnklist))
            {
                clrscr();
                btnSave.Text = "Submit";

                GetSetClass(false, true);
                //GetGridData();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string ConditionString = "";

            if (Page.IsValid)
            {
                Entity.ConfigurationHead objConfigurationHead = new Entity.ConfigurationHead();
                objConfigurationHead.MinInputValue = "0";
                objConfigurationHead.MaxInputValue = "0";
                string IDs = "";
                string Name = "";
                //DataTable dtconditiondata = new DataTable();
                //dtconditiondata.Columns.Add("ColumnName");
                //dtconditiondata.Columns.Add("Condition");
                //dtconditiondata.Columns.Add("ConditionValue");
                foreach (ListViewItem item in lstvQualifyingHeadMaster.Items)
                {
                    CheckBox cb = (CheckBox)item.FindControl("Chk_select");
                    DropDownList ddlcondition = (DropDownList)item.FindControl("ddlConditon");
                    Label lblcname = (Label)item.FindControl("lblColumnName");

                    if (cb.Checked)
                    {
                        HiddenField hf = (HiddenField)item.FindControl("hfDKId");
                        IDs += hf.Value + ",";
                        HiddenField hf2 = (HiddenField)item.FindControl("hfDKName");
                        Name += hf2.Value.Replace (" ","") + ",";
                        //DataRow dr = dtconditiondata.NewRow();
                        //dr["ColumnName"] = hf2.Value;
                        //dr["Condition"] = ddlcondition.SelectedValue.ToString();
                        TextBox txtCondiValue = (TextBox)item.FindControl("txtConditionValue");
                        DropDownList ddlOperator = (DropDownList)item.FindControl("ddlOperator");
                        
                        //dr["ConditionValue"] = txtCondiValue.Text;
                        //dtconditiondata.Rows.Add(dr);
                        if (ddlcondition.SelectedIndex > 0 && txtCondiValue.Text == "")
                        {
                            msg.GetMsg(this, "Please select Condition Value for column " + lblcname.Text, "");
                            return;
                        }
                        if (txtCondiValue.Text != string.Empty)
                        {
                            if (ddlcondition.SelectedValue != "0")
                            {
                                if (ddlcondition.SelectedValue == "Like")
                                {
                                    ConditionString = ConditionString + "[" + hf2.Value.Replace(" ", "") + "]  " + ddlcondition.SelectedValue.ToString() + "'%" + txtCondiValue.Text + "%' ";
                                }
                                else
                                {
                                ConditionString = ConditionString + "[" + hf2.Value.Replace(" ", "") + "]  " + ddlcondition.SelectedValue.ToString() + " '" + txtCondiValue.Text + "' ";
                                }
                                ConditionString = ConditionString + ddlOperator.SelectedValue;
                                
                                
                            }
                        }
                    }
                    else
                    {
                        if (ddlcondition.SelectedIndex > 0)
                        {
                            msg.GetMsg(this, "Please select Checkbox for column " + lblcname.Text, "");
                            return;
                        }
                    }
                   
                }
                if (ConditionString == string.Empty)
                {
                    ConditionString = string.Empty;
                }
                else
                {
                    ConditionString = "  Where  " + ConditionString;
                    ConditionString = ConditionString.Remove(ConditionString.Length - 4);
                }
                if (IDs == "")
                {
                    msg.GetMsg(this.Page, "AND", "LE");
                    return;
                }
                //if (hfPKEdit.Value != "0")
                //{
                //    if (!(IsUpdate && Event.Find(x => x.EventName.Contains("Update")) != null))
                //    {
                //        msg.GetMsg(this.Page, "QualifyingHeadMaster", "UR");
                //        return;
                //    }
                //    objConfigurationHead.ConfigurationHeadId = hfPKEdit.Value.ToInt32();
                //    objConfigurationHead.EventId = Event.Find(x => x.EventName.Contains("Update")).EventId;
                //}
                //else
                //{
                if (!(IsInsert && Event.Find(x => x.EventName.Contains("Insert")) != null))
                {
                    msg.GetMsg(this.Page, "NewQueryGeneratedForm", "SR");
                    return;
                }
                //objConfigurationHead.ConfigurationHeadId = 0;
                //objConfigurationHead.EventId = Event.Find(x => x.EventName.Contains("Insert")).EventId;
                objConfigurationHead.QueryName = txtQueryName.Text;
                objConfigurationHead.FormName = ddlFormname.SelectedValue;
                objConfigurationHead.ColumnsId = IDs;
                objConfigurationHead.ColumnsName = Name;
                objConfigurationHead.HostName = "";
                objConfigurationHead.IpAddr = "";
                objConfigurationHead.ConditionString = ConditionString;
                //objConfigurationHead.UserId = 0;
                int check = BAL.ConfigurationHeadMastermgmt.AddUpdateHeadName(objConfigurationHead);
                if (check > 0)
                {

                    msg.GetMsg(this.Page, "NewQueryGeneratedForm", "I");
                    Clear();


                }
               else  if (check == -2)
                {
                    msg.GetMsg(this.Page, "NewQueryGeneratedForm", "EE");
                }
                else if (check == -1)
                {
                    msg.GetMsg(this.Page, "Table Does Not Exits.", "");
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }
        protected void ddlQuery_selectedindexchanged(object sender, EventArgs e)
        {
            if (ddlQuery.SelectedValue.ToString() != "0")
            {
                GetGridData(ddlQuery.SelectedValue .ToString());
                if (ddlQuery.SelectedIndex > 0)
                {
                    btnRefresh.Visible = true;
                    btnDelete.Visible = true;
                }
                else
                {
                    btnRefresh.Visible = false;
                    btnDelete.Visible = false;
                }
            }
           

        }

        protected void ddlFormname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFormname.SelectedIndex > 0)
            {
                
                GetListData();
            }
            
        }

        protected void BtnRefresh_Click(object sender, EventArgs e)
        {
            if (ddlQuery.SelectedIndex > 0)
            {
                RefreshQueryData();
                ddlQuery_selectedindexchanged(null, null);
            }
            
        }


        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            if (ddlQuery.SelectedValue.ToString() != string.Empty)
            {
                if (Convert.ToInt32(ddlQuery.SelectedValue) > 0)
                {
                    DataSet dsResult = BAL.ConfigurationHeadMastermgmt.Delete_QueryMaster_Data(ddlQuery.SelectedValue.ToString());
                    msg.GetMsg(this.Page, dsResult.Tables[0].Rows[0]["RetMsg"].ToString(), "");
                    LoadQueryName();
                    QueryGrid.DataSource = null;
                    QueryGrid.DataBind();
                }
            }

        }

        





    }
}