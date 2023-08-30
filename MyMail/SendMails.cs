using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;




namespace MyBank.MyMail
{
    public class SendMails : System.Web.UI.Page
    {
        public void registerMail(string AccountNumber, string name, string gender, string email, string address, string branchData, string balance,string maxAmount,string minAmount)
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
            body = body.Replace("{balance}", balance);
            body = body.Replace("{openOn}", DateTime.Now.ToString());
            body = body.Replace("{maxAmount}", maxAmount);
            body = body.Replace("{minAmount}", minAmount);

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("haxkdmail@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Purchased Course Summary";
                mail.Body = body;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("haxkdmail@gmail.com", "geneqppuemqmupls");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
}