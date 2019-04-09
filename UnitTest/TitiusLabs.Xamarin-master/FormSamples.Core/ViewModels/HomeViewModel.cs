﻿using System;
using System.Windows.Input;
using TitiusLabs.Forms.ViewModels;
using Xamarin.Forms;

namespace FormSamples.Core.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand GoToSecondPageCommand
        {
            get{ return GetValue<ICommand>();}
            set { SetValue(value); }
        }

        public MainViewModel()
        {
            GoToSecondPageCommand = new Command(async() => await NavigateToModal(new NavigationFirstViewModel() { Title = "First View"}));
        }
    }
}
