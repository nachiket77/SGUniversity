using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Education.WebAPI.Models.Common
{
    public class ErrorLogs
    {
        public static void ErrorLog(Exception errorDtl, string methodName)
        {
            string err = null;
            string fileExistDate = DateTime.Today.ToString("ddMMyyyy");
            //fileExistDate = DateTime.Today;
            string logFile = System.Web.Hosting.HostingEnvironment.MapPath("~/ErrorLogs/" + "Error_" + fileExistDate + ".txt");
            System.IO.FileStream fileCreate = null;
            if (!System.IO.File.Exists(logFile))
            {
                fileCreate = System.IO.File.Create(logFile);
                fileCreate.Close();
            }

            err = "Page Name :-" + HttpContext.Current.Request.Url.LocalPath + "\n";
            err = err + "Error Log Date Time :-" + DateTime.Now + "\n";
            err = err + "Method Name :-" + methodName + "\n";
            err = err + "Error Message :-" + errorDtl.Message + "\n";
            err = err + "Source :-" + errorDtl.Source + "\n";
            err = err + "Trace :-" + errorDtl.StackTrace + "\n";
            if (errorDtl.InnerException != null)
            {
                err = err + "Inner Exception:- " + errorDtl.InnerException + "\n";
                err = err + "Inner Exception Meesage:- " + errorDtl.InnerException.Message + "\n";
            }
            System.IO.StreamWriter objWriter = null;

            objWriter = File.AppendText(logFile);
            objWriter.WriteLine("=====================================================================");
            objWriter.WriteLine(err);
            objWriter.Flush();
        }
    }
}