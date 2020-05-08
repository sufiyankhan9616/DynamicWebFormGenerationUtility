using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynamicWebFormGenerationUtility.UIL
{
    public partial class CommonMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadFormName();
            }
        }

        protected void ddlMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMenu.SelectedIndex > 0)
            {
                Session["MenuId"] = ddlMenu.SelectedValue.ToString();
                Session["Formid"] = Session["MenuId"];
                    Response.Redirect("FormFilling.aspx");

            }
            else
            {
                Session["MenuId"] = "0";
            }
        }


        void LoadFormName()
        {
            BAL.FillDropdown bfd = new BAL.FillDropdown();
            bfd.LoadFormname(ddlMenu);
            ddlMenu.Items.RemoveAt(0);
            ddlMenu.Items.Insert(0, new ListItem("Fill Form", "0"));
            if (Session["UserName"] != null)
            { txtUserName.Text = Session["UserName"].ToString(); }
            if (Session["RoleName"] != null)
            {
                txtRoleName.Text = Session["RoleName"].ToString();
            }
        }

    }
}