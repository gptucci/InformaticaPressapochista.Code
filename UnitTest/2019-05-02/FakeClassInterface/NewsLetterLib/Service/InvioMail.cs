using NewsLetterLib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetterLib.Service
{
    public class InvioMail:IInvioMail
    {
        public bool SendEmail(string destinatario, string _TestoEmail)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("your_email_address@gmail.com");
                mail.To.Add(destinatario);
                mail.Subject = "News Letter fanstastica";
                mail.Body = _TestoEmail;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("username", "password");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;

        }
    }
}
