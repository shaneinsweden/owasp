using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Hosting;

namespace Owasp.Data
{
    public class FileUtils
    {
        internal static string FetchMovieSummary(string selectedLanguageFile, HttpContext context)
        {
            return GetSafeArchiveData(selectedLanguageFile, context);
        }

        public static string GetArchiveData(string path, HttpContext context)
        {
            path = context.Server.MapPath(path);

            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }
            else
                return "File " + path + " does not exist";
        }

        public static string GetSafeArchiveData(string path, HttpContext context)
        {
            if (path.Contains(".."))
                return "naughty naughty";

            path = context.Server.MapPath(path);
            
            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }
            else
                return "File " + path + " does not exist";
        }

   

      
    }
}
