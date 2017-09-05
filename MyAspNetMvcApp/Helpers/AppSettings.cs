using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace MyAspNetMvcApp
{
    public static class AppSettings
    {
        public static string AppTitle
        {
            get { return ConfigurationManager.AppSettings["AppTitle"]; }
        }
        public static string AppDescription
        {
            get { return ConfigurationManager.AppSettings["AppDescription"]; }
        }
        public static string AppDomainName
        {
            get { return ConfigurationManager.AppSettings["AppDomainName"]; }
        }
        public static bool EmailVerificationEnabled
        {
            get { return Boolean.Parse(ConfigurationManager.AppSettings["EmailVerificationEnabled"]); }
        }
    }
}