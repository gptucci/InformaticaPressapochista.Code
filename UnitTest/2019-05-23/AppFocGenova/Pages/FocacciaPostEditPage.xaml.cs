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
	//[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FocacciaPostEditPage : ContentPage
	{
        //private FocacciaPostEditPage ()
        //{
        //	InitializeComponent ();
        //}

        private FocacciaPostEditViewModel vm;

        public FocacciaPostEditPage(FocaccePost focaccePost )
        {
            InitializeComponent();
            

        }
    }
}