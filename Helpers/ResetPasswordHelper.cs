using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AspNetCoreIdentity.Helpers
{
    public static class ResetPasswordHelper
    {
        public static void ResetPasswordSendMail(string link)
        {
            MailMessage mailMessage = new MailMessage();
            SmtpClient client = new SmtpClient("");
            mailMessage.From= new MailAddress("");
            mailMessage.To.Add("");
            mailMessage.Subject = "Şifre Sıfırlama";
            mailMessage.Body = "<h2>Şifreyi sıfırlamak için link'e tıklanıyız.</h2><hr/>";
            mailMessage.Body += $"<a href='{link}'>Şifre Yenileme için Tıkla</a>";
            mailMessage.IsBodyHtml = true;
            client.Port = 25;
            client.Credentials=new System.Net.NetworkCredential("","");
            client.Send(mailMessage);

        }
    }
}
