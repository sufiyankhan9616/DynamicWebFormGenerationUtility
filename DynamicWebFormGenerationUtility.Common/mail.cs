using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace DynamicWebFormGenerationUtility.Common
{
    public class mail
    {
        #region SendMail
        public static bool SendMail(string FromEmail, string FromName, string ToEmails, string ReplyEmail, string MailBody, string MailSubject, string CcEmails, string BccEmails, bool IsHtml, string attPath)
        {
            MailMessage objMail = new MailMessage();
            FromEmail = "shahabhay1994@gmail.com";
            if (!string.IsNullOrEmpty(FromName))
            {
                objMail.From = new MailAddress(FromEmail, FromName);
            }
            else
            {
                objMail.From = new MailAddress(FromEmail);
            }
            if (!string.IsNullOrEmpty(ReplyEmail))
            {
                objMail.ReplyTo = new MailAddress(ReplyEmail);

            }
            if (!string.IsNullOrEmpty(ToEmails))
            {
                objMail.To.Add(ToEmails);
            }
            if (!string.IsNullOrEmpty(CcEmails))
            {
                objMail.CC.Add(CcEmails);
            }
            if (!string.IsNullOrEmpty(BccEmails))
            {
                objMail.Bcc.Add(BccEmails);
            }
            else
            {
                BccEmails = System.Web.Configuration.WebConfigurationManager.AppSettings["ErrorBCCEmail"];
            }
            if (!string.IsNullOrEmpty(attPath))
            {
                Attachment path = new Attachment(attPath);

                objMail.Attachments.Add(path);
            }
            else
            {
                BccEmails = System.Web.Configuration.WebConfigurationManager.AppSettings["ErrorBCCEmail"];
            }
            objMail.Subject = MailSubject;
            objMail.Body = MailBody;
            objMail.IsBodyHtml = IsHtml;
            try
            {
                //objMail.ReplyToList.Add("ums@vnsgu.net");
                //objMail.Headers.Add("Return-Path", "ums@vnsgu.net");
                //SmtpClient client = new SmtpClient("203.77.200.27", 25);
                //client.UseDefaultCredentials = false;
                //client.Port = 25;
                //client.EnableSsl = false;
                //client.Credentials = new System.Net.NetworkCredential("ums@vnsgu.net", "UmsMail2018");
                //client.Send(objMail);
                return true;
            }
            catch (Exception e)
            {
                Exception ex = e;
                HttpContext.Current.Response.Write(ex.Message.ToString());
                HttpContext.Current.Response.Write("Mail Error");
                return false;
            }

        }
        #endregion
        public static bool SendSMSQuickRegistration(string ApplicationNo, string MobileNo, string Password, string AdmissionProcessName)
        {
            //Send Message to given Mobile No
            StringBuilder sbUrlMsg = new StringBuilder();

            sbUrlMsg.Append("http://login.arihantsms.com/vendorsms/pushsms.aspx?user=vnsgu&password=vnsgu@1965&msisdn=" + MobileNo);

            sbUrlMsg.Append("&sid=VNSGUS&msg=");

            sbUrlMsg.AppendLine("Your Quick Registration for admission in " + AdmissionProcessName + " has been completed. Login with User ID " + ApplicationNo + " and Password " + Password + " to complete the application form.");

            sbUrlMsg.AppendLine("&fl=0&gwid=2");

            // creating web request to send sms 
            HttpWebRequest _createRequest = (HttpWebRequest)WebRequest.Create(sbUrlMsg.ToString());
            // getting response of sms
            HttpWebResponse myResp = (HttpWebResponse)_createRequest.GetResponse();
            System.IO.StreamReader _responseStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = _responseStreamReader.ReadToEnd();
            _responseStreamReader.Close();
            myResp.Close();

            return true;
            //ENDSend Message to given Mobile No
        }
        public static bool SendBulkSMS(string ApplicationNo, string MobileNo, string ApplicantName, string SMSText, string AdmissionProcessName)
        {
            //Send Message to given Mobile No
            StringBuilder sbUrlMsg = new StringBuilder();

            sbUrlMsg.Append("http://login.arihantsms.com/vendorsms/pushsms.aspx?user=vnsgu&password=vnsgu@1965&msisdn=" + MobileNo);

            sbUrlMsg.Append("&sid=VNSGUS&msg=");

            sbUrlMsg.AppendLine(SMSText);

            sbUrlMsg.AppendLine("&fl=0&gwid=2");

            // creating web request to send sms 
            HttpWebRequest _createRequest = (HttpWebRequest)WebRequest.Create(sbUrlMsg.ToString());
            //  getting response of sms
            HttpWebResponse myResp = (HttpWebResponse)_createRequest.GetResponse();
            System.IO.StreamReader _responseStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = _responseStreamReader.ReadToEnd();
            _responseStreamReader.Close();
            myResp.Close();

            if (((dynamic)JsonConvert.DeserializeObject(responseString)).ErrorMessage == "Success")
            {
                return true;
            }
            else
            {
                return false;
            }
            //ENDSend Message to given Mobile No
        }

        public static bool SendSMSFinalSubmission(string ApplicationNo, string MobileNo, string AdmissionProcessName)
        {
            //Send Message to given Mobile No
            StringBuilder sbUrlMsg = new StringBuilder();
            //Your Quick Registration for admission in ………………………………… has been completed. Login with User ID ……………………… and Password …………………… to complete the application form.
            sbUrlMsg.Append("http://login.arihantsms.com/vendorsms/pushsms.aspx?user=vnsgu&password=vnsgu@1965&msisdn=" + MobileNo);

            sbUrlMsg.Append("&sid=VNSGUS&msg=");
            sbUrlMsg.AppendLine("Dear Student Your Application With ID:" + ApplicationNo + " Submitted Successfully For " + AdmissionProcessName + ". It Is Mandatory to Verify Application Form at Help Center");
            sbUrlMsg.AppendLine("&fl=0&gwid=2");

            // creating web request to send sms 
            HttpWebRequest _createRequest = (HttpWebRequest)WebRequest.Create(sbUrlMsg.ToString());
            // getting response of sms
            HttpWebResponse myResp = (HttpWebResponse)_createRequest.GetResponse();
            System.IO.StreamReader _responseStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = _responseStreamReader.ReadToEnd();
            _responseStreamReader.Close();
            myResp.Close();

            return true;
            //ENDSend Message to given Mobile No
        }
        public static bool SendSMSPayment(string MobileNo, string AdmissionProcessName)
        {
            //Send Message to given Mobile No
            StringBuilder sbUrlMsg = new StringBuilder();
            //Your Quick Registration for admission in ………………………………… has been completed. Login with User ID ……………………… and Password …………………… to complete the application form.
            sbUrlMsg.Append("http://login.arihantsms.com/vendorsms/pushsms.aspx?user=vnsgu&password=vnsgu@1965&msisdn=" + MobileNo);

            sbUrlMsg.Append("&sid=VNSGUS&msg=");
            sbUrlMsg.Append("Your Submission of Application form and payment has been completed successfully for admission in " + AdmissionProcessName);
            sbUrlMsg.AppendLine("&fl=0&gwid=2");

            // creating web request to send sms 
            HttpWebRequest _createRequest = (HttpWebRequest)WebRequest.Create(sbUrlMsg.ToString());
            // getting response of sms
            HttpWebResponse myResp = (HttpWebResponse)_createRequest.GetResponse();
            System.IO.StreamReader _responseStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = _responseStreamReader.ReadToEnd();
            _responseStreamReader.Close();
            myResp.Close();

            return true;
            //ENDSend Message to given Mobile No
        }
        public static bool SendSMSHelpCenterVerification(string ApplicationNo, string MobileNo, string AdmissionProcessName)
        {
            //Send Message to given Mobile No
            StringBuilder sbUrlMsg = new StringBuilder();
            //Your Quick Registration for admission in ………………………………… has been completed. Login with User ID ……………………… and Password …………………… to complete the application form.
            sbUrlMsg.Append("http://login.arihantsms.com/vendorsms/pushsms.aspx?user=vnsgu&password=vnsgu@1965&msisdn=" + MobileNo);

            sbUrlMsg.Append("&sid=VNSGUS&msg=");
            sbUrlMsg.Append("Your Application form " + ApplicationNo + " successfully verified by helpcenter / college for admission in " + AdmissionProcessName);
            sbUrlMsg.AppendLine("&fl=0&gwid=2");

            // creating web request to send sms 
            HttpWebRequest _createRequest = (HttpWebRequest)WebRequest.Create(sbUrlMsg.ToString());
            // getting response of sms
            HttpWebResponse myResp = (HttpWebResponse)_createRequest.GetResponse();
            System.IO.StreamReader _responseStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = _responseStreamReader.ReadToEnd();
            _responseStreamReader.Close();
            myResp.Close();

            return true;
            //ENDSend Message to given Mobile No
        }
        public static bool SendSMSUniversityVerification(string ApplicationNo, string MobileNo, string AdmissionProcessName)
        {
            //Send Message to given Mobile No
            StringBuilder sbUrlMsg = new StringBuilder();
            //Your Quick Registration for admission in ………………………………… has been completed. Login with User ID ……………………… and Password …………………… to complete the application form.
            sbUrlMsg.Append("http://login.arihantsms.com/vendorsms/pushsms.aspx?user=vnsgu&password=vnsgu@1965&msisdn=" + MobileNo);

            sbUrlMsg.Append("&sid=VNSGUS&msg=");
            sbUrlMsg.Append("Your Application form " + ApplicationNo + " successfully verified by university for admission in  " + AdmissionProcessName);
            sbUrlMsg.AppendLine("&fl=0&gwid=2");

            // creating web request to send sms 
            HttpWebRequest _createRequest = (HttpWebRequest)WebRequest.Create(sbUrlMsg.ToString());
            // getting response of sms
            HttpWebResponse myResp = (HttpWebResponse)_createRequest.GetResponse();
            System.IO.StreamReader _responseStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = _responseStreamReader.ReadToEnd();
            _responseStreamReader.Close();
            myResp.Close();

            return true;
            //ENDSend Message to given Mobile No
        }
        public static bool SendSMSMeritPublishPrinciple(string MeritName, string MobileNo, string AdmissionProcessName)
        {
            //Send Message to given Mobile No
            StringBuilder sbUrlMsg = new StringBuilder();
            //Your Quick Registration for admission in ………………………………… has been completed. Login with User ID ……………………… and Password …………………… to complete the application form.
            sbUrlMsg.Append("http://login.arihantsms.com/vendorsms/pushsms.aspx?user=vnsgu&password=vnsgu@1965&msisdn=" + MobileNo);

            sbUrlMsg.Append("&sid=VNSGUS&msg=");
            sbUrlMsg.Append("Respected Principle Sir , Merit List " + MeritName + " Published For " + AdmissionProcessName);
            sbUrlMsg.AppendLine("&fl=0&gwid=2");

            // creating web request to send sms 
            HttpWebRequest _createRequest = (HttpWebRequest)WebRequest.Create(sbUrlMsg.ToString());
            // getting response of sms
            HttpWebResponse myResp = (HttpWebResponse)_createRequest.GetResponse();
            System.IO.StreamReader _responseStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = _responseStreamReader.ReadToEnd();
            _responseStreamReader.Close();
            myResp.Close();

            return true;
            //ENDSend Message to given Mobile No
        }
        public static bool SendSMSCuttoffPublishPrinciple(string MeritName, string MobileNo, string MarksRange, string AdmissionProcessName)
        {
            //Send Message to given Mobile No
            StringBuilder sbUrlMsg = new StringBuilder();
            //Your Quick Registration for admission in ………………………………… has been completed. Login with User ID ……………………… and Password …………………… to complete the application form.
            sbUrlMsg.Append("http://login.arihantsms.com/vendorsms/pushsms.aspx?user=vnsgu&password=vnsgu@1965&msisdn=" + MobileNo);

            sbUrlMsg.Append("&sid=VNSGUS&msg=");
            sbUrlMsg.Append("Respected Principle Sir , Cut-off List of " + MeritName + " with Marks Range " + MarksRange + " Published For " + AdmissionProcessName);
            sbUrlMsg.AppendLine("&fl=0&gwid=2");

            // creating web request to send sms 
            HttpWebRequest _createRequest = (HttpWebRequest)WebRequest.Create(sbUrlMsg.ToString());
            // getting response of sms
            HttpWebResponse myResp = (HttpWebResponse)_createRequest.GetResponse();
            System.IO.StreamReader _responseStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = _responseStreamReader.ReadToEnd();
            _responseStreamReader.Close();
            myResp.Close();

            return true;
            //ENDSend Message to given Mobile No
        }
        #region Password Recovery Mail
        //public static bool SendPasswordMail(string EmployeeName, string emailAddress, string Password, string FromEmail)
        //{
        //    string strMailBody = "";
        //    string path = System.Web.HttpContext.Current.Server.MapPath("/Admin/MailTemplate/PasswordRecovery.html");
        //    System.IO.StreamReader IDDSbody = new System.IO.StreamReader(path);
        //    strMailBody = IDDSbody.ReadToEnd();

        //    strMailBody = strMailBody.Replace("{@AdminPanelLogoURL}", AppConfiguration.AdminPanelLogoURL);
        //    strMailBody = strMailBody.Replace("{@AdminPanelURL}", AppConfiguration.AdminPanelURL);
        //    strMailBody = strMailBody.Replace("{@ProjectName}", AppConfiguration.ProjectName);

        //    strMailBody = strMailBody.Replace("{Name}", EmployeeName);
        //    strMailBody = strMailBody.Replace("{username}", emailAddress);
        //    strMailBody = strMailBody.Replace("{password}", Password);

        //    bool Chk = SendMail(FromEmail, "SA", emailAddress, FromEmail, strMailBody, "SA" + " Credentials", "", "heta@gipl.net", true, "");
        //    return Chk;

        //}
        public static bool SendBulkMail(string ApplicationNo, string MobileNo, string ApplicantName, string Email, string EmailText, string AdmissionProcessName)
        {
            string strMailBody = "";
            string path = System.Web.HttpContext.Current.Server.MapPath("/Admin/MailTemplate/BulkMailSending.html");
            System.IO.StreamReader IDDSbody = new System.IO.StreamReader(path);
            strMailBody = IDDSbody.ReadToEnd();

            strMailBody = strMailBody.Replace("{EmailText}", EmailText);


            DataTable dt = BAL.SMTPConfigmgmt.GetSMTPSetting();
            bool Chk = SendMail(dt.Rows[0]["UserName"].ToString(), "VNSGU : Admission Department", Email, "", strMailBody, "Login Credentials", "", "", true, "");
            return Chk;

        }
        public static bool SendPasswordMail(string EmployeeName, string emailAddress, string Password)
        {
            string strMailBody = "";
            string path = System.Web.HttpContext.Current.Server.MapPath("/Admin/MailTemplate/PasswordRecovery.html");
            System.IO.StreamReader IDDSbody = new System.IO.StreamReader(path);
            strMailBody = IDDSbody.ReadToEnd();

            strMailBody = strMailBody.Replace("{Name}", EmployeeName);
            strMailBody = strMailBody.Replace("{username}", emailAddress);
            strMailBody = strMailBody.Replace("{password}", Password);
            DataTable dt = BAL.SMTPConfigmgmt.GetSMTPSetting();
            bool Chk = SendMail(dt.Rows[0]["UserName"].ToString(), "VNSGU : Admission Department", emailAddress, "", strMailBody, "Login Credentials", "", "", true, "");
            return Chk;

        }
        public static bool SendWelcomeMail(string UserName, string emailAddress, string Password)
        {
            string strMailBody = "";
            string path = System.Web.HttpContext.Current.Server.MapPath("/Admin/MailTemplate/WelcomeUser.html");
            System.IO.StreamReader IDDSbody = new System.IO.StreamReader(path);
            strMailBody = IDDSbody.ReadToEnd();

            strMailBody = strMailBody.Replace("{Name}", UserName);
            // strMailBody = strMailBody.Replace("{username}", emailAddress);
            strMailBody = strMailBody.Replace("{password}", Password);
            DataTable dt = BAL.SMTPConfigmgmt.GetSMTPSetting();
            bool Chk = SendMail(dt.Rows[0]["UserName"].ToString(), "VNSGU : Admission Department", emailAddress, "", strMailBody, "Registration Successful", "", "", true, "");
            return Chk;

        }
        public static bool SendFinalSubmitMail(string UserName, string emailAddress, string AdmissionProcessName)
        {
            string strMailBody = "";
            string path = System.Web.HttpContext.Current.Server.MapPath("/Admin/MailTemplate/AdmissionFinalSubmit.html");
            System.IO.StreamReader IDDSbody = new System.IO.StreamReader(path);
            strMailBody = IDDSbody.ReadToEnd();

            strMailBody = strMailBody.Replace("{Name}", UserName);
            // strMailBody = strMailBody.Replace("{username}", emailAddress);
            strMailBody = strMailBody.Replace("{Password}", AdmissionProcessName);
            DataTable dt = BAL.SMTPConfigmgmt.GetSMTPSetting();
            bool Chk = SendMail(dt.Rows[0]["UserName"].ToString(), "VNSGU : Admission Department", emailAddress, "", strMailBody, "Application Submitted Successfully", "", "", true, "");
            return Chk;

        }
        public static bool SendVerificationMailHelpCenter(string UserName, string emailAddress, string AdmissionProcessName)
        {
            string strMailBody = "";
            string path = System.Web.HttpContext.Current.Server.MapPath("/Admin/MailTemplate/AdmissionVerificationHelpCenter.html");
            System.IO.StreamReader IDDSbody = new System.IO.StreamReader(path);
            strMailBody = IDDSbody.ReadToEnd();

            strMailBody = strMailBody.Replace("{Name}", UserName);
            // strMailBody = strMailBody.Replace("{username}", emailAddress);
            strMailBody = strMailBody.Replace("{Password}", AdmissionProcessName);
            DataTable dt = BAL.SMTPConfigmgmt.GetSMTPSetting();
            bool Chk = SendMail(dt.Rows[0]["UserName"].ToString(), "VNSGU : Admission Department", emailAddress, "", strMailBody, "Application Submitted Successfully", "", "", true, "");
            return Chk;

        }
        public static bool SendVerificationMailUniversity(string UserName, string emailAddress, string AdmissionProcessName)
        {
            string strMailBody = "";
            string path = System.Web.HttpContext.Current.Server.MapPath("/Admin/MailTemplate/AdmissionVerificationUniversity.html");
            System.IO.StreamReader IDDSbody = new System.IO.StreamReader(path);
            strMailBody = IDDSbody.ReadToEnd();

            strMailBody = strMailBody.Replace("{Name}", UserName);
            // strMailBody = strMailBody.Replace("{username}", emailAddress);
            strMailBody = strMailBody.Replace("{Password}", AdmissionProcessName);
            DataTable dt = BAL.SMTPConfigmgmt.GetSMTPSetting();
            bool Chk = SendMail(dt.Rows[0]["UserName"].ToString(), "VNSGU : Admission Department", emailAddress, "", strMailBody, "Application Submitted Successfully", "", "", true, "");
            return Chk;

        }

        // Added by ROHIT SHARMA FOR CANCELATION ADMISSION OTP 03.03.2019
        public static bool SendSMSForApplicantCancelOTP(string MobileNo, string SMSText)
        {
            //Send Message to given Mobile No
            StringBuilder sbUrlMsg = new StringBuilder();

            sbUrlMsg.Append("http://login.arihantsms.com/vendorsms/pushsms.aspx?user=vnsgu&password=vnsgu@1965&msisdn=" + MobileNo);

            sbUrlMsg.Append("&sid=VNSGUS&msg=");

            sbUrlMsg.AppendLine(SMSText);

            sbUrlMsg.AppendLine("&fl=0&gwid=2");

            // creating web request to send sms 
            HttpWebRequest _createRequest = (HttpWebRequest)WebRequest.Create(sbUrlMsg.ToString());
            //  getting response of sms
            HttpWebResponse myResp = (HttpWebResponse)_createRequest.GetResponse();
            System.IO.StreamReader _responseStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = _responseStreamReader.ReadToEnd();
            _responseStreamReader.Close();
            myResp.Close();

            if (((dynamic)JsonConvert.DeserializeObject(responseString)).ErrorMessage == "Success")
            {
                return true;
            }
            else
            {
                return false;
            }
            //ENDSend Message to given Mobile No
        }
        public static bool SendMailForApplicantCancel(string ApplicationNo, string ApplicantName, string Email, string OPTEmail)
        {
            string strMailBody = "";
            string path = System.Web.HttpContext.Current.Server.MapPath("/Admin/MailTemplate/SendMailForApplicantCancel.html");
            System.IO.StreamReader IDDSbody = new System.IO.StreamReader(path);
            strMailBody = IDDSbody.ReadToEnd();

            strMailBody = strMailBody.Replace("{ApplicationNo}", ApplicationNo);
            strMailBody = strMailBody.Replace("{ApplicantName}", ApplicantName);

            strMailBody = strMailBody.Replace("{OPTMessage}", OPTEmail);

            DataTable dt = BAL.SMTPConfigmgmt.GetSMTPSetting();
            bool Chk = SendMail(dt.Rows[0]["UserName"].ToString(), "VNSGU : Admission Department", Email, "", strMailBody, "Cancelation OTP Detail ", "", "", true, "");
            return Chk;

        }
        #endregion
    }
}
