﻿using BizMathLib.Models;
using NewsLetterLib.Service;
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
        private InvioMail invioMail;
        private RepositoryGenerico<ListaMailNewsletter> repositoryListaMailNewsletter;

        private InvioMailNewsLetter()
        {
            
        }

        public InvioMailNewsLetter(InvioMail _invioMail, RepositoryGenerico<ListaMailNewsletter> _repositoryListaMailNewsletter)
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
