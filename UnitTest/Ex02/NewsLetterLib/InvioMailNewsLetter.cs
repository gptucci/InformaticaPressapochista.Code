using BizMathLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BizMathLib
{
    public class InvioMailNewsLetter
    {
        private LocalDbContext mLocalDbContext = new LocalDbContext();
        public bool EseguiAnalisi(string _TestoEmail)
        {
            List<ListaMailNewsletter> ListaMailDaInviare = mLocalDbContext.SaldiFinali.Where(x => x.MailDaInviare && !string.IsNullOrEmpty(x.Mail)).ToList();

            foreach (var item in ListaMailDaInviare)
            {
                if (!SendEmail(item.Mail, _TestoEmail))
                    return false;

                item.MailDaInviare = false;

            }

            mLocalDbContext.SaveChanges();
            return true;

        }
        


        private bool SendEmail(string destinatario, string _TestoEmail)
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
