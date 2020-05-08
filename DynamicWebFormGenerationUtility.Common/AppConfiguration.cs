using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DynamicWebFormGenerationUtility.Common
{
    public class AppConfiguration
    {
        public static int PageSize
        {
            get { return ConfigurationManager.AppSettings["RecordsPerPage"].ToString().ToInt32(); }

        }
        public static int MaxLengthDetails
        {
            get { return ConfigurationManager.AppSettings["MaxLengthDetails"].ToString().ToInt32(); }

        }
        public static int MaxUploadStudentPhotoSize
        {
            get { return ConfigurationManager.AppSettings["MaxUploadStudentPhotoSize"].ToString().ToInt32(); }

        }

        public static string InnerPageHeader
        {
            get { return ConfigurationManager.AppSettings["InnerPageHeader"].ToString(); }

        }
        public static string AboutUsContent
        {
            get { return ConfigurationManager.AppSettings["AboutUsContent"].ToString().ToString(); }

        }
        public static string WebsiteName
        {
            get { return ConfigurationManager.AppSettings["WebsiteName"].ToString(); }

        }
        public static string LabLink
        {
            get { return ConfigurationManager.AppSettings["LabLink"].ToString(); }

        }
        public static string AboutUsLink
        {
            get { return ConfigurationManager.AppSettings["AboutUsLink"].ToString(); }

        }
        public static string BrochureLink
        {
            get { return ConfigurationManager.AppSettings["BrochureLink"].ToString(); }

        }
        public static string CTBLink
        {
            get { return ConfigurationManager.AppSettings["CTBLink"].ToString(); }

        }
        public static string AboutUsID
        {
            get { return ConfigurationManager.AppSettings["AboutUsID"].ToString(); }

        }


        #region Mail
        public static string DomainURL
        {
            get { return ConfigurationManager.AppSettings["DomainURL"].ToString(); }

        }


        public static string AdminPanelURL
        {
            get { return ConfigurationManager.AppSettings["AdminPanelURL"].ToString(); }

        }
        public static string AdminPanelLogoURL
        {
            get { return ConfigurationManager.AppSettings["AdminPanelLogoURL"].ToString(); }

        }
        public static string ProjectName
        {
            get { return ConfigurationManager.AppSettings["ProjectName"].ToString(); }

        }
        public static string ProjectNameAbbr
        {
            get { return ConfigurationManager.AppSettings["ProjectNameAbbr"].ToString(); }

        }
        #endregion
        public static string ErrorFromName
        {
            get { return ConfigurationManager.AppSettings["ErrorFromName"].ToString(); }
        }

        public static string ErrorMailSubject
        {
            get { return ConfigurationManager.AppSettings["ErrorMailSubject"].ToString(); }
        }
        #region ErrorMail
        public static string ErrorToEmail
        {
            get { return ConfigurationManager.AppSettings["ErrorToEmail"].ToString(); }

        }

        public static string ErrorFromEmail
        {
            get { return ConfigurationManager.AppSettings["ErrorFromEmail"].ToString(); }

        }

        public static string ErrorBCCEmail
        {
            get { return ConfigurationManager.AppSettings["ErrorBCCEmail"].ToString(); }

        }
        #endregion
        public static string RequiredErrorMail
        {
            get { return ConfigurationManager.AppSettings["RequiredErrorMail"].ToString(); }
        }

      
        public static int MaxPDFSize
        {
            get { return ConfigurationManager.AppSettings["MaxPDFSize"].ToString().ToInt(); }

        }
        public static string UploadFilePathBaseStudent
        {
            get
            {
                return ConfigurationManager.AppSettings["UploadFilePathBaseStudent"].ToString();
            }
        }
        public static int MaxUploadFileSize
        {
            get { return ConfigurationManager.AppSettings["MaxUploadFileSize"].ToString().ToInt(); }

        }
        public static int MaxImageSize
        {
            get { return ConfigurationManager.AppSettings["MaxImageSize"].ToString().ToInt(); }

        }

        /// <summary>
        /// return Large PhotoSize in Bytes 
        /// </summary>
        public static int LargeWidth
        {
            get { return ConfigurationManager.AppSettings["LargeWidth"].ToString().ToInt32(); }

        }
        /// <summary>
        /// return Large PhotoSize in Bytes 
        /// </summary>
        public static int LargeHeight
        {
            get { return ConfigurationManager.AppSettings["LargeHeight"].ToString().ToInt32(); }

        }

        /// <summary>
        /// return Middiam PhotoSize in Bytes 
        /// </summary>
        public static int MiddiamWidth
        {
            get { return ConfigurationManager.AppSettings["MiddiamWidth"].ToString().ToInt32(); }

        }
        /// <summary>
        /// return Middiam PhotoSize in Bytes 
        /// </summary>
        public static int MiddiamHeight
        {
            get { return ConfigurationManager.AppSettings["MiddiamHeight"].ToString().ToInt32(); }

        }

        /// <summary>
        /// return Thumb PhotoSize in Bytes 
        /// </summary>
        public static int ThumbWidth
        {
            get { return ConfigurationManager.AppSettings["ThumbWidth"].ToString().ToInt32(); }

        }
        /// <summary>
        /// return Thumb PhotoSize in Bytes 
        /// </summary>
        public static int ThumbHeight
        {
            get { return ConfigurationManager.AppSettings["ThumbHeight"].ToString().ToInt32(); }

        }

        /// <summary>
        /// return Thumb PhotoSize in Bytes 
        /// </summary>
        public static int InternalBannerWidth
        {
            get { return ConfigurationManager.AppSettings["InternalBannerWidth"].ToString().ToInt32(); }

        }
        /// <summary>
        /// return Thumb PhotoSize in Bytes 
        /// </summary>
        public static int InternalpageBannerHeight
        {
            get { return ConfigurationManager.AppSettings["InternalpageBannerHeight"].ToString().ToInt32(); }

        }

        /// <summary>
        /// return Thumb PhotoSize in Bytes 
        /// </summary>
        public static int HomepageBannerWidth
        {
            get { return ConfigurationManager.AppSettings["HomepageBannerWidth"].ToString().ToInt32(); }

        }
        /// <summary>
        /// return Thumb PhotoSize in Bytes 
        /// </summary>
        public static int HomepageBannerHeight
        {
            get { return ConfigurationManager.AppSettings["HomepageBannerHeight"].ToString().ToInt32(); }

        }

        /// <summary>
        /// return Map PhotoSize in Bytes 
        /// </summary>
        public static int MapWidth
        {
            get { return ConfigurationManager.AppSettings["MapWidth"].ToString().ToInt32(); }

        }
        /// <summary>
        /// return Map PhotoSize in Bytes 
        /// </summary>
        public static int MapHeight
        {
            get { return ConfigurationManager.AppSettings["MapHeight"].ToString().ToInt32(); }

        }

        public static int GalleryMaxImageSize
        {
            get { return ConfigurationManager.AppSettings["GalleryMaxImageSize"].ToString().ToInt(); }

        }

        /// <summary>
        /// return Gallery Large PhotoSize in Bytes 
        /// </summary>
        public static int GalleryLargeWidth
        {
            get { return ConfigurationManager.AppSettings["GalleryLargeWidth"].ToString().ToInt32(); }

        }
        /// <summary>
        /// return Gallery Large PhotoSize in Bytes 
        /// </summary>
        public static int GalleryLargeHeight
        {
            get { return ConfigurationManager.AppSettings["GalleryLargeHeight"].ToString().ToInt32(); }

        }

        /// <summary>
        /// return Gallery Middiam PhotoSize in Bytes 
        /// </summary>
        public static int GalleryMiddiamWidth
        {
            get { return ConfigurationManager.AppSettings["GalleryMiddiamWidth"].ToString().ToInt32(); }

        }
        /// <summary>
        /// return Gallery Middiam PhotoSize in Bytes 
        /// </summary>
        public static int GalleryMiddiamHeight
        {
            get { return ConfigurationManager.AppSettings["GalleryMiddiamHeight"].ToString().ToInt32(); }

        }

        /// <summary>
        /// return Gallery Thumb PhotoSize in Bytes 
        /// </summary>
        public static int GalleryThumbWidth
        {
            get { return ConfigurationManager.AppSettings["GalleryThumbWidth"].ToString().ToInt32(); }

        }
        /// <summary>
        /// return Gallery Thumb PhotoSize in Bytes 
        /// </summary>
        public static int GalleryThumbHeight
        {
            get { return ConfigurationManager.AppSettings["GalleryThumbHeight"].ToString().ToInt32(); }

        }

        public static string OriginalImagePath
        {
            get { return ConfigurationManager.AppSettings["OriginalImagePath"].ToString(); }

        }

        public static string ApplicantPhotoFolderPathBase
        {
            get { return ConfigurationManager.AppSettings["ApplicantPhotoFolderPathBase"].ToString(); }
        }

        public static string ApplicantPhotoBaseUrl
        {
            get { return ConfigurationManager.AppSettings["ApplicantPhotoBaseUrl"].ToString(); }
        }

        public static string ThumbImagePath
        {
            get { return ConfigurationManager.AppSettings["ThumbImagePath"].ToString(); }

        }
        public static string MediumImagePath
        {
            get { return ConfigurationManager.AppSettings["MediumImagePath"].ToString(); }

        }
        public static string LargeImagePath
        {
            get { return ConfigurationManager.AppSettings["LargeImagePath"].ToString(); }

        }
        public static string NoImagePath
        {
            get { return ConfigurationManager.AppSettings["NoImagePath"].ToString(); }

        }
        public static string ContentPDFFilePath
        {
            get { return ConfigurationManager.AppSettings["ContentPDFFilePath"].ToString(); }
        }

        public static string AnnouncementPDFFilePath
        {
            get { return ConfigurationManager.AppSettings["AnnouncementPDFFilePath"].ToString(); }
        }

        public static string TenderPDFFilePath
        {
            get { return ConfigurationManager.AppSettings["TenderPDFFilePath"].ToString(); }
        }

        public static string Error404
        {
            get { return ConfigurationManager.AppSettings["Error404"].ToString(); }
        }
        public static string ContentNotFoundMsg
        {
            get { return ConfigurationManager.AppSettings["ContentNotFoundMsg"].ToString(); }
        }
        public static string ComingSoon
        {
            get { return ConfigurationManager.AppSettings["ComingSoon"].ToString(); }
        }
        public static string AppendTextInPageTitle
        {
            get { return ConfigurationManager.AppSettings["AppendTextInPageTitle"].ToString(); }
        }
        public static string FromMailQuery
        {
            get { return ConfigurationManager.AppSettings["FromMailQuery"].ToString(); }
        }
        public static string FromMailEdu
        {
            get { return ConfigurationManager.AppSettings["FromMailEdu"].ToString(); }
        }
        public static string ToMailQuery
        {
            get { return ConfigurationManager.AppSettings["ToMailQuery"].ToString(); }
        }
        public static string ToMailEdu
        {
            get { return ConfigurationManager.AppSettings["ToMailEdu"].ToString(); }
        }
    }

}
