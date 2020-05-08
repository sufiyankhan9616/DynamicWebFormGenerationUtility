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
    public partial class CheckQueryDeatils : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 OfficeId = 1234;
            Int32  FormId = 12;
            string Dist = "ABD";
            string Tal = "MAN";
            string OtherSession = "OIP";
            string Userid = "1234";
            string RoleName = "RO";
            string RoleId = "ROH";
            string username = "Admin";
            EncryptDecryptQueryString _encrDecrpOBJ = new EncryptDecryptQueryString();
            //string EOfficeId = _encrDecrpOBJ.Encrypt(OfficeId.ToString (), ConfigurationManager.AppSettings["GenericKey"]);
            //string EFormId = _encrDecrpOBJ.Encrypt(FormId.ToString(), ConfigurationManager.AppSettings["GenericKey"]);
            //string EDistId = _encrDecrpOBJ.Encrypt(Dist.ToString(), ConfigurationManager.AppSettings["GenericKey"]);
            //string ETalId = _encrDecrpOBJ.Encrypt(Tal.ToString(),ConfigurationManager.AppSettings["GenericKey"]);
            //string EOtherSession = _encrDecrpOBJ.Encrypt(OtherSession.ToString(), ConfigurationManager.AppSettings["GenericKey"]);
            //string EUserid = _encrDecrpOBJ.Encrypt(Userid.ToString(), ConfigurationManager.AppSettings["GenericKey"]);
            //string ERoleName = _encrDecrpOBJ.Encrypt(RoleName.ToString(), ConfigurationManager.AppSettings["GenericKey"]);
            //string ERoleId = _encrDecrpOBJ.Encrypt(RoleId.ToString(), ConfigurationManager.AppSettings["GenericKey"]);
            //and then Pass value in query strinng
            string url = "OfficeId=" + OfficeId.ToString() + "&Formid=" + FormId.ToString() + "&DistCode=" + Dist.ToString() + "&TalCode=" + Tal.ToString() + "&OtherSession=" + OtherSession.ToString() + "&RoleId=" + RoleId.ToString() + "&RoleName=" + RoleName.ToString() + "&UserId=" + Userid.ToString() + "&UserName=" + username.ToString();
            //url = _encrDecrpOBJ.Encrypt(url, ConfigurationManager.AppSettings["GenericKey"]);
            Response.Redirect("GenericQuery.aspx?" + url);
        }
    }
}