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
    public partial class RegexMaster : root
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                GetSetClass(true, false);
                GetListData();
            }
        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Entity.RegexMasterEntitycs  objregex = new Entity.RegexMasterEntitycs();
                if (hfPKEdit.Value != "0")
                {
                    if (!(IsUpdate && Event.Find(x => x.EventName.Contains("Update")) != null))
                    {
                        msg.GetMsg(this.Page, "RegexMaster", "UR");
                        return;
                    }
                    objregex.RegexId  = hfPKEdit.Value.ToInt32();
                    objregex.EventId = Event.Find(x => x.EventName.Contains("Update")).EventId;
                }
                else
                {
                    if (!(IsInsert && Event.Find(x => x.EventName.Contains("Insert")) != null))
                    {
                        msg.GetMsg(this.Page, "RegexMaster", "SR");
                        return;
                    }
                    objregex.RegexId  = 0;
                    objregex.EventId = Event.Find(x => x.EventName.Contains("Insert")).EventId;
                }

                objregex.ValidationName = txtValidationName.Text;
                objregex.ErrMsg = txtErrMsg.Text;
                objregex.ValidationExp = txtValidationExp.Text;
                objregex.HostName = "";
                objregex.IpAddr = "";
                objregex.UserId = 0;
                objregex.TransactionId = "";
                objregex.EventId  =0;
                objregex.Isdelete = false ;
                int check = BAL.FormMastermgmt.AddUpdateRegexMaster(objregex);
                if (check > 0)
                {
                    if (hfPKEdit.Value != "1")
                    {
                        msg.GetMsg(this.Page, "RegexMastre", "U");
                        Clrscr();
                        GetListData();
                        GetSetClass(false, true);
                    }
                    else
                    {
                        msg.GetMsg(this.Page, "RegexMastre", "I");
                        Clrscr();
                        GetListData();
                    }
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
           
        }

        public void EditData(string pk)
        {
            hfPKEdit.Value = pk;
            List<Entity.RegexMasterEntitycs > lstObjHeadMaster = new List<Entity.RegexMasterEntitycs>();
            lstObjHeadMaster = BAL.FormMastermgmt.GEtRegexMasterData  (Convert.ToInt32(hfPKEdit.Value));
            if (lstObjHeadMaster.Count > 0)
            {
                btnSave.Text = "Update";
                txtErrMsg .Text  = lstObjHeadMaster.First().ErrMsg ;
                txtValidationExp .Text = lstObjHeadMaster.First().ValidationExp ;
                txtValidationName .Text = lstObjHeadMaster.First().ValidationName ;

                GetSetClass(true, false);
            }
        }
        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            List<Entity.RegexMasterEntitycs > lst = new List<Entity.RegexMasterEntitycs>();
            var query = (from v in BAL.FormMastermgmt.GEtRegexMasterData (0)
                         select new
                         {
                             v.ValidationName ,
                         }).ToList();
            ListConversion.ExporttoExcel(ListConversion.ToDataTable(query));
        }

        protected void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            if (!(IsDelete && Event.Find(x => x.EventName.Contains("Delete")) != null))
            {
                msg.GetMsg(this.Page, "RegexMastre", "DR");
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
                int lst = BAL.FormMastermgmt.DeleteFormRegex( IDs, 0, "", "", Event.Find(x => x.EventName.Contains("Delete")).EventId, Guid.NewGuid().ToString());
                if (lst == 1)
                {
                    msg.GetMsg(this.Page, "RegexForm", "D");
                }
               
                else
                {
                    msg.GetMsg(this.Page, "RegexForm", "DE");
                }
                GetListData();
            }
            else
            {
                msg.GetMsg(this.Page, "RegexForm", "SD");
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
            List<Entity.RegexMasterEntitycs > lst = new List<Entity.RegexMasterEntitycs>();
            lst = BAL.FormMastermgmt.GEtRegexMasterData (0);
            BindData(lst);
        }
        void BindData(List<Entity.RegexMasterEntitycs > lst)
        {
            lstvFormMaster.DataSource = lst;
            lstvFormMaster.DataBind();
        }
      
       

        void Clrscr()
        {
            txtErrMsg.Text = string.Empty;
            txtValidationExp.Text = string.Empty;
            txtValidationName.Text = string.Empty;
            btnSave.Text = "Save";
            hfPKEdit.Value = "0";
           
        }

       


        protected void lstvComponent_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

            if (e.CommandName == "DeleteData")
            {
                HiddenField Hiddenid = e.Item.FindControl("hfDKValidationId") as HiddenField;
                if (Convert.ToInt32(Hiddenid.Value) == -1)
                {
                    msg.GetMsg(this.Page, "Configuration Head is generated for this component, you cannot delete this record.", "");
                    return;
                }

            }
        }
    }
}