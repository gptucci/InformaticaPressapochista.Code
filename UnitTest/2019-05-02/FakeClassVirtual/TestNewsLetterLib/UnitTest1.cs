using BizMathLib;
using BizMathLib.Models;
using NewsLetterLib.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace TestNewsLetterLib
{
    public class InvioMailFake : InvioMail
    {
        public int NumMailInviate { get; set; }
        public override bool SendEmail(string destinatario, string _TestoEmail)
        {
            NumMailInviate += 1;
            return true;
        }
    }
    public class RepositoryGenericoFake : RepositoryGenerico<ListaMailNewsletter>
    {
        private List<ListaMailNewsletter> mLista = new List<ListaMailNewsletter>();

        public RepositoryGenericoFake()
        {
            mLista.Add(new ListaMailNewsletter() { Mail = "test@test.it", MailDaInviare = true, DataInvioUltimaMail = DateTime.Now });
        }

        public override IEnumerable<ListaMailNewsletter> GetAll()
        {

            return mLista;
        }
        public override void Insert(ListaMailNewsletter obj)
        {
        }
        public override IEnumerable<ListaMailNewsletter> GetItems(Func<ListaMailNewsletter, bool> predicato)
        {


            return mLista.Where(predicato);
        }
        public override void Update(ListaMailNewsletter obj)
        {

        }
        public override void Delete(object id)
        {

        }
        public override void Save()
        {

        }
    }

    public class UnitTest1
    {
        
        [Fact]
        public void Test1()
        {

            InvioMailFake invioMailFake = new InvioMailFake();


            RepositoryGenericoFake repositoryGenericoFake = new RepositoryGenericoFake();

  

            InvioMailNewsLetter invioMailNewsLetter = new InvioMailNewsLetter(invioMailFake, repositoryGenericoFake);
            bool ret=invioMailNewsLetter.EseguiAnalisi("test01");

            Assert.Equal(1,invioMailFake.NumMailInviate);

            Assert.False(repositoryGenericoFake.GetItems(x=>x.Mail== "test@test.it").FirstOrDefault().MailDaInviare);
        }
    }
    

}
