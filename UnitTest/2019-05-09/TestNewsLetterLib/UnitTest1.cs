using BizMathLib;
using BizMathLib.Models;
using Moq;
using NewsLetterLib.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xunit;

namespace TestNewsLetterLib
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Creo un oggetto fake che implementa l'interfaccia IInvioMail
            Mock<IInvioMail> invioMailFake = new Mock<IInvioMail>(MockBehavior.Strict);

            //Configuro questo oggetto in modo tale che se gli passo qualisiasi valore stringa per i due parametri
            //destinatario e testo mail questo trestituisca true
            invioMailFake.Setup(x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>())).Returns(true);


            //Creo un oggetto fake che implementa l'interfaccia IRepositoryGenerico
            Mock<IRepositoryGenerico<ListaMailNewsletter>> repositoryGenericoFake = new Mock<IRepositoryGenerico<ListaMailNewsletter>>(MockBehavior.Loose);

            //Configuro questo oggetto in modo tale che per qualisiasi predicato passi allora restituisca sempre 
            //la lista impostata
            List<ListaMailNewsletter> mLista = new List<ListaMailNewsletter>();
            mLista.Add(new ListaMailNewsletter() { Mail = "test@test.it", MailDaInviare = false, DataInvioUltimaMail = DateTime.Now });
            repositoryGenericoFake.Setup(x => x.GetItems(It.IsAny<Func<ListaMailNewsletter, bool>>())).Returns(mLista);

            InvioMailNewsLetter invioMailNewsLetter = new InvioMailNewsLetter(invioMailFake.Object, repositoryGenericoFake.Object);
            bool ret=invioMailNewsLetter.EseguiAnalisi("test01");
            Assert.True(ret);

            invioMailFake.Verify(x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>()),Times.Once);

        }
    }

}
