using AppFocGenova.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFocacBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
	{

        public MainPage()
		{
			InitializeComponent();
            //BindingContext = vm =new MainViewModel(new FocacBookRepository());
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    //vm.LoadFocaccePostCommand.Execute(null);
            
        //}
    }
}
