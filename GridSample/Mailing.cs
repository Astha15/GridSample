using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.Web.Mvc;

namespace GridSample
{
    public class Mailing
    {
        string sender = "";
        string password = "";
        public Mailing(string _sender, string _password)
        {
            sender = _sender;
            password = _password;
        }

        public bool SendMail (string recipient, string body)
        {
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com");
            client.Port = 587;
            client.UseDefaultCredentials = false;

            using (var mail = new MailMessage(sender.Trim(), recipient.Trim()))
            {
                mail.Subject = "Alerts Report";
                mail.Body = body;
                mail.IsBodyHtml = false;
                var smtp = new SmtpClient();
                smtp.Host = "smtp-mail.outlook.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(sender, password);
                smtp.Port = 587;
                try
                {
                    smtp.Send(mail);
                    return true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
            }

        }
    }
}