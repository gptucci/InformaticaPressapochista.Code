using BizMathLib.Models;
using NewsLetterLib.Interface;
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
        private IInvioMail invioMail;
        private IRepositoryGenerico<ListaMailNewsletter> repositoryListaMailNewsletter;


        private InvioMailNewsLetter()
        {

        }
        public InvioMailNewsLetter( IInvioMail _invioMail, IRepositoryGenerico<ListaMailNewsletter> _repositoryListaMailNewsletter)
        {
            invioMail = _invioMail;
            repositoryListaMailNewsletter = _repositoryListaMailNewsletter;
        }

        public bool EseguiAnalisi(string _TestoEmail)
        {
            List<ListaMailNewsletter> ListaMailDaInviare = repositoryListaMailNewsletter.GetItems(x => x.MailDaInviare && !string.IsNullOrEmpty(x.Mail)).ToList();

            foreach (var item in ListaMailDaInviare)
            {
                if (!invioMail.SendEmail(item.Mail, _TestoEmail))
                    return false;

                item.MailDaInviare = false;

            }

            repositoryListaMailNewsletter.Save();
            return true;

        }
        
    }
}
