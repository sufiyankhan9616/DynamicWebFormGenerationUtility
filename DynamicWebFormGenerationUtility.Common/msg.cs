using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicWebFormGenerationUtility.Common
{
    public class msg
    {
        public static string GetMsg(System.Web.UI.Page pg, string msgFor, string msgType)
        {
            string strMsg = "";
            try
            {
                switch (msgType)
                {
                    case "EE":
                        strMsg = "swal({ title: \"Opps!!\", text: \"Query Name Already Exists\",  icon: \"error\",  button: \"Ok\",});";
                        break;
                    case "LE":
                        strMsg = "swal({ title: \"Opps!!\", text: \"Please Select atleast one Column.\",  icon: \"error\",  button: \"Ok\",});";
                        break;
                    case "I":
                        strMsg = "swal({ title: \"Done\", text: \"Record Saved Successfully\",  icon: \"success\",  button: \"Ok\",});";
                        break;
                    case "P":
                        strMsg = "swal({ title: \"Done\", text: \"Payment Verified Successfully\",  icon: \"success\",  button: \"Ok\",});";
                        break;
                    case "IA":
                        strMsg = "swal({ title: \"Alert\", text: \"Please Enter Valid Application Number.\",  icon: \"error\",  button: \"Ok\",});";
                        break;
                    case "U":
                        strMsg = "swal({ title: \"Done\", text: \"Record Updated Successfully\",  icon: \"success\",  button: \"Ok\",});";
                        break;
                    case "D":
                        strMsg = "swal({ title: \"Done\", text: \"Record Deleted Successfully\",  icon: \"success\",  button: \"Ok\",});";
                        break;
                    case "IP":
                        strMsg = "swal({ title: \"Done\", text: \"Incorrect Password\",  icon: \"warning\",  button: \"Ok\",});";
                        break;
                    case "IE":
                        strMsg = "swal({ title: \"Error\", text: \"Record Can't Be Saved\",  icon: \"error\",  button: \"Ok\",});";
                        break;
                    case "UE":
                        strMsg = "swal({ title: \"Error\", text: \"Record Can't Be Updated\",  icon: \"error\",  button: \"Ok\",});";
                        break;
                    case "DE":
                        strMsg = "swal({ title: \"Error\", text: \"Record Can't Be Deleted\",  icon: \"error\",  button: \"Ok\",});";
                        break;
                    case "AE":
                        strMsg = "swal({ title: \"Alert\", text: \"Record Already Exists\",  icon: \"warning\",  button: \"Ok\",});";
                        break;
                    case "PE":
                        strMsg = "swal({ title: \"Alert\", text: \"Payment Already verified\",  icon: \"warning\",  button: \"Ok\",});";
                        break;
                    case "CF":
                        strMsg = "swal({ title: \"Error\", text: \"Record Can't Be Deleted Due To Dependency\",  icon: \"error\",  button: \"Ok\",});";
                        break;
                    case "ANC":
                        strMsg = "swal({ title: \"Done\", text: \"Enter Only One Record.\",  icon: \"warning\",  button: \"Ok\",});";
                        break;
                    case "CED":
                        strMsg = "swal({ title: \"Error\", text: \"Record Can't Be Edited or Deleted Due To Dependency\",  icon: \"error\",  button: \"Ok\",});";
                        break;
                    case "UR":
                        strMsg = "swal({ title: \"Error\", text: \"Does not have rights for update.\",  icon: \"error\",  button: \"Ok\",});";
                        break;
                    case "SR":
                        strMsg = "swal({ title: \"Opps!!\", text: \"Does not have rights for insert\",  icon: \"error\",  button: \"Ok\",});";
                        break;
                    case "AU":
                        strMsg = "swal({ title: \"Error\", text: \"Record Dependency Error.\",  icon: \"error\",  button: \"Ok\",});";
                        break;
                    case "UV":
                        strMsg = "swal({ title: \"Done\", text: \"Status Verified Successfully\",  icon: \"success\",  button: \"Ok\",});";
                        break;
                    case "UAV":
                        strMsg = "swal({ title: \"Alert\", text: \"Some of the Applicant(s) are already Verified.\",  icon: \"success\",  button: \"Ok\",});";
                        break;
                    case "UUn":
                        strMsg = "swal({ title: \"Done\", text: \"Status UnVerified Successfully\",  icon: \"success\",  button: \"Ok\",});";
                        break;
                    case "UAUn":
                        strMsg = "swal({ title: \"Alert\", text: \"You can't Unverified because Some Applicant(s) are Eligible or Enrolled.\",  icon: \"success\",  button: \"Ok\",});";
                        break;
                    case "SD":
                        strMsg = "swal({ title: \"Opps!!\", text: \"Please select record which you want to Delete.\",  icon: \"error\",  button: \"Ok\",});";
                        break;
                    case "FND":
                        strMsg = "swal({ title: \"Opps!!\", text: \"Fees not defined.\",  icon: \"error\",  button: \"Ok\",});";
                        break;
                    case "MFV":
                        strMsg = "swal({ title: \"Opps!!\", text: \"Invalid Merit Formula.\",  icon: \"error\",  button: \"Ok\",});";
                        break;
                    case "MFIV":
                        strMsg = "swal({ title: \"Opps!!\", text: \"Please Enter All Selected Identifier in Merit Formula.\",  icon: \"error\",  button: \"Ok\",});";
                        break;
                    case "MFID":
                        strMsg = "swal({ title: \"Opps!!\", text: \"Please Select Unique Identifier.\",  icon: \"error\",  button: \"Ok\",});";
                        break;
                    case "QRIK":
                        strMsg = "swal({ title: \"Opps!!\", text: \"Entered Kit Details are not Valid.\",  icon: \"error\",  button: \"Ok\",});";
                        break;
                    case "Weightage":
                        strMsg = "swal({ title: \"Opps!!\", text: \"Total weightage for all the selected qualifying head in a formula must be equal to 1.00. or If no weightage is applicable, all the selected qualifying head in a formula must have weightage of 1.00 \",  icon: \"error\",  button: \"Ok\",});";
                        break;
                    case "APFREEZE":
                        strMsg = "swal({ title: \"Alert\", text: \"Selected Admission Process is Freeze. Kindly UnFreeze in order to make changes.\",  icon: \"error\",  button: \"Ok\",});";
                        break;
                    case "Send":
                        strMsg = "swal({ title: \"Done\", text: \"SMS Send Successfully\",  icon: \"success\",  button: \"Ok\",});";
                        break;
                    case "Email":
                        strMsg = "swal({ title: \"Done\", text: \"Email Send Successfully\",  icon: \"success\",  button: \"Ok\",});";
                        break;

                    case "DR":
                        strMsg = "swal({ title: \"Opps!!\", text: \"You does not have rights to perform this delete activity.\",  icon: \"error\",  button: \"Ok\",});";
                        break;
                    case "VR":
                        strMsg = "swal({ title: \"Opps!!\", text: \"You does not have rights to perform this view activity.\",  icon: \"error\",  button: \"Ok\",});";
                        break;
                    case "RE":
                        strMsg = "swal({ title: \"Alert\", text: \"Record Already Exists for Selected Parameter kindly Complete the Round. \",  icon: \"warning\",  button: \"Ok\",});";
                        break;
                    case "MR":
                        strMsg = "swal({ title: \"Alert\", text: \"Mock Round Already Exists. \",  icon: \"warning\",  button: \"Ok\",});";
                        break;
                    case "DC":

                        strMsg = msgFor;
                        break;

                    default:
                        strMsg = "swal({ title: \"Information\", text: \" " + msgFor + " \",  icon: \"info\",  button: \"Ok\",});";
                        break;
                }


                pg.ClientScript.RegisterStartupScript(pg.GetType(), "alert", strMsg, true);


                return strMsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AlertMessage(System.Web.UI.Page pg, string header, string Message)
        {
            pg.ClientScript.RegisterStartupScript(pg.GetType(), "swal(" + header + ", " + Message + ");", Message, true);
        }

    }
}
