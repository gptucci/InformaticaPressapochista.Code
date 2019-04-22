using AppFocGenova.Interface;
using Moq;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xunit;
using System.Linq;
using AppFocGenova;
using AppFocacBook;
using System.Collections.Generic;
using AppFocGenova.Models;
using FreshMvvm;

namespace XUnitTestFocacBook
{
    public class UnitTest1
    {
        public UnitTest1()
        {
            Xamarin.Forms.Mocks.MockForms.Init();

        }

        [Fact]
        public void Test_AperturaNuovaMaschera()
        {

            Mock<IFocacBookRepository> mockFocacBookRepository = new Mock<IFocacBookRepository>();
            mockFocacBookRepository.Setup(x => x.GetAllPost()).Returns(new System.Collections.Generic.List<AppFocGenova.Models.FocaccePost>());

            MainViewModel mMainPageViewModel = new MainViewModel(mockFocacBookRepository.Object);


            var coreMethodsMock = new Mock<IPageModelCoreMethods>(MockBehavior.Strict);

            coreMethodsMock.Setup(x => x.PushPageModel<FocacciaPostEditViewModel>(It.IsAny<bool>())).Returns(Task.CompletedTask);


            mMainPageViewModel.CoreMethods = coreMethodsMock.Object;
            mMainPageViewModel.AggiungiPostFocacciaPostCommand.Execute(null);

            coreMethodsMock.Verify(x => x.PushPageModel<FocacciaPostEditViewModel>(It.IsAny<bool>()));

        }
        [Fact]
        public void Test2()
        {
            Mock<IFocacBookRepository> mockFocacBookRepository = new Mock<IFocacBookRepository>();

            List<FocaccePost> ListaFocaccePost = new List<FocaccePost>();
            ListaFocaccePost.Add(new FocaccePost()
            {
                Id = Guid.NewGuid().ToString(),
                NomeUtente = "gptucci",
                Luogo = "Genova, Focacceria XYZ",
                DataOra = DateTime.Now,
                Voto = 5
            });

            ListaFocaccePost.Add(new FocaccePost()
            {
                Id = Guid.NewGuid().ToString(),
                NomeUtente = "gptucci",
                Luogo = "Genova, Focacceria ZYX",
                DataOra = DateTime.Now,
                Voto = 1
            });

            mockFocacBookRepository.Setup(x => x.GetAllPost()).Returns(ListaFocaccePost);

            MainViewModel mMainPageViewModel = new MainViewModel(mockFocacBookRepository.Object);

            var coreMethodsMock = new Mock<FreshMvvm.IPageModelCoreMethods>(MockBehavior.Strict);
            coreMethodsMock.Setup(x => x.PushPageModel<FocacciaPostEditViewModel>(It.IsAny<object>(), It.IsAny<bool>(), It.IsAny<bool>())).Returns(Task.CompletedTask);



            mMainPageViewModel.CoreMethods = coreMethodsMock.Object;

            mMainPageViewModel.SelectedItem = ListaFocaccePost[0];

            coreMethodsMock.Verify(x => x.PushPageModel<FocacciaPostEditViewModel>(ListaFocaccePost[0], It.IsAny<bool>(), It.IsAny<bool>()));




        }
    }
}
