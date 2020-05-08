using DynamicWebFormGenerationUtility.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynamicWebFormGenerationUtility.UIL
{
    public partial class TemplateMaster : root
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetListData();
                GetSetClass(true, false);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Entity.TemplateMaster objConfigurationHead = new Entity.TemplateMaster();
                if (hfPKEdit.Value != "0")
                {
                    if (!(IsUpdate && Event.Find(x => x.EventName.Contains("Update")) != null))
                    {
                        msg.GetMsg(this.Page, "TemplateMaster", "UR");
                        return;
                    }
                    objConfigurationHead.TemplateDropDownId = hfPKEdit.Value.ToInt32();
                    objConfigurationHead.EventId = Event.Find(x => x.EventName.Contains("Update")).EventId;
                }
                else
                {
                    if (!(IsInsert && Event.Find(x => x.EventName.Contains("Insert")) != null))
                    {
                        msg.GetMsg(this.Page, "TemplateMaster", "SR");
                        return;
                    }
                    objConfigurationHead.TemplateDropDownId = 0;
                    objConfigurationHead.EventId = Event.Find(x => x.EventName.Contains("Insert")).EventId;
                }
                objConfigurationHead.TemplateDropdownName = txttemplatename.Text;
                objConfigurationHead.UserId = 0;
                objConfigurationHead.EventId = 0;
                objConfigurationHead.HostName = "";
                objConfigurationHead.IpAddr = "";
                objConfigurationHead.TransactionId = "";
                int check = BAL.TemplateMastermgmt.AddUpdateTemplateMaster(objConfigurationHead);
                if (check > 0)
                {
                    if (hfPKEdit.Value != "0")
                    {
                        msg.GetMsg(this.Page, "TemplateMaster", "U");
                        Clrscr();
                        GetListData();
                    }
                    else
                    {
                        msg.GetMsg(this.Page, "TemplateMaster", "I");
                        Clrscr();
                        GetListData();
                    }
                }
                else if (check == -1)
                {
                    msg.GetMsg(this.Page, "TemplateMaster", "AE");
                }
                else
                {
                    msg.GetMsg(this.Page, "TemplateMaster", "E");
                }
            }
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            List<Entity.TemplateMaster> lst = new List<Entity.TemplateMaster>();
            var query = (from v in BAL.TemplateMastermgmt.GetTemplateMasterData(0, -1)
                         select new
                         {
                             v.TemplateDropdownName,
                         }).ToList();
            ListConversion.ExporttoExcel(ListConversion.ToDataTable(query));
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
            List<Entity.TemplateMaster> lst = new List<Entity.TemplateMaster>();
            lst = BAL.TemplateMastermgmt.GetTemplateMasterData(0, -1);
            BindData(lst);
        }
        void BindData(List<Entity.TemplateMaster> lst)
        {
            lstvTemplateMaster.DataSource = lst;
            lstvTemplateMaster.DataBind();
        }
        void Clrscr()
        {
            txttemplatename.Text = "";
            btnSave.Text = "Save";
            hfPKEdit.Value = "0";
        }

        public void EditData(string pk)
        {
            hfPKEdit.Value = pk;
            List<Entity.TemplateMaster> lstObjHeadMaster = new List<Entity.TemplateMaster>();
            lstObjHeadMaster = BAL.TemplateMastermgmt.GetTemplateMasterData(Convert.ToInt32(hfPKEdit.Value), -1);
            if (lstObjHeadMaster.Count > 0)
            {
                btnSave.Text = "Update";
                txttemplatename.Text = lstObjHeadMaster.First().TemplateDropdownName;
                GetSetClass(true, false);
            }
        }

        protected void lstvTemplateMaster_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditData")
            {
                EditData(e.CommandArgument.ToString());
            }
        }

        protected void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            if (!(IsDelete && Event.Find(x => x.EventName.Contains("Delete")) != null))
            {
                msg.GetMsg(this.Page, "TemplateMaster", "DR");
                return;

            }
            string IDs = "";
            foreach (ListViewItem item in lstvTemplateMaster.Items)
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
                String IpAddress = "";
                String MacAddress = "";
                int lst = BAL.TemplateMastermgmt.DeleteTemplateMaster(IDs, Event.Find(x => x.EventName.Contains("Insert")).EventId, Guid.NewGuid().ToString(), IpAddress, MacAddress);
                if (lst == 1)
                {
                    msg.GetMsg(this.Page, "TemplateMaster", "D");
                }
                else
                {
                    msg.GetMsg(this.Page, "TemplateMaster", "DE");
                }
                GetListData();
            }
            else
            {
                msg.GetMsg(this.Page, "TemplateMaster", "SD");
            }
            GetSetClass(false, true);
        }

        protected void btnExportExcel_Click1(object sender, EventArgs e)
        {
            List<Entity.TemplateMaster> lst = new List<Entity.TemplateMaster>();
            var query = (from v in BAL.TemplateMastermgmt.GetTemplateMasterData(0, -1)
                         select new
                         {
                             v.TemplateDropdownName,
                         }).ToList();
            ListConversion.ExporttoExcel(ListConversion.ToDataTable(query));
        }
    }
}