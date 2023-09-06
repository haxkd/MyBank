using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Configuration;

namespace MyBank.MyMail
{
    public class SendMails : System.Web.UI.Page
    {
        public string MailEmail = ConfigurationManager.AppSettings["MailEmail"];
        public string MailPassword = ConfigurationManager.AppSettings["MailPassword"];
        public void registerMail(string AccountNumber, string name, string gender, string email, string address, string branchData)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/MyMail/Register.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{AccountNumber}", AccountNumber);
            body = body.Replace("{name}", name);
            body = body.Replace("{gender}", gender);
            body = body.Replace("{email}", email);
            body = body.Replace("{address}", address);
            body = body.Replace("{branchData}", branchData);
            body = body.Replace("{balance}", "0");
            body = body.Replace("{openOn}", DateTime.Now.ToString());
            body = body.Replace("{maxAmount}", "10000");
            body = body.Replace("{minAmount}", "1000");

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(MailEmail);
                mail.To.Add(email);
                mail.Subject = "My Bank Registeration";
                mail.Body = body;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(MailEmail, MailPassword);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }

        public void loginMail(string email, string address,string attempt)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/MyMail/login.html")))
            {
                body = reader.ReadToEnd();
            }
            
            body = body.Replace("{email}", email);
            body = body.Replace("{address}", address);
            body = body.Replace("{openOn}", DateTime.Now.ToString());
            body = body.Replace("{attempt}", attempt);

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(MailEmail);
                mail.To.Add(email);
                mail.Subject = "My Bank login";
                mail.Body = body;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(MailEmail, MailPassword);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }

    
        public void newManager(string email,string password,string name)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/MyMail/Manager.html")))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{email}", email);
            body = body.Replace("{name}", name);
            body = body.Replace("{password}", password);

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(MailEmail);
                mail.To.Add(email);
                mail.Subject = "My Bank new Manager";
                mail.Body = body;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(MailEmail, MailPassword);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    
    }
}