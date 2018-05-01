using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Education.WebAPI.Models.Common
{
    public class Mails
    {
        public static bool SendEmail(string toMail, string subject, string body)
        {
            try
            {
                string fromMail = ConfigurationManager.AppSettings["fromMail"];
                string hostName = ConfigurationManager.AppSettings["hostName"];
                string password = ConfigurationManager.AppSettings["password"];
                int port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);

                MailMessage mm = new MailMessage(fromMail, toMail);
                mm.Subject = subject;// "Password Recovery";
                mm.Body = body;// string.Format("Hi {0},<br /><br />Your password is {1}.<br /><br />Thank You.", username, password);
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = hostName;// "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential();
                NetworkCred.UserName = fromMail; //"sender@gmail.com";
                NetworkCred.Password = password;// "<Password>";
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
                smtp.Port = port;
                smtp.Send(mm);

                return true;
            }
            catch (Exception ex)
            {
                ErrorLogs.ErrorLog(ex, "SendEmail()");
                return false;
            }
        }

    }
}