using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using DynamicWebFormGenerationUtility.Common;
using DynamicWebFormGenerationUtility.BAL;
using DynamicWebFormGenerationUtility.DAL;
using DynamicWebFormGenerationUtility.Entity;

namespace DynamicWebFormGenerationUtility.UIL
{
    public partial class TemplateDataBinding : root
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetSetClass(true, false);
            }
        }

        void LoadNormalDropDown()
        {
            BAL.FillDropdown bfd = new BAL.FillDropdown();
            bfd.LoadTemplateDropDown(ddlTamplateMaster);
        }
        void LoadCascadingBaseTemplateDropDown()
        {
            BAL.FillDropdown bfd = new BAL.FillDropdown();
            bfd.LoadTemplateDropDown(ddlBaseTamplate);
        }
        void LoadCascadingBaseTemplateDropDownValues()
        {
            BAL.FillDropdown bfd = new BAL.FillDropdown();
            bfd.CascadingDropDownTemplate(ddlBaseTemplateValue, ddlBaseTamplate.SelectedValue.ToString () , "BaseDropdownLoad");
        }
        protected void lstvTemplateMaster_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditData")
            {
                EditData(Convert .ToInt32 ( e.CommandArgument.ToString ()));
            }

        }
        public void EditData(Int32  pk)
        {
            hfPKEdit.Value = pk.ToString ();
            List<Entity.ParameterMaster> lst = new List<Entity.ParameterMaster>();
            lst = BAL.ParameterMasterMGMT.GetDropdownType(pk);
          
                if (lst.Count > 0)
            {

                foreach (var value in lst)
                {
                    if (value.BaseParameterId == 0)
                    {
                        DivNormal.Visible = true;
                        btnSave.Text = "Update";
                        rblDataBinding.SelectedValue = "1";
                        rblDataBinding_SelectedIndexChanged(null, null);
                        ddlTamplateMaster.SelectedValue = value.TamplateDropDownId.ToString();
                        txtDropdownValue.Text = value.ParameterName.ToString();
                    }
                    else
                    {
                        DivCascading.Visible = true;
                        btnCascadingSave .Text = "Update";
                        rblDataBinding.SelectedValue = "2";
                        rblDataBinding_SelectedIndexChanged(null, null);
                        ddlBaseTamplate.SelectedValue = value.MainParameter.ToString();
                        LoadCascadingBaseTemplateDropDownValues();
                        ddlBaseTemplateValue.SelectedValue = value.BaseParameterId  .ToString ();
                        LoadCascadingTemplateDropDown();
                        ddlTemplate.SelectedValue = value.TamplateDropDownId  .ToString();
                        txttemplate.Text = value.ParameterName.ToString();
                    }
                    
             }
              
                GetSetClass(true, false);
            }
        }
        protected void tab_Click(object sender, EventArgs e)
        {
            if (sender.Equals(lnkDetails))
            {
                Clear();
                btnSave.Text = "Submit";
                btnCascadingSave .Text = "Submit";
                hfPKEdit.Value = "0";
                GetSetClass(true, false);
            }
            else if (sender.Equals(lnklist))
            {
                Clear();
                btnSave.Text = "Submit";
                btnCascadingSave.Text = "Submit";
                hfPKEdit.Value = "0";
                GetSetClass(false, true);
                GetListData(0);
            }
        }
        void GetListData(int parameterId)
        {
            List<Entity.ParameterMaster > lst = new List<Entity.ParameterMaster>();
            lst = BAL.ParameterMasterMGMT.GetDropdownType(parameterId);
            BindData(lst);
           
        }
        void BindData(List<Entity.ParameterMaster > lst)
        {
            lstvTemplateMaster.DataSource = lst;
            lstvTemplateMaster.DataBind();
        }
        void GetSetClass(bool IsAdd, bool IsList)
        {
            if (IsAdd)
            {

                DivCascading.Attributes["class"] = "";
                DivNormal.Attributes["class"] = "";
                list.Attributes["class"] = "";
                DivCascading.Attributes.Add("class", "tab-pane fade in active");
                DivNormal.Attributes.Add("class", "tab-pane fade in active");
                list.Attributes.Add("class", "tab-pane fade in");
                lnklist.Visible = true;
                lnkDetails.Visible = false;
                btnDeleteSelected.Visible = false;
                btnExportExcel.Visible = false;
                divRadioButton.Visible = true ;
                list.Visible = false;

            }
            if (IsList)
            {
                DivCascading.Attributes["class"] = "";
                DivNormal.Attributes["class"] = "";
                list.Attributes["class"] = "";
                DivCascading.Attributes.Add("class", "tab-pane fade in");
                DivNormal.Attributes.Add("class", "tab-pane fade in");
                list.Attributes.Add("class", "tab-pane fade in active");
                lnklist.Visible = false;
                lnkDetails.Visible = true;
                btnDeleteSelected.Visible = true;
                btnExportExcel.Visible = true;
                list.Visible = true;
                divRadioButton.Visible = false;
            }
        }
        void LoadCascadingTemplateDropDown()
        {
            BAL.FillDropdown bfd = new BAL.FillDropdown();
            bfd.CascadingDropDownTemplate(ddlTemplate, ddlBaseTemplateValue.SelectedValue.ToString(), "TamplateDropdownLoad");
        }
        private void InsertNormalRecord()
        {
            Entity.ParameterMaster obj = new Entity.ParameterMaster();
            if (hfPKEdit.Value != "0")
            {
                if (!(IsUpdate && Event.Find(x => x.EventName.Contains("Update")) != null))
                {
                    msg.GetMsg(this.Page, "TemplateDataBinding", "UR");
                    return;
                }
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtDropdownValue .Text, "^[a-zA-Z ]"))
                {
                    msg.GetMsg(this.Page, "TemplateDataBinding", "ANC");
                    txttemplate.Text.Remove(txtDropdownValue.Text.Length - 1);
                    return;
                }
                obj.ParameterId = hfPKEdit.Value.ToInt32();
                obj.EventId = Event.Find(x => x.EventName.Contains("Update")).EventId;
            }
            else
            {
                if (!(IsInsert && Event.Find(x => x.EventName.Contains("Insert")) != null))
                {
                    msg.GetMsg(this.Page, "TemplateDataBinding", "SR");
                    return;
                }
                obj.ParameterId = 0;
                obj.EventId = Event.Find(x => x.EventName.Contains("Insert")).EventId;
            }

             obj.TamplateDropDownId = Convert .ToInt32 (ddlTamplateMaster.SelectedValue);
                obj.BaseParameterId = 0;
                obj.EventId = Event.Find(x => x.EventName.Contains("Insert")).EventId;
            //obj.UserId = Convert.ToInt32(Session["UserId"].ToString());
              obj.UserId = 0;
                obj.DropdownValue = txtDropdownValue.Text;
                obj.IpAddr = "";
                DataSet dsget = BAL.ParameterMasterMGMT.InsertDropdownEntry(obj);
                msg.GetMsg(this.Page, dsget.Tables[0].Rows[0]["msg"].ToString (), "");
            ddlTamplateMaster.SelectedIndex = -1;
            txtDropdownValue.Text = string.Empty;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            InsertNormalRecord();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void rblDataBinding_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblDataBinding.SelectedValue== "1")
            {
                DivNormal.Visible = true;
                LoadNormalDropDown();
            }
            else
            {
                DivNormal.Visible = false ;
            }
            if (rblDataBinding.SelectedValue=="2")
            {
                DivCascading.Visible = true;
                LoadCascadingBaseTemplateDropDown();
            }
            else
            {
                DivCascading.Visible = false ;
            }
        }

        protected void ddlBaseTamplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCascadingBaseTemplateDropDownValues();
        }

        protected void ddlBaseTemplateValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCascadingTemplateDropDown();
        }
        private void InsertUpdateCascadingDropdownRecord()
        {
            Entity.ParameterMaster obj = new Entity.ParameterMaster();
            if (hfPKEdit.Value != "0")
            {
                if (!(IsUpdate && Event.Find(x => x.EventName.Contains("Update")) != null))
                {
                    msg.GetMsg(this.Page, "TemplateDataBinding", "UR");
                    return;
                }
                if (!System.Text.RegularExpressions.Regex.IsMatch(txttemplate.Text, "^[a-zA-Z ]"))
                {
                    msg.GetMsg(this.Page, "TemplateDataBinding", "ANC");
                    txttemplate.Text.Remove(txttemplate.Text.Length - 1);
                    return;
                }
                obj.ParameterId   = hfPKEdit.Value.ToInt32();
                obj.EventId = Event.Find(x => x.EventName.Contains("Update")).EventId;
            }
            else
            {
                if (!(IsInsert && Event.Find(x => x.EventName.Contains("Insert")) != null))
                {
                    msg.GetMsg(this.Page, "TemplateDataBinding", "SR");
                    return;
                }
                obj.ParameterId = 0;
                obj.EventId = Event.Find(x => x.EventName.Contains("Insert")).EventId;
            }

            //child
            obj.BaseParameterId = Convert.ToInt32(ddlBaseTemplateValue.SelectedValue );
            //Subchile for Entry
            obj.TamplateDropDownId = Convert.ToInt32(ddlTemplate .SelectedValue);
            obj.UserId = 0;
            obj.DropdownValue = txttemplate.Text.Trim();
            DataSet dsget = BAL.ParameterMasterMGMT.InsertDropdownEntry(obj);
            if (dsget.Tables [0].Rows .Count >0 )
            { 
               msg.GetMsg(this.Page, dsget.Tables[0].Rows[0]["msg"].ToString(), "");
                btnCascadingReset_Click(null , null);
            }
            
        }
        protected void btnCascadingSave_Click(object sender, EventArgs e)
        {
           
            InsertUpdateCascadingDropdownRecord();
            
        }
       
        protected void btnCascadingReset_Click(object sender, EventArgs e)
        {
            Clear();


        }
        void Clear()
        {
            txtDropdownValue.Text = "Submit";
            txttemplate.Text = "Submit";
            LoadNormalDropDown();
            txtDropdownValue.Text = string.Empty;
            ddlBaseTamplate.SelectedIndex = -1;
            LoadCascadingBaseTemplateDropDownValues();
            LoadCascadingTemplateDropDown();
            txttemplate.Text = string.Empty;
            hfPKEdit.Value = "0";
        }
        protected void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {

        }
    }
}