using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SmartShop.Web.App_Start
{
    public class LoggerConfig
    {
        private static ILog log;

        public static ILog Logger
        {
            get
            {
                if (log == null)
                {
                    log = LogManager.GetLogger("UnhandledExceptions");
                }

                return log;
            }
        }

        internal static void RegisterLogger()
        {
            // BasicConfigurator replaced with XmlConfigurator.

            XmlConfigurator.Configure(new FileInfo(HttpContext.Current.Server.MapPath("~/Log4net.config")));
        }
    }
}