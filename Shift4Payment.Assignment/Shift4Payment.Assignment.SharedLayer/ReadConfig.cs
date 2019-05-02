using System.Configuration;

namespace Shift4Payment.Assignment.SharedLayer
{
    /// <summary>
    /// application configurations
    /// </summary>
    public static class ReadConfig
    {
        /// <summary>
        /// smtp server for email sending
        /// </summary>
        public static string SmtpServerDetails
        {
            get
            {
                return ConfigurationManager.AppSettings["SmtpServerDetails"] ?? "smtp.gmail.com";
            }
        }

        /// <summary>
        /// from email
        /// </summary>
        public static string FromEmail
        {
            get
            {
                return ConfigurationManager.AppSettings["FromEmail"] ?? "admin@gmail.com";
            }
        }

        /// <summary>
        /// smtp password
        /// </summary>
        public static string SmtpPassword
        {
            get
            {
                return ConfigurationManager.AppSettings["SmtpPassword"] ?? "";
            }
        }

        /// <summary>
        /// to email 
        /// </summary>
        public static string ToEmail
        {
            get
            {
                return ConfigurationManager.AppSettings["ToEmail"] ?? "admin@gmail.com";
            }
        }

    }
}
