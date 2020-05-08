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
    public partial class FormFilling : root
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadFormName();
                //ddlFormname.SelectedValue = Session["MenuId"].ToString();
                ddlFormname.SelectedValue = Session["MenuId"].ToString();
                Session["SeqId"] = 0;
                DataSet ds = BAL.FormFillingmgmt.GetMaxUserIDByFormId(ddlFormname.SelectedValue.ToInt64());
                //Session["SeqId"] = ds.Tables[0].Rows[0]["USERID"].ToString().ToInt64() + 1;
                ddlFormname_SelectedIndexChanged(null, null);
                lblFormName.Text = ddlFormname.SelectedItem.ToString();
                DropDownList ddlmstmenu = (DropDownList)Master.FindControl("ddlMenu");

                ddlmstmenu.SelectedValue = Session["MenuId"].ToString();
                GetSetClass(true, false);
                if (Session["DistCode"] != null)
                { }
                else { 
                Session["DistCode"] = "";
                 Session["TalCode"] = "";
                Session["OfficeId"] = "";
                Session["OtherSession"] = "";
                }
            }
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
                btnExportExcel.Visible = false;
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
        void GetListData(DataTable DTFilterData)
        {
            dgFormFilling.DataSource = BAL.ConfigurationHeadMastermgmt.getFormFillingData(ddlFormname.SelectedValue, DTFilterData).Tables[0];
            dgFormFilling.DataBind();


        }
        protected void tab_Click(object sender, EventArgs e)
        {
            if (sender.Equals(lnkDetails))
            {
                Session["SeqId"] = 0;
                //Session["SeqId"] = ds.Tables[0].Rows[0]["USERID"].ToString().ToInt64() + 1;
                ddlFormname_SelectedIndexChanged(null, null);
                DropDownList ddlmstmenu = (DropDownList)Master.FindControl("ddlMenu");
                GetSetClass(true, false);
                btnSave.Text = "Submit";
                //hfPKEdit.Value = "0";
                //GetSetClass(true, false);
                //DataSet ds = BAL.FormFillingmgmt.GetMaxUserIDByFormId(ddlFormname.SelectedValue.ToInt64());
                ////Session["UserId"] = ds.Tables[0].Rows[0]["USERID"].ToString().ToInt64() + 1;
                //ddlFormname_SelectedIndexChanged(null, null);

            }
            else if (sender.Equals(lnklist))
            {
                btnSave.Text = "Submit";
                //hfPKEdit.Value = "0";
                GetSetClass(false, true);
                btnSearch_Click(null, null);
            }
        }
        void LoadFormName()
        {
            BAL.FillDropdown bfd = new BAL.FillDropdown();
            bfd.LoadFormname(ddlFormname);
        }
        public DataTable GetControlByForm(string FormComponentMasterId)
        {
            return BAL.FormFillingmgmt.GetControlByForm(ddlFormname.SelectedValue.ToString().ToInt32(), Session["SeqId"].ToString().ToInt64(), FormComponentMasterId.ToString().ToInt64()).Tables[0].DefaultView.ToTable();
        }
        public DataTable GetSearchControlByForm()
        {
            return BAL.FormFillingmgmt.GetSearchingControlByForm(ddlFormname.SelectedValue.ToString().ToInt32()).Tables[0].DefaultView.ToTable();
        }

        public DataTable BindDropDownFromTemplateDropDownId(string TemplateDropdownMasterId)
        {
            if (TemplateDropdownMasterId.ToInt64() > 0)
            {
                if (TemplateDropdownMasterId != "" && !(TemplateDropdownMasterId is DBNull) && TemplateDropdownMasterId != "0")
                    return BAL.FormFillingmgmt.BindDropDownFromTemplateDropDownId(TemplateDropdownMasterId).Tables[0];
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        public DataTable BindChildDropDownFromTemplateDropDownId(string TemplateDropdownMasterId, string UserId, string ConfigurationHeadId)
        {
            if (TemplateDropdownMasterId.ToInt64() > 0)
            {
                if (TemplateDropdownMasterId != "" && !(TemplateDropdownMasterId is DBNull) && TemplateDropdownMasterId != "0")
                    return BAL.FormFillingmgmt.LoadChildDropDownTemplateMasterId(TemplateDropdownMasterId, UserId, ConfigurationHeadId).Tables[0];
                else
                    return null;
            }
            else
            {
                return null;
            }
        }


        public DataTable BindRadioButtionListByTemplateDropDownId(string TemplateDropdownMasterId, string para1 = "")
        {
            if (TemplateDropdownMasterId != "" && !(TemplateDropdownMasterId is DBNull) && TemplateDropdownMasterId != "0")
                if (para1 == "")
                {
                    return BAL.FormFillingmgmt.BindDropDownFromTemplateDropDownId(TemplateDropdownMasterId).Tables[0];

                }
                else
                {
                    return BAL.FormFillingmgmt.BindDropDownFromTemplateDropDownId(TemplateDropdownMasterId).Tables[0];
                }
            return null;
        }
        protected DataTable GetQulaifyingHeadData(Control pg, DataTable qt, DataTable st)
        {
            // Generate Table From  Head Binded and only update value in respective head and send back
            foreach (Control ctrl in pg.Controls)
            {
                //check for all the TextBox controls on the page and clear them
                if (ctrl.GetType() == typeof(USControls.USTextBox) && ctrl.Parent.Visible == true)
                {
                    USControls.USTextBox utxt = (USControls.USTextBox)ctrl;
                    DataRow dr;

                    if (utxt.IsObtained == utxt.IsTotal == utxt.IsPercentage == false)
                    {
                        dr = qt.Select("HeadId=" + utxt.DBName).First();
                        dr["HeadValue"] = utxt.Text;
                    }
                }
                else if (ctrl.GetType() == typeof(USControls.USDropDownList) && ctrl.Parent.Visible == true)
                {
                    USControls.USDropDownList utxt = (USControls.USDropDownList)ctrl;
                    DataRow dr = qt.Select("HeadId=" + utxt.DBName).First();
                    if (dr != null)
                        dr["HeadValue"] = utxt.SelectedValue;
                }
                else if (ctrl.GetType() == typeof(USControls.USBaseDropDownList) && ctrl.Parent.Visible == true)
                {
                    USControls.USBaseDropDownList utxt = (USControls.USBaseDropDownList)ctrl;
                    DataRow dr = qt.Select("HeadId=" + utxt.DBName).First();
                    if (dr != null)
                        dr["HeadValue"] = utxt.SelectedValue;
                }
                else if (ctrl.GetType() == typeof(USControls.USRadioButtonList) && ctrl.Parent.Visible == true)
                {
                    USControls.USRadioButtonList utxt = (USControls.USRadioButtonList)ctrl;
                    DataRow dr = qt.Select("HeadId=" + utxt.DBName).First();
                    if (dr != null)
                        dr["HeadValue"] = utxt.SelectedValue;
                }
                else if (ctrl.GetType() == typeof(USControls.USCheckBox) && ctrl.Parent.Visible == true)
                {
                    USControls.USCheckBox utxt = (USControls.USCheckBox)ctrl;
                    DataRow dr = qt.Select("HeadId=" + utxt.DBName).First();

                    if (dr != null)
                    {
                        dr["HeadValue"] = utxt.Checked == true ? "True" : "False";
                    }

                }
                qt.AcceptChanges();
                GetQulaifyingHeadData(ctrl, qt, st);
            }
            return qt;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Entity.FormFilling objFormFilling = new Entity.FormFilling();
            objFormFilling.MinInputValue = "0";

            DataSet ds = BAL.FormFillingmgmt.GetControlByForm(ddlFormname.SelectedValue.ToInt32(), Session["SeqId"].ToString().ToInt64(), 0);
            DataTable qt = ds.Tables[1];

            DataTable st = ds.Tables[0];
            objFormFilling.dt = GetQulaifyingHeadData(sectionLev1, qt, st);
            if (objFormFilling.dt.Rows.Count == 0)
            {
                msg.GetMsg(this.Page, "Please configure atleast one control.", "");
                return;
            }
            objFormFilling.FormId = ddlFormname.SelectedValue.ToInt32();
            objFormFilling.HostName = "";
            objFormFilling.IpAddr = "";
            objFormFilling.SeqId = Session["SeqId"].ToString().ToInt64();
            if (btnSave.Text.ToString().ToLower() == "update")
            {
                objFormFilling.Isupdate = true;
            }
            else
            {
                objFormFilling.Isupdate = false;
            }

            objFormFilling.DistCode = Session["DistCode"].ToString();
            objFormFilling.TalCode = Session["TalCode"].ToString();
            objFormFilling.OfficeId = Session["OfficeId"].ToString();
            objFormFilling.OtherSession = Session["OtherSession"].ToString();
            DataSet check = BAL.FormFillingmgmt.AddUpdateFormFilling(objFormFilling);
            if (check.Tables.Count > 0)
            {
                for (int i = 0; i < check.Tables.Count; i++)
                {
                    if (check.Tables[i].Rows.Count > 0)
                    {
                        if (Convert.ToInt32(check.Tables[i].Rows[0]["RetVal"]) == 1)
                        {
                            msg.GetMsg(this.Page, check.Tables[i].Rows[0]["RetMsg"].ToString(), "");
                            clrscr();
                            GetSetClass(false, true);
                        }
                        else if (Convert.ToInt32(check.Tables[i].Rows[0]["RetVal"]) == 2)
                        {
                            DataSet ds1 = BAL.FormFillingmgmt.GetMaxUserIDByFormId(ddlFormname.SelectedValue.ToInt64());
                            //Session["SeqId"] = ds1.Tables[0].Rows[0]["USERID"].ToString().ToInt64() + 1;
                            clrscr();
                            GetSetClass(false, true);
                            msg.GetMsg(this.Page, check.Tables[i].Rows[0]["RetMsg"].ToString(), "");
                        }
                        else if (Convert.ToInt32(check.Tables[i].Rows[0]["RetVal"]) == -1)
                        {
                            msg.GetMsg(this.Page, check.Tables[i].Rows[0]["RetMsg"].ToString(), "");
                        }
                        else if (Convert.ToInt32(check.Tables[i].Rows[0]["RetVal"]) == -3)
                        {
                            msg.GetMsg(this.Page, check.Tables[i].Rows[0]["RetMsg"].ToString(), "");
                        }
                    }

                }

            }
            else
            {
                msg.GetMsg(this.Page, "ConfigurationForm", "E");
            }

        }

        public DataTable BindSubRepeter(string FormComponentMasterId)
        {
            DataTable dt = GetControlByForm(FormComponentMasterId);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["FormFillingId"].ToString().ToInt64() > 0)
                {
                    btnSave.Text = "Update";
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            else
            {

                msg.GetMsg(this.Page, "Please configure atleast one control.", "");
                return dt;
            }
        }

        public DataTable BindSearchingRepeter()
        {
            DataTable dt = GetSearchControlByForm();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["FormFillingId"].ToString().ToInt64() > 0)
                {
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            else
            {
                return dt;
            }
        }

        protected void ddlFormname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFormname.SelectedIndex > 0)
            {
                sectionLev1.DataSource = BAL.FormFillingmgmt.GetComponantControlByForm(ddlFormname.SelectedValue.ToString().ToInt32(), Session["SeqId"].ToString().ToInt64()).Tables[0].DefaultView.ToTable();
                sectionLev1.DataBind();
                sectionSerach.DataSource = BindSearchingRepeter();
                sectionSerach.DataBind();
            }
            else
            {
                sectionLev1.DataSource = null;
                sectionLev1.DataBind();
                sectionSerach.DataSource = null;
                sectionSerach.DataBind();
            }
        }

        void clrscr()
        {
            btnDelete.Visible = false;
            DataSet ds = BAL.FormFillingmgmt.GetMaxUserIDByFormId(ddlFormname.SelectedValue.ToInt64());
            //Session["UserId"] = ds.Tables[0].Rows[0]["USERID"].ToString().ToInt64() + 1;
            ddlFormname_SelectedIndexChanged(null, null);
            btnSave.Text = "Save";
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clrscr();
        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!(IsDelete && Event.Find(x => x.EventName.Contains("Delete")) != null))
            {
                msg.GetMsg(this.Page, "FormFilling", "DR");
                return;

            }
            int lst = BAL.FormFillingmgmt.DeleteFormFilling(ddlFormname.SelectedValue.ToInt32(), Convert.ToInt32(Session["SeqId"]), Convert.ToInt32(Session["User_Id"]), "", "", Event.Find(x => x.EventName.Contains("Delete")).ToString().ToInt64(), Guid.NewGuid().ToString());
            if (lst == 1)
            {
                msg.GetMsg(this.Page, "FormFilling", "D");
                clrscr();
            }
            else
            {
                msg.GetMsg(this.Page, "FormFilling", "DE");
            }
        }

        protected void USBaseDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["IsFound"] = false;
            USControls.USBaseDropDownList drp = sender as USControls.USBaseDropDownList;
            if (drp.SelectedIndex > 0 && drp.ChildDBName.ToString().ToInt64() > 0)
            {
                String Para1 = drp.SelectedValue.ToString();
                GetDropdownbyDBName(sectionLev1, Para1, drp.ChildDBName);
            }
        }
        protected void GetDropdownbyDBName(Control control, string Para1, string ChildDBName)
        {
            if (ViewState["IsFound"].ToString().ToBoolean() == false)
            {

                foreach (Control ctrl in control.Controls)
                {


                    if (ctrl.GetType() == typeof(USControls.USDropDownList) && ctrl.Parent.Visible == true)
                    {

                        USControls.USDropDownList drp = (USControls.USDropDownList)ctrl.FindControl("USDDTEMP");
                        if (drp.DBName == ChildDBName && drp.DBName != "")
                        {
                            drp.Items.Clear();
                            DataTable dt = BAL.FormFillingmgmt.BindDropDownFromTemplateDropDownIdAndPara1(drp.DBName, Para1).Tables[0];
                            foreach (DataRow drow in dt.Rows)
                            {
                                ListItem lst = new ListItem(drow["ParameterText"].ToString(), drow["ParameterValue"].ToString());
                                drp.Items.Add(lst);
                            }
                            ViewState["IsFound"] = true;
                            return;
                        }

                    }
                    //Sufiyan Adding for UsBase Template filtering  || ctrl.GetType() == typeof(USControls.USBaseDropDownList))
                    else if (ctrl.GetType() == typeof(USControls.USBaseDropDownList) && ctrl.Parent.Visible == true)
                    {
                        USControls.USDropDownList drp2 = (USControls.USDropDownList)ctrl.FindControl("USDDTEMP");
                        USControls.USBaseDropDownList drp1 = (USControls.USBaseDropDownList)ctrl.FindControl("USBaseDropDownList1");
                        if (drp2.DBName == ChildDBName && drp2.DBName != "")
                        {
                            drp1.Items.Clear();
                            DataTable dt = BAL.FormFillingmgmt.BindDropDownFromTemplateDropDownIdAndPara1(drp2.DBName, Para1).Tables[0];
                            foreach (DataRow drow in dt.Rows)
                            {
                                ListItem lst = new ListItem(drow["ParameterText"].ToString(), drow["ParameterValue"].ToString());
                                drp1.Items.Add(lst);
                            }
                            ViewState["IsFound"] = true;
                            return;
                        }
                    }

                    else if (ViewState["IsFound"].ToString().ToBoolean() == false)
                    {
                        GetDropdownbyDBName(ctrl, Para1, ChildDBName);
                    }


                }

            }
        }

        protected void GetSearchDropdownbyDBName(Control control, string Para1, string ChildDBName)
        {
            if (ViewState["IsSearchFound"].ToString().ToBoolean() == false)
            {

                foreach (Control ctrl in control.Controls)
                {


                    if (ctrl.GetType() == typeof(USControls.USDropDownList) && ctrl.Parent.Visible == true)
                    {

                        USControls.USDropDownList drp = (USControls.USDropDownList)ctrl.FindControl("USDDTEMP");
                        if (drp.DBName == ChildDBName && drp.DBName != "")
                        {
                            drp.Items.Clear();
                            DataTable dt = BAL.FormFillingmgmt.BindDropDownFromTemplateDropDownIdAndPara1(drp.DBName, Para1).Tables[0];
                            foreach (DataRow drow in dt.Rows)
                            {
                                ListItem lst = new ListItem(drow["ParameterText"].ToString(), drow["ParameterValue"].ToString());
                                drp.Items.Add(lst);
                            }
                            ViewState["IsFound"] = true;
                            return;
                        }

                    }
                    //Sufiyan Adding for UsBase Template filtering  || ctrl.GetType() == typeof(USControls.USBaseDropDownList))
                    else if (ctrl.GetType() == typeof(USControls.USBaseDropDownList) && ctrl.Parent.Visible == true)
                    {
                        USControls.USDropDownList drp2 = (USControls.USDropDownList)ctrl.FindControl("USDDTEMP");
                        USControls.USBaseDropDownList drp1 = (USControls.USBaseDropDownList)ctrl.FindControl("USBaseDropDownList1");
                        if (drp2.DBName == ChildDBName && drp2.DBName != "")
                        {
                            drp1.Items.Clear();
                            DataTable dt = BAL.FormFillingmgmt.BindDropDownFromTemplateDropDownIdAndPara1(drp2.DBName, Para1).Tables[0];
                            foreach (DataRow drow in dt.Rows)
                            {
                                ListItem lst = new ListItem(drow["ParameterText"].ToString(), drow["ParameterValue"].ToString());
                                drp1.Items.Add(lst);
                            }
                            ViewState["IsFound"] = true;
                            return;
                        }
                    }

                    else if (ViewState["IsFound"].ToString().ToBoolean() == false)
                    {
                        GetDropdownbyDBName(ctrl, Para1, ChildDBName);
                    }


                }

            }
        }

        //protected void GetBaseDropDown(Control control)
        //{

        //    foreach (Control ctrl in control.Controls)
        //    {
        //        if (ctrl.GetType() == typeof(USControls.USBaseDropDownList) && ctrl.Parent.Visible == true)
        //        {

        //            USControls.USBaseDropDownList drp = (USControls.USBaseDropDownList)ctrl.FindControl("USBaseDropDownList1");
        //            USBaseDropDownList_SelectedIndexChanged(drp, null);
        //            GetBaseDropDown(ctrl);

        //        }
        //        else
        //        {
        //            GetBaseDropDown(ctrl);
        //        }


        //    }
        //}

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
            ddlFormname_SelectedIndexChanged(null, null);
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {

        }


        protected void dgFormFilling_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string commandName = e.CommandName;
            string FormRowId = e.CommandArgument.ToString();
            if (commandName == "AEdit")
            {
                Session["SeqId"] = FormRowId.ToString();
                ddlFormname_SelectedIndexChanged(null, null);
                GetSetClass(true, false);
                btnSave.Text = "Update";
            }
            if (commandName == "ADelete")
            {
                Session["SeqId"] = FormRowId.ToString();

                btnDelete_Click(null, null);
                GetSetClass(false, true);
            }
        }

        protected void dgFormFilling_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[3].Visible = false;
        }

        protected void USBaseDropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["IsSearchFound"] = false;
            USControls.USBaseDropDownList drp = sender as USControls.USBaseDropDownList;
            if (drp.SelectedIndex > 0 && drp.ChildDBName.ToString().ToInt64() > 0)
            {
                String Para1 = drp.SelectedValue.ToString();
                GetSearchDropdownbyDBName(sectionSerach, Para1, drp.ChildDBName);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Entity.FormFilling objFormFilling = new Entity.FormFilling();
            objFormFilling.MinInputValue = "0";

            DataSet ds = BAL.FormFillingmgmt.GetSearchingControlByForm(ddlFormname.SelectedValue.ToInt32());
            DataTable qt = ds.Tables[1];

            DataTable st = ds.Tables[0];
            objFormFilling.dt = GetQulaifyingHeadData(sectionSerach, qt, st);
            GetListData(objFormFilling.dt);
            GetSetClass(false , true );

        }
    }
}