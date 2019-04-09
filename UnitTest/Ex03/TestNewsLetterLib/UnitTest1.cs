using BizMathLib;
using BizMathLib.Models;
using NewsLetterLib.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Xunit;

namespace TestNewsLetterLib
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            InvioMailNewsLetter invioMailNewsLetter = new InvioMailNewsLetter();
            InvioMailFake invioMailFake = new InvioMailFake();
            RepositoryGenericoFake repositoryGenericoFake = new RepositoryGenericoFake();
            bool ret = invioMailNewsLetter.EseguiAnalisi("test01", invioMailFake, repositoryGenericoFake);
            Assert.True(ret);
            Assert.Equal(1, invioMailFake.NumMailInviate);
        }
    }

    public class InvioMailFake:IInvioMail
    {
        public int NumMailInviate { get; set; }

        public bool SendEmail(string destinatario, string _TestoEmail)
        {
            NumMailInviate += 1;
            return true;
        }
    }

    public class RepositoryGenericoFake : IRepositoryGenerico<ListaMailNewsletter> 
    {
        private List<ListaMailNewsletter> mLista = new List<ListaMailNewsletter>();

        public RepositoryGenericoFake()
        {
            mLista.Add(new ListaMailNewsletter() { Mail = "test@test.it", MailDaInviare = true, DataInvioUltimaMail = DateTime.Now });
        }
        
        public IEnumerable<ListaMailNewsletter> GetAll()
        {
            
            return mLista;
        }
        public void Insert(ListaMailNewsletter obj)
        {
        }
        public IEnumerable<ListaMailNewsletter> GetItems(Func<ListaMailNewsletter, bool> predicato)
        {
            //var tt = mLista.Where(predicato);

            return mLista.Where(predicato);
        }
        public void Update(ListaMailNewsletter obj)
        {
           
        }
        public void Delete(object id)
        {
           
        }
        public void Save()
        {
           
        }
    }

}
