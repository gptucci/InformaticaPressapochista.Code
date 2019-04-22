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
            
            Mock<IInvioMail> invioMailFake = new Mock<IInvioMail>();
            invioMailFake.Setup(x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            Mock<IRepositoryGenerico<ListaMailNewsletter>> repositoryGenericoFake = new Mock<IRepositoryGenerico<ListaMailNewsletter>>();

            List<ListaMailNewsletter> mLista = new List<ListaMailNewsletter>();
            mLista.Add(new ListaMailNewsletter() { Mail = "test@test.it", MailDaInviare = false, DataInvioUltimaMail = DateTime.Now });
            repositoryGenericoFake.Setup(x => x.GetItems(It.IsAny<Func<ListaMailNewsletter, bool>>())).Returns(mLista);

            InvioMailNewsLetter invioMailNewsLetter = new InvioMailNewsLetter();
            bool ret=invioMailNewsLetter.EseguiAnalisi("test01", invioMailFake.Object, repositoryGenericoFake.Object);
            Assert.True(ret);

            invioMailFake.Verify(x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>()),Times.Once);
            //invioMailFake.Verify(x => x.SendEmail("test@test.it", It.IsAny<string>()), Times.Once);


        }
    }

}
