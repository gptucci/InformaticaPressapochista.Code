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
    public class FocacciaPostEditViewModel : FreshBasePageModel
    {
        ICommand salvapostfocacciaCommand;
        ICommand cancellapostfocacciaCommand;
        ICommand annullaCommand;
        private FocaccePost focaccePostInEditing = null;
        IFocacBookRepository focacbookrepo;
        private bool IsBusy = false;


        public FocacciaPostEditViewModel(IFocacBookRepository _focacbookrepo)
        {
            focacbookrepo = _focacbookrepo;
            
        }
        public override void Init(object initData)
        {

            FocaccePost focaccePost = initData as FocaccePost;

            if (focaccePost != null)
            {
                //Siamo in modifica
                this.Title = "Modifica Post";
                NomeUtente = focaccePost.NomeUtente;
                Luogo = focaccePost.Luogo;
                DataPost = focaccePost.DataOra.Date;
                OraPost = focaccePost.DataOra.TimeOfDay;
                Voto = focaccePost.Voto;
                VisualizzaCancella = true;
                focaccePostInEditing = focaccePost;
            }
            else
            {
                //siamo in nuovo
                this.Title = "Inserimento Post";

            }
        }

        public ICommand SalvaFocacciaPostCommand =>
            salvapostfocacciaCommand ?? (salvapostfocacciaCommand = new Command(async () => await SalvaFocacciPostAsync()));
        public ICommand CancellaFocacciaPostCommand =>
            cancellapostfocacciaCommand ?? (cancellapostfocacciaCommand = new Command(async () => await CancellaFocacciPostAsync()));

        public ICommand AnnullaCommand =>
            annullaCommand ?? (annullaCommand = new Command(async () => await Application.Current.MainPage.Navigation.PopAsync()));

        private bool visualizzaCancella = false;
        public bool VisualizzaCancella
        {
            get {
                return visualizzaCancella;
            }
            set {
                visualizzaCancella = value;
                RaisePropertyChanged();
            }

        }

        private string title = string.Empty;
        public string Title
        {
            get
            {
                return title;
            }
            set {
                title = value;
                RaisePropertyChanged();
            }
        }


        private string nomeutente = string.Empty;
        public string NomeUtente
        {
   
            get
            {
                return nomeutente;
            }
            set
            {
                nomeutente = value;
                RaisePropertyChanged();
            }
        }

        private string luogo = string.Empty;
        public string Luogo
        {
            get {
                return luogo;
            }
            set {
                luogo = value;
                RaisePropertyChanged();
            }
    
        }

        private int voto =0;
        public int Voto
        {
            
            get
            {
                return voto;
            }
            set
            {
                if (value < 0 || value > 10)
                {
                    voto = 0;
                }
                else
                {
                    voto = value;
                }

                RaisePropertyChanged();
            }

        }

        private DateTime datapost = DateTime.Now;
        public DateTime DataPost
        {
            get
            {
                return datapost;
            }
            set
            {
                datapost = value;
                RaisePropertyChanged();
            }
        }

        private TimeSpan orapost = DateTime.Now.TimeOfDay;
        public TimeSpan OraPost
        {
            

            get
            {
                return orapost;
            }
            set
            {
                orapost = value;
                RaisePropertyChanged();
            }

        }

        private async Task SalvaFocacciPostAsync()
        {

            if (IsBusy)
                return;

            if (string.IsNullOrWhiteSpace(Luogo) ||
                    string.IsNullOrWhiteSpace(NomeUtente))
            {
                await this.CoreMethods.DisplayAlert("Aggiunta/Modifica Focacceria", "Occorre compilare nome utente e luogo", "Ok");
                return;
            }

            IsBusy = true;

            try
            {

                

                if (focaccePostInEditing==null)
                {
                    //Siamo in nuovo
                    var focacciapost = new FocaccePost
                    {
                        NomeUtente = this.NomeUtente,
                        Luogo = this.Luogo,
                        DataOra = new DateTime(DataPost.Year, DataPost.Month, DataPost.Day, OraPost.Hours, OraPost.Minutes, OraPost.Seconds),
                        Voto = this.Voto
                    };

                    focacbookrepo.AddItem(focacciapost);
                }else
                {
                    //Siamo in editing
                    focaccePostInEditing.NomeUtente = this.NomeUtente;
                    focaccePostInEditing.Luogo = this.Luogo;
                    focaccePostInEditing.DataOra = new DateTime(DataPost.Year, DataPost.Month, DataPost.Day, OraPost.Hours, OraPost.Minutes, OraPost.Seconds);
                    focaccePostInEditing.Voto = this.Voto;

                    
                }


                
                this.NomeUtente = string.Empty;
                this.Luogo = string.Empty;
                this.Voto = 0;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("====>Errore: " + ex);
            }
            finally
            {
                IsBusy = false;
                await CoreMethods.PopPageModel();
            }


        }
        private async Task CancellaFocacciPostAsync()
        {
            if (IsBusy)
                return;

            bool ret= await CoreMethods.DisplayAlert("Cancellazione Focacceria","Si desidera continuare con la cancellazione ?", "Esci","Ok");
            if (ret)
                return;
            

            try
            {
                IsBusy = true;


                if (focaccePostInEditing != null)
                {
                    focacbookrepo.DeleteItem(focaccePostInEditing);
                }
                                

                

            }
            catch (Exception ex)
            {
                Debug.WriteLine("====>Errore: " + ex);
            }
            finally
            {
                IsBusy = false;
                await CoreMethods.PopPageModel(focaccePostInEditing);
            }


        }
    }
}
