using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using DynamicWebFormGenerationUtility.Common;
namespace DynamicWebFormGenerationUtility.UIL
{
    public partial class GenericQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //String SSOAppID = _encrDecrpOBJ.Encrypt(ConfigurationManager.AppSettings["SSOAppID"]);
                //and then Pass value in query strinng
                EncryptDecryptQueryString _encrDecrpOBJ = new EncryptDecryptQueryString();
                Entity.FormMaster objConfigurationHead = new Entity.FormMaster();
                //string converted = Request.QueryString.ToString();//Request.QueryString.ToString().Replace("/", "");
                ////converted = converted.Replace("+", "");
                //converted = converted.Replace("%", "");
                //string qrystring = converted, ConfigurationManager.AppSettings["GenericKey"]);

                if (Request.QueryString["OfficeId"] != null && Request.QueryString["OfficeId"] != string.Empty)
                {
                    Session["OfficeId"] = Request.QueryString["OfficeId"].ToString();
                    objConfigurationHead.OfficeName = Session["OfficeId"].ToString();
                }
                if (Request.QueryString["DistCode"] != null && Request.QueryString["DistCode"] != string.Empty)
                {
                    Session["DistCode"] = Request.QueryString["DistCode"].ToString();
                    objConfigurationHead.DistName = Session["DistCode"].ToString();
                }
                if (Request.QueryString["TalCode"] != null && Request.QueryString["TalCode"] != string.Empty)
                {
                    Session["TalCode"] = Request.QueryString["TalCode"].ToString();
                    objConfigurationHead.TalName = Session["TalCode"].ToString();
                }
                if (Request.QueryString["OtherSession"] != null && Request.QueryString["OtherSession"] != string.Empty)
                {
                    Session["OtherSession"] = Request.QueryString["OtherSession"].ToString();
                    objConfigurationHead.OtherSession = Session["OtherSession"].ToString();
                }
                if (Request.QueryString["Formid"] != null && Request.QueryString["Formid"] != string.Empty)
                {
                    Session["Formid"] = Request.QueryString["Formid"].ToString();
                    Session["MenuId"] = Session["Formid"];
                    objConfigurationHead.FormId = Convert.ToInt32(Session["Formid"]);
                }
                if (Request.QueryString["RoleId"] != null && Request.QueryString["RoleId"] != string.Empty)
                {
                    Session["RoleId"] = Request.QueryString["RoleId"].ToString();
                    objConfigurationHead.Roleid = Session["RoleId"].ToString();
                }
                if (Request.QueryString["RoleName"] != null && Request.QueryString["RoleName"] != string.Empty)
                {
                    Session["RoleName"] = Request.QueryString["RoleName"].ToString();
                    objConfigurationHead.RoleName = Session["RoleName"].ToString();
                }
                if (Request.QueryString["UserId"] != null && Request.QueryString["UserId"] != string.Empty)
                {
                    Session["UserId"] = Request.QueryString["UserId"].ToString();
                    objConfigurationHead.UserId = Convert.ToInt32(Session["UserId"].ToString());
                }
                if (Request.QueryString["UserName"] != null && Request.QueryString["UserName"] != string.Empty)
                {
                    Session["UserName"] = Request.QueryString["UserName"].ToString();
                    objConfigurationHead.UserName = Session["UserName"].ToString();
                }


                int check = BAL.FormMastermgmt.AddSessionLog(objConfigurationHead);
                if (check == 1)
                {
                    Response.Redirect("Formfilling.aspx");
                }
            }
        }
    }
}