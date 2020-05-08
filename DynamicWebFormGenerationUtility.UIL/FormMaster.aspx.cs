using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DynamicWebFormGenerationUtility.Common;
using System.Data;

namespace DynamicWebFormGenerationUtility.UIL
{
    public partial class FormMaster : root
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["sortname"] = "";
                ViewState["sortexp"] = "";
                GetSetClass(true, false);
                LoadFormName();
            }
        }

        void LoadFormName()
        {
            BAL.FillDropdown bfd = new BAL.FillDropdown();
            bfd.LoadFormname(ddlFormname);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Entity.FormMaster objConfigurationHead = new Entity.FormMaster();
                if (hfPKEdit.Value != "0")
                {
                    if (!(IsUpdate && Event.Find(x => x.EventName.Contains("Update")) != null))
                    {
                        msg.GetMsg(this.Page, "FormMaster", "UR");
                        return;
                    }
                    objConfigurationHead.FormId = hfPKEdit.Value.ToInt32();
                    objConfigurationHead.EventId = Event.Find(x => x.EventName.Contains("Update")).EventId;
                }
                else
                {
                    if (!(IsInsert && Event.Find(x => x.EventName.Contains("Insert")) != null))
                    {
                        msg.GetMsg(this.Page, "FormMaster", "SR");
                        return;
                    }
                    objConfigurationHead.FormId = 0;
                    objConfigurationHead.EventId = Event.Find(x => x.EventName.Contains("Insert")).EventId;
                }
                if (ViewState["dtData"] == null)

                {
                    dt.Columns.Add("ComponentName");
                    dt.Columns.Add("SeqNo");
                    dt.Columns.Add("id");

                    DataRow dr = dt.NewRow();
                    dr[0] = txtFormName.Text;
                    dr[1] = 1;
                    dr[2] = 0;
                    dt.Rows.Add(dr);
                    ViewState["dtData"] = dt;

                }
                else
                {
                    DataTable dt = (DataTable)ViewState["dtData"];
                    dt.Columns.Remove("Validationid");
                    ViewState["dtData"] = dt;
                }
                objConfigurationHead.DtComponent =(DataTable ) ViewState["dtData"];
                objConfigurationHead.FormName = txtFormName.Text;
                objConfigurationHead.FormTitle = txtFormTitle.Text;
                objConfigurationHead.Remarks = txtRemark.Text;
                objConfigurationHead.HostName = "";
                objConfigurationHead.IpAddr = "";
                objConfigurationHead.UserId = 0;
                objConfigurationHead.RefFormId = ddlFormname.SelectedValue.ToInt32();
                int check = BAL.FormMastermgmt.AddUpdateFormMaster(objConfigurationHead);
                if (check > 0)
                {
                    if (hfPKEdit.Value != "0")
                    {
                        msg.GetMsg(this.Page, "FormMaster", "U");
                        Clrscr();
                        GetListData();
                        GetSetClass(false, true);
                       
                    }
                    else
                    {
                        msg.GetMsg(this.Page, "FormMaster", "I");
                        Clrscr();
                        GetListData();
                       
                    }
                }
                else if (check == -3)
                {
                    msg.GetMsg(this.Page, "Record Freezed, You Can't Insert And Update.", "");
                }
                else if (check == -1)
                {
                    msg.GetMsg(this.Page, "FormMaster", "AE");
                }
                else
                {
                    msg.GetMsg(this.Page, "FormMaster", "E");
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Clrscr();
        }

        protected void lstvFormMaster_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditData")
            {
                EditData(e.CommandArgument.ToString());
            }
            if (e.CommandName == "FreezData")
            {
                HiddenField Form_ID = e.Item.FindControl("hfDKId") as HiddenField;
                Entity.FormMaster objConfigurationHead = new Entity.FormMaster();
                objConfigurationHead.FormId = Form_ID.Value.ToInt32();
                string FreezValue = e.CommandArgument.ToString();
                if (FreezValue == "Freez")
                {
                    objConfigurationHead.Is_Freez = "1";
                }
                else
                {
                    objConfigurationHead.Is_Freez = "0";
                }
                DataSet check = BAL.FormMastermgmt.FreezFormMaster(objConfigurationHead);
                if (check.Tables[0].Rows.Count > 0)
                {
                    //msg.GetMsg(this.Page, check.Tables[0].Rows[0]["Msg"].ToString(), "");
                    string String = check.Tables[0].Rows[0]["Msg"].ToString();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('"+ String + "');location.href = 'FormMaster.aspx';", true);
                }
               else  if (check.Tables[1].Rows.Count > 0)
                {
                    //msg.GetMsg(this.Page, check.Tables[1].Rows[0]["Msg"].ToString(), "");
                    string String = check.Tables[1].Rows[0]["Msg"].ToString();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + String + "');location.href = 'FormMaster.aspx';", true);
                }
                GetListData();
            }
        }

        public void EditData(string pk)
        {
            hfPKEdit.Value = pk;
            Divform.Visible = false;
            List<Entity.FormMaster> lstObjHeadMaster = new List<Entity.FormMaster>();
            lstObjHeadMaster = BAL.FormMastermgmt.GetFormMasterData(Convert.ToInt32(hfPKEdit.Value), -1);
            if (lstObjHeadMaster.Count > 0)
            {
                btnSave.Text = "Update";
                btnAdd.Text = "Add";
                txtFormName.Text = lstObjHeadMaster.First().FormName;
                txtFormTitle.Text = lstObjHeadMaster.First().FormTitle;
                txtRemark.Text = lstObjHeadMaster.First().Remarks.ToString();
                GetComponentData(Convert.ToInt32(hfPKEdit.Value));
                GetSetClass(true, false);
            }
        }
        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            List<Entity.FormMaster> lst = new List<Entity.FormMaster>();
            var query = (from v in BAL.FormMastermgmt.GetFormMasterData(0, -1)
                         select new
                         {
                             v.FormName,
                             v.FormTitle,
                             v.Remarks
                         }).ToList();
            ListConversion.ExporttoExcel(ListConversion.ToDataTable(query));
        }

        protected void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            if (!(IsDelete && Event.Find(x => x.EventName.Contains("Delete")) != null))
            {
                msg.GetMsg(this.Page, "FormMaster", "DR");
                return;

            }
            string IDs = "";
            foreach (ListViewItem item in lstvFormMaster.Items)
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
                int lst = BAL.FormMastermgmt.DeleteFormMaster(IDs, 0, "", "", Event.Find(x => x.EventName.Contains("Delete")).EventId, Guid.NewGuid().ToString());
                if (lst == 1)
                {
                    msg.GetMsg(this.Page, "ConfigurationForm", "D");
                }
                if (lst == -3)
                {
                    msg.GetMsg(this.Page, "Record Freezed, You Can't Delete And Update.", "");
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
            }
        }

        protected void tab_Click(object sender, EventArgs e)
        {
            if (sender.Equals(lnkDetails))
            {
                Clrscr();
                btnSave.Text = "Submit";
                hfPKEdit.Value = "0";
                GetSetClass(true, false);
            }
            else if (sender.Equals(lnklist))
            {
                Clrscr();
                btnSave.Text = "Submit";
                hfPKEdit.Value = "0";
                GetSetClass(false, true);
                GetListData();
            }
        }


        void GetListData()
        {
            List<Entity.FormMaster> lst = new List<Entity.FormMaster>();
            lst = BAL.FormMastermgmt.GetFormMasterData(0, -1);
            BindData(lst);
        }
        void BindData(List<Entity.FormMaster> lst)
        {
            lstvFormMaster.DataSource = lst;
            lstvFormMaster.DataBind();
        }
        void GetComponentData(int Formid)
        {
            DataTable dtcomp = new DataTable();
            dtcomp = BAL.FormMastermgmt.GetFormComponentData(Formid, 1);
            if (dtcomp.Rows.Count > 0)
            {
                ViewState["dtData"] = dtcomp;
            
            }
            BindComponentData(dtcomp);



        }
        void BindComponentData(DataTable dtitem)
        {
            LWComponent.DataSource = dtitem;
            LWComponent.DataBind();
        }

        void Clrscr()
        {
            txtFormName.Text = "";
            txtFormTitle.Text = "";
            txtRemark.Text = "";
            btnSave.Text = "Save";
            hfPKEdit.Value = "0";
            Divform.Visible = true;
            txtComponent.Text = string.Empty;
            txtCompSeqNo.Text = string.Empty;
            ViewState["dtData"] = null ;
            LWComponent.DataSource = null;
            LWComponent.DataBind();
            LoadFormName();
        }

        DataTable dt = new DataTable();
        protected void btnAdd_Click(object sender, EventArgs e)
        {
          

            if (txtComponent.Text == string.Empty)
            {
                msg.GetMsg(this.Page, "Enter Component Name.", "");
                return;
            }
            if (txtCompSeqNo.Text == string.Empty)
            {
                msg.GetMsg(this.Page, "Enter Component Sequence Number.", "");
                return;
            }

            if (btnAdd.Text == "Add")
            {

                if (ViewState["dtData"] != null)
                {


                    dt = (DataTable)ViewState["dtData"];
                    Boolean ChkValidation = false;
                    if (ViewState["dtData"] != null)
                    {

                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            DataRow dr1 = dt.Rows[i];
                            if (dr1["ComponentName"].ToString() == txtComponent.Text.Trim())
                            {
                                msg.GetMsg(this.Page, "Component Name Already Exist.", "");
                                ChkValidation = true;
                            }

                            if (Convert.ToDecimal(dr1["SeqNo"].ToString()) == Convert.ToDecimal(txtCompSeqNo.Text.Trim()))
                            {
                                msg.GetMsg(this.Page, "Component Sequence Number Alredy Exist.", "");
                                ChkValidation = true;
                            }
                            if (ChkValidation == true)
                            {

                                return;
                            }

                        }
                    }
                }
                else
                {
                    dt.Columns.Add("ComponentName");
                    dt.Columns.Add("SeqNo");
                    dt.Columns.Add("id");
                    dt.Columns.Add("Validationid");
                }
                DataRow dr = dt.NewRow();
                dr["ComponentName"] = txtComponent.Text;
                dr["SeqNo"] = txtCompSeqNo.Text.Trim();
                dr["id"] = 0;
                dr["Validationid"] = 0;
                dt.Rows.Add(dr);
                ViewState["dtData"] = dt;
                if (dt.Rows.Count > 0)
                {
                    LWComponent.DataSource = dt;
                    LWComponent.DataBind();
                }
                  txtComponent.Text = string.Empty;
                    txtCompSeqNo.Text = string.Empty;
            }
            else if (btnAdd.Text == "Update")
            {
                dt = (DataTable)ViewState["dtData"];
                if (ViewState["dtData"] != null)
                {
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        DataRow dr = dt.Rows[i];
                        if (dr["ComponentName"].ToString() == txtComponent.Text.Trim() && dr["ComponentName"].ToString() != ViewState["UpdateComponentName"].ToString())
                        {
                            msg.GetMsg(this.Page, "Component Name Already Exist.", "");
                            return;
                        }
                        if (Convert.ToDecimal(dr["SeqNo"].ToString()) == Convert.ToDecimal(txtCompSeqNo.Text.Trim()) && Convert.ToDecimal(dr["SeqNo"].ToString()) != Convert.ToDecimal(ViewState["SeqNo"].ToString ()))
                        {
                            msg.GetMsg(this.Page, "Component Sequence Number Alredy Exist.", "");
                            return;
                        }

                      

                       
                        if ( dr["ComponentName"].ToString() == ViewState["UpdateComponentName"].ToString())
                        {
                            dr["ComponentName"] = txtComponent.Text;
                            dr["SeqNo"] = txtCompSeqNo.Text;
                            btnAdd.Text = "Add";
                            if (dt.Rows.Count > 0)
                            {
                                LWComponent.DataSource = dt;
                                LWComponent.DataBind();
                            }
                        }

                    }
                    txtComponent.Text = string.Empty;
                    txtCompSeqNo.Text = string.Empty;
                   ViewState["UpdateComponentName"] = null;
                    ViewState["SeqNo"] = null;
                }

            }

        }


        protected void lstvComponent_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            
                if (e.CommandName == "DeleteData")
            {
                HiddenField Hiddenid =  e.Item.FindControl("hfDKValidationId") as HiddenField;
                if (Convert .ToInt32 ( Hiddenid.Value  )== -1)
                {
                    msg.GetMsg(this.Page, "Configuration Head is generated for this component, you cannot delete this record.", "");
                    return;
                }
                if (ViewState["dtData"] != null)
                {
                    
                     dt = (DataTable)ViewState["dtData"];
                    Int32 id = Convert.ToInt32(e.CommandArgument);
                   
                    DataRow dr = dt.Rows[id - 1];
                    dt.Rows.Remove(dr);
                    ViewState["dtData"] = dt;
                    LWComponent.DataSource = dt;
                    LWComponent.DataBind();
                }

            }

            if (e.CommandName == "EditData")
            {
                if (ViewState["dtData"] != null)
                {
                    dt = (DataTable)ViewState["dtData"];
                    Int32 id = Convert.ToInt32(e.CommandArgument);
                    DataRow dr = dt.Rows[id - 1];
                    txtComponent.Text = dr["ComponentName"].ToString();
                    txtCompSeqNo.Text = dr["SeqNo"].ToString();
                    ViewState["UpdateComponentName"] = dr["ComponentName"].ToString();
                    ViewState["SeqNo"]= dr["SeqNo"].ToString();
                    btnAdd.Text = "Update";
                }
                else
                {
                    btnAdd.Text = "Add";

                }
            }
        }
    }
}