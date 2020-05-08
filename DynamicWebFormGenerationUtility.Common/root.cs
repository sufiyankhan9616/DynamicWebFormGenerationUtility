using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DynamicWebFormGenerationUtility.BAL;
namespace DynamicWebFormGenerationUtility.Common
{
    public class root : System.Web.UI.Page
    {

        public List<Entity.Event> Event;
        public string FormName;
        public string UserLevel = "Admin";
        public bool IsInsert = true;
        public bool IsUpdate = true;
        public bool IsDelete = true;
        public bool IsView = true;

        public bool IsApprove = true;
        public bool IsReject = true;
        public bool IsCustom1 = true;
        public bool IsCustom2 = true;
        public bool IsCustom3 = true;
        public bool IsCustom4 = true;


        public enum Level { University, Student, SuperAdmin, GiplAdmin, College, HelpCenter, Admin, Guest };

        public string GetIpAddress()
        {
            if (Request.UserHostAddress != null)
            {
                return Request.UserHostAddress;
            }
            else
            {
                return "NA";
            }
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            FormName = Request.Path;

            //if (UserCookies.UserType == "2" && !FormName.ToLower().Contains("student") && !FormName.ToLower().Contains("payment") && !FormName.ToLower().Contains("printreport"))
            //{
            //    Response.Redirect("~/student/login.aspx");
            //}
            // CHANGED FOR COMMON LOGIN ON 06-02-2019--- ROHIT SHARMA-- comment above line
            Event = BAL.Eventmgmt.GetEventByFormName(FormName.Split('/')[FormName.Split('/').GetLength(0) - 1].ToString().Replace(".aspx", "").Trim());
            checkUserRights();
        }

        public void checkUserRights()
        {
            //if (UserCookies.UserType == "2")
            //{
            //    UserLevel = "Student";

            //    IsInsert = true;
            //    IsUpdate = true;
            //    IsDelete = true;
            //    IsView = true;
            //}

            //else
            //{
            //    List<Entity.Users> UserRights = new List<Entity.Users>();
            //    UserRights = BAL.Usersmgmt.checkUserRights(UserCookies.UserID, FormName);
            //    if (UserRights.Count > 0)
            //    {
            //        IsInsert = UserRights[0].IsInsert;
            //        IsUpdate = UserRights[0].IsUpdate;
            //        IsDelete = UserRights[0].IsDelete;
            //        IsApprove = UserRights[0].IsApprove;
            //        IsReject = UserRights[0].IsReject;
            //        IsCustom1 = UserRights[0].Custom1;
            //        IsCustom2 = UserRights[0].Custom2;
            //        IsCustom3 = UserRights[0].Custom3;
            //        IsCustom4 = UserRights[0].Custom4;
            //    }
            //    else
            //    {
            //        if (UserCookies.UserID != 0)
            //        {
            //            string strRedirect = "~/Master/Dashboard.aspx";
            //            Response.Redirect(strRedirect, false);
            //            return;
            //        }
            //        else
            //        {
            //            //Response.Redirect("http://demovnsgu.vnsgu.net/");
            //            if (System.Web.Configuration.WebConfigurationManager.AppSettings["IsLogoutRedirect"] == "1")
            //            {
            //                Response.Redirect(System.Web.Configuration.WebConfigurationManager.AppSettings["LogoutliveUrl"].ToString());
            //            }
            //            else
            //            {
            //                Response.Redirect("~/UMSLogin.aspx");
            //            }
            //        }



            //    }

            //}




        }

        #region OnError


        protected override void OnError(EventArgs e)
        {
            string ErrorFromName = AppConfiguration.ErrorFromName;
            string ErrorMailSubject = AppConfiguration.ErrorMailSubject;
            string ErrorToEmail = AppConfiguration.ErrorToEmail;
            string ErrorFromEmail = AppConfiguration.ErrorFromEmail;
            string ErrorBCCEmail = AppConfiguration.ErrorBCCEmail;


            string errorInfo = "";
            string source = "";

            // At this point we have information about the error
            HttpContext ctx = HttpContext.Current;
            Exception exception = ctx.Server.GetLastError();


            errorInfo = "<br><b>Offending URL:</b> " + ctx.Request.Url.ToString() + "<br><b>Source:</b> " + exception.Source + "<br><b>Message:</b> " + exception.Message + "<br><b>Stack trace:</b> " + exception.StackTrace;
            source = ctx.Request.Url.ToString();


            // Mail Body
            StringBuilder Mail = new StringBuilder();
            Mail.Append(DateTime.Now.ToString() + "<br/>\n\r");
            Mail.Append(source + "<br/>\n\r");
            Mail.Append(errorInfo + "<br/>\n\r");
            Mail.Append(base.Request.UserHostAddress + "<br/>\n\r");
            Mail.Append(ctx.User.Identity.IsAuthenticated ? ctx.User.Identity.Name : "Unknown" + "<br/>\n\r");
            Mail.Append(DateTime.Now.ToString() + "<br/>\n\r");

            string strMail = Mail.ToString().Replace(" at ", "<br/>at ");

            //Write Error to DB
            ErrorLog(strMail, source);

            //Send Error Email
            if (AppConfiguration.RequiredErrorMail.ToString() == "1")
            {
                //mail.SendMail(ErrorFromEmail, "Error Mail", ErrorToEmail, "", strMail, "Error Mail", "", ErrorBCCEmail, true, "");
                mail.SendMail(ErrorFromEmail, ErrorFromName, ErrorToEmail, "", strMail, ErrorMailSubject, "", ErrorBCCEmail, true, "");
            }

            // --------------------------------------------------
            // To let the page finish running we clear the error
            // --------------------------------------------------  
            ctx.Server.ClearError();

            if (Request.Url.ToString().Contains("/Admin/"))
            {
                base.Response.Redirect("~/Admin/Dashboard.aspx?Msg=This is a System Error, Please Contact Administrator.");
            }
            else
            {
                Server.Transfer(AppConfiguration.Error404);
            }
        }
        #endregion

        void ErrorLog(string ErrorMsg, string source)
        {
            Entity.Error objError = new Entity.Error();
            objError.IpAddress = string.IsNullOrEmpty("") ? HttpContext.Current.Request.UserHostAddress : "";
            objError.Message = ErrorMsg;
            objError.Source = source;
            objError.Browser = Request.Browser.Type;
            objError.UserName = string.IsNullOrEmpty("") ? "End User" : "";
            BAL.Errormgmt.AddUpdateError(objError);
        }

        public string EncryptQueryString(string strQueryString)
        {
            EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
            return objEDQueryString.Encrypt(strQueryString, "G0b1n30y");
        }


    }
}
