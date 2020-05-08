using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DynamicWebFormGenerationUtility.Common;
using DynamicWebFormGenerationUtility.BAL;

namespace DynamicWebFormGenerationUtility.UIL
{
    public partial class ConfigurationForm : root
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ViewState["sortname"] = "";
                ViewState["sortexp"] = "";
                GetSetClass(true, false);
                LoadInputTypeMasterDropdown();
                LoadTemplateDropDown();
                LoadConfigurationFormname();
                LoadValidationType();
                //int a = 0;
                //a = 1 / a;
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
                btnDeleteSelected.Visible = false;
                btnExportExcel.Visible = false;
                Details.Visible = true;
                list.Visible = false;
                IsVisiblefield(true);
            }
            if (IsList)
            {
                Details.Attributes["class"] = "";
                list.Attributes["class"] = "";
                Details.Attributes.Add("class", "tab-pane fade in");
                list.Attributes.Add("class", "tab-pane fade in active");
                lnklist.Visible = false;
                lnkDetails.Visible = true;
                btnDeleteSelected.Visible = true;
                btnExportExcel.Visible = true;
                Details.Visible = false;
                list.Visible = true;
                IsVisiblefield(false);
            }
        }
        void LoadInputTypeMasterDropdown()
        {
            BAL.FillDropdown bfd = new BAL.FillDropdown();
            bfd.LoadInputTypeMasterDropdown(ddlInputType);
        }


        void LoadTemplateDropDown()
        {
            BAL.FillDropdown bfd = new BAL.FillDropdown();
            bfd.LoadTemplateDropDown(ddlTemplateDropdownMaster);
        }
        

        void LoadConfigurationFormname()
        {
            BAL.FillDropdown bfd = new BAL.FillDropdown();
            bfd.LoadConfigurationFormname(ddlFormname);
        }
        
        void LoadValidationType()
        {
            BAL.FillDropdown bfd = new BAL.FillDropdown();
            bfd.LoadValidationType(ddlValidationType);
        }
        
        void LoadChildDropDownByFormId()
        {
            BAL.FillDropdown bfd = new BAL.FillDropdown();
            bfd.LoadChildDropDownByFormId(ddlChildDropDownHead, ddlFormname.SelectedValue.ToString());
        }

        void LoadFormComponent()
        {
            BAL.FillDropdown bfd = new BAL.FillDropdown();
            bfd.LoadFormComponentFormId(ddlFormComponent, ddlFormname.SelectedValue.ToString());
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Entity.ConfigurationHead objConfigurationHead = new Entity.ConfigurationHead();
                objConfigurationHead.MinInputValue = "0";
                objConfigurationHead.MaxInputValue = "0";
                if (hfPKEdit.Value != "0")
                {
                    if (!(IsUpdate && Event.Find(x => x.EventName.Contains("Update")) != null))
                    {
                        msg.GetMsg(this.Page, "QualifyingHeadMaster", "UR");
                        return;
                    }
                    objConfigurationHead.ConfigurationHeadId = hfPKEdit.Value.ToInt32();
                    objConfigurationHead.EventId = Event.Find(x => x.EventName.Contains("Update")).EventId;
                }
                else
                {
                    if (!(IsInsert && Event.Find(x => x.EventName.Contains("Insert")) != null))
                    {
                        msg.GetMsg(this.Page, "QualifyingHeadMaster", "SR");
                        return;
                    }
                    objConfigurationHead.ConfigurationHeadId = 0;
                    objConfigurationHead.EventId = Event.Find(x => x.EventName.Contains("Insert")).EventId;
                }
                objConfigurationHead.ConfigurationHeadName = txtQualifyingHeadName.Text;
                objConfigurationHead.HeadNote = txtHeadNoteforStudent.Text;
                objConfigurationHead.InputTypeId = ddlInputType.SelectedValue.ToInt16();
                objConfigurationHead.FormId = ddlFormname.SelectedValue.ToString().ToInt32();
                objConfigurationHead.FormComponentMasterId = ddlFormComponent.SelectedValue.ToString().ToInt64();
                objConfigurationHead.IsUniqueKey = chkUniqueKey.Checked;
                objConfigurationHead.IsCompositeUniqueKey = chkCompositeUniqueKey.Checked;
                if (Convert.ToInt64(ddlInputType.SelectedItem.Value) == 6)
                {
                    if (txtMinInputValue.Text == string.Empty)
                    {
                        msg.GetMsg(this.Page, "Please Enter Minimum Input Value", "");
                        return;
                    }
                    else if (txtMaxInputValue.Text == string.Empty)
                    {
                        msg.GetMsg(this.Page, "Please Enter Maximum Input Value", "");
                        return;
                    }
                }
                if (Convert.ToInt64(ddlInputType.SelectedItem.Value) == 3 || Convert.ToInt64(ddlInputType.SelectedItem.Value) == 12)
                {
                    objConfigurationHead.MinInputValue = txtMinInputValue.Text;
                    objConfigurationHead.MaxInputValue = txtMaxInputValue.Text;
                }
                else if (Convert.ToInt64(ddlInputType.SelectedItem.Value) == 15 || Convert.ToInt64(ddlInputType.SelectedItem.Value) == 5 || Convert.ToInt64(ddlInputType.SelectedItem.Value) == 14)
                {
                    objConfigurationHead.TemplateDropdownMasterId = ddlTemplateDropdownMaster.SelectedValue.ToInt16();

                }
                else if (Convert.ToInt64(ddlInputType.SelectedItem.Value) == 2)
                {
                    objConfigurationHead.MinInputValue = txtMinDate.Text;
                    objConfigurationHead.MaxInputValue = txtMaxDate.Text;
                }
                else if (Convert.ToInt64(ddlInputType.SelectedItem.Value) == 10)
                {
                    objConfigurationHead.MaxLength = txtMaxLength.Text.ToInt32();
                    objConfigurationHead.RegexMasterId = ddlValidationType.SelectedValue.ToString().ToInt64();
                }
                if (Convert.ToInt64(ddlInputType.SelectedItem.Value) == 15)
                {
                    objConfigurationHead.ChildDBId = ddlChildDropDownHead.Text.ToInt64();
                }
                objConfigurationHead.IsCompulsaryEntry = chkIsCompulsaryEntry.Checked;
                objConfigurationHead.IsSearchableDropdown = chkSarchableDrp.Checked;
                objConfigurationHead.Remark = txtRemark.Text;
                objConfigurationHead.HostName = "";
                objConfigurationHead.IpAddr = "";
                objConfigurationHead.UserId = 0;
                objConfigurationHead.DisplayPreferenceNo = txtQualifyingHeadDisplayPreferenceNo.Text.ToDecimal();
                int check = BAL.ConfigurationHeadMastermgmt.AddUpdateConfigurationHead(objConfigurationHead);

                if (check > 0)
                {
                    if (hfPKEdit.Value != "0")
                    {
                        msg.GetMsg(this.Page, "ConfigurationForm", "U");
                        clrscr();
                        GetListData();
                        GetSetClass(false, true);
                    }
                    else
                    {
                        msg.GetMsg(this.Page, "ConfigurationForm", "I");
                        clrscr();
                        GetListData();
                    }
                }
                else if (check == -1)
                {
                    msg.GetMsg(this.Page, "ConfigurationForm", "AE");
                }
                if (check == -3)
                {
                    msg.GetMsg(this.Page, "This Form control's is freezed you can't Insert/Update Configuration ,In order to update configuration please unfreez form and then try again.", "");
                }
                else if (check == -2)
                {
                    msg.GetMsg(this.Page, "Head Display Preference already exist. Make sure it should be unique in every component.", "");
                }
                else
                {
                    msg.GetMsg(this.Page, "ConfigurationForm", "E");
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clrscr();
        }

        void clrscr()
        {
            txtQualifyingHeadName.Text = String.Empty;
            txtHeadNoteforStudent.Text = String.Empty;
            ddlInputType.SelectedIndex = 0;
            ddlFormname.SelectedIndex = 0;
            txtMinInputValue.Text = string.Empty;
            txtMaxInputValue.Text = String.Empty;
            txtQualifyingHeadDisplayPreferenceNo.Text = String.Empty;
            chkIsCompulsaryEntry.Checked = false;
            ddlTemplateDropdownMaster.SelectedIndex = 0;
            txtRemark.Text = String.Empty;
            lblDescription.Text = string.Empty;
            lblDescription.Visible = false;
            hfPKEdit.Value = "0";
            DivMaxLength.Visible = false;
            divMinMaxDate.Visible = false;
            divMinMaxValues.Visible = false;
            divTemplateDropdownMaster.Visible = false;
            txtMaxInputValue.Enabled = true;
            ddlFormComponent.SelectedIndex = 0;
            chkSarchableDrp.Checked = false;


        }
        protected void tab_Click(object sender, EventArgs e)
        {
            if (sender.Equals(lnkDetails))
            {
                clrscr();
                btnSave.Text = "Submit";
                hfPKEdit.Value = "0";
                GetSetClass(true, false);
            }
            else if (sender.Equals(lnklist))
            {
                clrscr();
                btnSave.Text = "Submit";
                hfPKEdit.Value = "0";
                GetSetClass(false, true);
                GetListData();
            }
        }

        void GetListData()
        {
            List<Entity.ConfigurationHead> lst = new List<Entity.ConfigurationHead>();
            lst = BAL.ConfigurationHeadMastermgmt.GetConfigurationHeadData(0, -1);
            BindData(lst);
        }
        void BindData(List<Entity.ConfigurationHead> lst)
        {
            lstvQualifyingHeadMaster.DataSource = lst;
            lstvQualifyingHeadMaster.DataBind();
        }
        protected void ddlInputType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt64(ddlInputType.SelectedItem.Value) > 0)
            {
                //List<Entity.QualifyingHeadMaster> Description = new List<Entity.QualifyingHeadMaster>();
                //Description = BAL.QualifyingHeadMastermgmt.GetDescriptionData(ddlInputType.SelectedItem.Value);
                //lblDescription.Visible = true;
                //lblDescription.Text = Description[0].Description;
                //txtMinInputValue.Text = string.Empty;
                //txtMaxInputValue.Text = string.Empty;
                //txtMaxInputValue.Enabled = true;

                if (Convert.ToInt64(ddlInputType.SelectedItem.Value) == 2)
                {
                    divMinMaxDate.Visible = true;
                }
                else
                {
                    divMinMaxDate.Visible = false;
                }

                if (Convert.ToInt64(ddlInputType.SelectedItem.Value) == 3 || Convert.ToInt64(ddlInputType.SelectedItem.Value) == 12)
                {
                    divMinMaxValues.Visible = true;
                }
                else
                {
                    divMinMaxValues.Visible = false;
                }
                if (Convert.ToInt64(ddlInputType.SelectedItem.Value) == 15 || Convert.ToInt64(ddlInputType.SelectedItem.Value) == 5 || Convert.ToInt64(ddlInputType.SelectedItem.Value) == 14)
                {
                    divTemplateDropdownMaster.Visible = true;
                }

                else
                {
                    divTemplateDropdownMaster.Visible = false;
                }
                if (Convert.ToInt64(ddlInputType.SelectedItem.Value) == 10)
                {
                    DivMaxLength.Visible = true;
                    divRegex.Visible = true;
                }
                else
                {
                    DivMaxLength.Visible = false;
                    divRegex.Visible = false;
                }
                if (Convert.ToInt64(ddlInputType.SelectedItem.Value) == 15)
                {
                    divChildDropdown.Visible = true;
                }
                else
                {
                    divChildDropdown.Visible = false;

                }
            }
            else
            {
                lblDescription.Text = string.Empty;
                lblDescription.Visible = false;
            }
        }

        protected void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            if (!(IsDelete && Event.Find(x => x.EventName.Contains("Delete")) != null))
            {
                msg.GetMsg(this.Page, "QualifyingHeadMaster", "DR");
                return;

            }
            string IDs = "";
            foreach (ListViewItem item in lstvQualifyingHeadMaster.Items)
            {
                CheckBox cb = (CheckBox)item.FindControl("Chk_select");
                if (cb.Checked)
                {
                    HiddenField hf = (HiddenField)item.FindControl("hfDKId");
                    IDs += hf.Value + ",";
                }
            }
            if (IDs != "")
            {
                int lst = BAL.ConfigurationHeadMastermgmt.DeleteConfigurationHead(IDs, 0, "", "", Event.Find(x => x.EventName.Contains("Delete")).EventId, Guid.NewGuid().ToString());
                if (lst == 0)
                {
                    msg.GetMsg(this.Page, "ConfigurationForm", "D");
                }
                else
                {
                    msg.GetMsg(this.Page, "ConfigurationForm", "DE");
                }
                GetListData();
            }
            else
            {
                msg.GetMsg(this.Page, "ConfigurationForm", "SD");
            }
            GetSetClass(false, true);

        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            List<Entity.ConfigurationHead> lst = new List<Entity.ConfigurationHead>();
            var query = (from v in BAL.ConfigurationHeadMastermgmt.GetConfigurationHeadData(0, -1)
                         select new
                         {
                             v.FormTitle,
                             ConfigurationHeadName = v.ConfigurationHeadName,
                             HeadNote = v.HeadNote,
                             InputType = v.InputType,
                             MinInputValue = v.MinInputValue,
                             MaxInputValue = v.MaxInputValue,
                             DisplayPreferenceNo = v.DisplayPreferenceNo,
                             IsCompulsaryEntry = v.IsCompulsaryEntry,
                             TemplateDropdownName = v.TemplateDropdownName,
                             Remark = v.TemplateDropdownName
                         }).ToList();
            ListConversion.ExporttoExcel(ListConversion.ToDataTable(query));
        }

        protected void lstvQualifyingHeadMaster_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditData")
            {
                EditData(e.CommandArgument.ToString());
            }
        }

        public void IsVisiblefield(bool IsVisiblefield)
        {
            ddlInputType.Enabled = IsVisiblefield;
        }
        public void EditData(string pk)
        {
            hfPKEdit.Value = pk;
            List<Entity.ConfigurationHead> lstObjHeadMaster = new List<Entity.ConfigurationHead>();
            lstObjHeadMaster = BAL.ConfigurationHeadMastermgmt.GetConfigurationHeadData(Convert.ToInt32(hfPKEdit.Value), -1);
            txtMaxInputValue.Enabled = true;
            if (lstObjHeadMaster.Count > 0)
            {
                IsVisiblefield(false);
                btnSave.Text = "Update";
                txtQualifyingHeadName.Text = lstObjHeadMaster.First().ConfigurationHeadName;
                txtHeadNoteforStudent.Text = lstObjHeadMaster.First().HeadNote;
                ddlInputType.SelectedValue = lstObjHeadMaster.First().InputTypeId.ToString();
                ddlFormname.SelectedValue = lstObjHeadMaster.First().FormId.ToString();
                ddlFormname_SelectedIndexChanged(null, null);
                ddlFormComponent.SelectedValue = lstObjHeadMaster.First().FormComponentMasterId.ToString();
                if (lstObjHeadMaster.First().InputTypeId == 3 || lstObjHeadMaster.First().InputTypeId == 12 || lstObjHeadMaster.First().InputTypeId == 9)
                {
                    if (Convert.ToInt64(ddlInputType.SelectedItem.Value) == 9)
                    {
                        divMinMaxValues.Visible = true;
                        txtMinInputValue.Text = lstObjHeadMaster.First().MinInputValue.ToString();
                        txtMaxInputValue.Text = lstObjHeadMaster.First().MaxInputValue.ToString();
                        txtMaxInputValue.Enabled = false;
                    }
                }
                if (lstObjHeadMaster.First().InputTypeId == 3 || lstObjHeadMaster.First().InputTypeId == 12)
                {
                    divMinMaxValues.Visible = true;
                    txtMinInputValue.Text = lstObjHeadMaster.First().MinInputValue.ToString();
                    txtMaxInputValue.Text = lstObjHeadMaster.First().MaxInputValue.ToString();
                }
                if (lstObjHeadMaster.First().InputTypeId == 2)
                {
                    divMinMaxDate.Visible = true;
                    txtMinDate.Text = lstObjHeadMaster.First().MinInputValue.ToString();
                    txtMaxDate.Text = lstObjHeadMaster.First().MaxInputValue.ToString();
                }
                if (Convert.ToInt64(ddlInputType.SelectedItem.Value) == 10)
                {
                    DivMaxLength.Visible = true;
                    txtMaxLength.Text = lstObjHeadMaster.First().MaxLength.ToString();
                    divRegex.Visible = true;
                    ddlValidationType.SelectedValue = lstObjHeadMaster.First().RegexMasterId.ToString();
                }
                if (Convert.ToInt64(ddlInputType.SelectedItem.Value) == 15)
                {
                    divChildDropdown.Visible = true;
                    ddlChildDropDownHead.SelectedValue = lstObjHeadMaster.First().ChildDBId.ToString();
                }
                if (lstObjHeadMaster.First().InputTypeId == 5 || lstObjHeadMaster.First().InputTypeId == 14)
                {
                    divTemplateDropdownMaster.Visible = true;
                    ddlTemplateDropdownMaster.SelectedValue = lstObjHeadMaster.First().TemplateDropdownMasterId.ToString();

                }
                else
                {
                    ddlTemplateDropdownMaster.SelectedValue = lstObjHeadMaster.First().TemplateDropdownMasterId.ToString();
                }

                txtQualifyingHeadDisplayPreferenceNo.Text = lstObjHeadMaster.First().DisplayPreferenceNo.ToString();
                chkIsCompulsaryEntry.Checked = lstObjHeadMaster.First().IsCompulsaryEntry;
                chkCompositeUniqueKey.Checked = lstObjHeadMaster.First().IsCompositeUniqueKey;
                chkSarchableDrp.Checked = lstObjHeadMaster.First().IsSearchableDropdown ;
                chkUniqueKey.Checked = lstObjHeadMaster.First().IsUniqueKey;
                txtRemark.Text = lstObjHeadMaster.First().Remark;
                GetSetClass(true, false);
            }
        }

        protected void ddlFormname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFormname.SelectedIndex > 0)
            {
                LoadChildDropDownByFormId();
                LoadFormComponent();
            }

        }

       
    }
}