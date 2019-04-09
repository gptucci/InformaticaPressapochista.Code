using AppFocGenova.Interface;
using AppFocGenova.Models;
using FreshMvvm;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppFocacBook
{

    public class MainViewModel :  FreshBasePageModel
    {
        ICommand aggiungipostfocacciaCommand;
        IFocacBookRepository focacbookrepo;
        private bool IsBusy = false;
        private MainViewModel()
        {

        }
        public MainViewModel(IFocacBookRepository _focacbookrepo)
        {
            focacbookrepo = _focacbookrepo;
            //this.Title = "Lista Post";
        }


        public ObservableRangeCollection<FocaccePost> CollectionFocaccePost { get; } = new ObservableRangeCollection<FocaccePost>();

        public override void Init(object initData)
        {
            CollectionFocaccePost.ReplaceRange(focacbookrepo.GetAllPost());
        }

        public override void ReverseInit(object returndData)
        {
            CollectionFocaccePost.ReplaceRange(focacbookrepo.GetAllPost());
        }

        public ICommand AggiungiPostFocacciaPostCommand =>
            aggiungipostfocacciaCommand ?? (aggiungipostfocacciaCommand = new Command(async () => await AggiungiFocacciPostAsync()));



        FocaccePost focaccePostselectedItem;
        public FocaccePost SelectedItem
        {
            get { return focaccePostselectedItem; }
            set
            {
                focaccePostselectedItem = value;
                RaisePropertyChanged();
                
                if (focaccePostselectedItem != null)
                {
                    FocaccePostSelectedCommand.Execute(focaccePostselectedItem);
                    //Application.Current.MainPage.Navigation.PushAsync(new FocacciaPostEditPage(focaccePostselectedItem));
                    //SelectedItem = null;
                }
            }
        }

        public Command<FocaccePost> FocaccePostSelectedCommand
        {
            get
            {
                return new Command<FocaccePost>(async (post) => {
                    await CoreMethods.PushPageModel<FocacciaPostEditViewModel>(post,true,false);
                });
            }
        }


        private async Task AggiungiFocacciPostAsync()
        {
            await CoreMethods.PushPageModel<FocacciaPostEditViewModel>();
        }

    }
}
