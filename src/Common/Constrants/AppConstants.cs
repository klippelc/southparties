using System;
using System.Configuration;

namespace Common
{
    public static class AppConstants
    {
        public static readonly string AdApplicationName = ConfigurationManager.AppSettings["ADApplicationName"].ToLowerInvariant();
        public static readonly string ApplicationDescription = ConfigurationManager.AppSettings["ApplicationDesc"];
        public static readonly string ApplicationName = ConfigurationManager.AppSettings["ApplicationName"];
        public static readonly string BugNotificationEmail = ConfigurationManager.AppSettings["BUG::ContactEmail"].ToLowerInvariant();
        public static readonly string TenantId = ConfigurationManager.AppSettings["TenantId"];
        public static readonly string EIMSClientId = ConfigurationManager.AppSettings["EIMS::ClientId"];
        public static readonly string EIMSClientSecret = ConfigurationManager.AppSettings["EIMS::ClientSecret"];
        public static readonly string FilesApiUrl = ConfigurationManager.AppSettings["Files::Api"];
        public static readonly string AllowMobileView = ConfigurationManager.AppSettings["AllowMobileView"];

        public static readonly bool NotifyNewAccount = Convert.ToBoolean(ConfigurationManager.AppSettings["SendNotificationEmail"]);

        public const int HasDecimals2 = 2;
        public const int HasDecimals18 = 18;

        public const int HasMaxLength2 = 2;
        public const int HasMaxLength4 = 4;
        public const int HasMaxLength5 = 5;
        public const int HasMaxLength6 = 6;
        public const int HasMaxLength10 = 10;
        public const int HasMaxLength12 = 12;
        public const int HasMaxLength15 = 15;
        public const int HasMaxLength24 = 24;
        public const int HasMaxLength48 = 48;
        public const int HasMaxLength96 = 96;
        public const int HasMaxLength128 = 128;
        public const int HasMaxLength256 = 256;
        public const int HasMaxLength512 = 512;
        public const int HasMaxLength1024 = 1024;
        public const int HasMaxLength2048 = 2048;

        public const string TransactionSuccess = "SUCCESS: Your transaction was successful";
        public const string TransactionError = "ERROR: An error happened when saving your data, If Problem Persist contact Tech Support (954) 357-8600!";
        public const string QueryError = "ERROR: An error happened when retrieving your data, If Problem Persist contact Tech Support (954) 357-8600!";
        public const string ValidationWarning = "WARNING: Validation Errors were found in your form, check fields and submit again.";
        public const string JsonModelStateInvalid = "validation_error";
        public const string StandardValidationErrorMessage = "This is a Required Field...";
        public const string JsonError = "error";
        public const string AccessBrowardCookie = "BrowardID";
        public const string AspNetSessionIdCookie = "ASP.NET_SessionId";
        public const string AccessBrowardLocalConnectorKey = "AccessBROWARDLocalConnector";
        public const string AccessBrowardKey = "AccessBroward";
        public const string PhotoExtension = ".jpg";
        public const string PhotoExtensionJpeg = ".jpeg";
        public const string PdfExtension = ".pdf";
        public const string PdfContentType = "application/pdf";
        public const string JpgContentType = "image/jpeg";

        public const string GenericFolder = "general-files";
        public const string ApplicationsFolder = "applications";

        public const string LocalHostIpAddressDev = "::1";
        public const string LocalHostIpAddress = "127.0.0.1";
        public const string RelayServerUrl = @"unit8.bc.broward.cty";

        public const int RelayServerPort = 25;
    }
}
