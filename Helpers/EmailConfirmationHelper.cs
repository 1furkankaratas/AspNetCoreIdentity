using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AspNetCoreIdentity.Helpers
{
    public static class EmailConfirmationHelper
    {
        public static void EmailConfirmationSendMail(string link, string email)
        {
            MailMessage mailMessage = new MailMessage();
            SmtpClient client = new SmtpClient("");
            mailMessage.From = new MailAddress("");
            mailMessage.To.Add(email);
            mailMessage.Subject = "Hesap Doğrulama";
            mailMessage.Body = "<h2>Hesap Doğrulama</h2><hr/>";
            mailMessage.Body += $"<a href='{link}'>Doğrulamak için tıklayınız</a>";
            mailMessage.IsBodyHtml = true;
            client.Port = 25;
            client.Credentials = new System.Net.NetworkCredential("", "");
            client.Send(mailMessage);

        }
    }
}
