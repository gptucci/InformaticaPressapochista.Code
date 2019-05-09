using System;
using InfPressapochista.AppTest01.Models;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace InfPressapochista.AppTest01.ViewModels
{
public class ArticoliListaViewModel : INotifyPropertyChanged
{
	private List<Articolo> _ListaArticoli;

	public ArticoliListaViewModel()
	{
		_ListaArticoli = new List<Articolo>();
		_ListaArticoli.Clear();
		for (int i = 0; i < 1800; i++)
		{
			_ListaArticoli.Add(new Articolo()
			{
				CodArt = "Articolo" + i.ToString(),
				Descrizione = "Descrizione" + i.ToString()
			});
		}
	}

	public List<Articolo> ListaArticoli
	{
		get { return _ListaArticoli; }

		set
		{
			_ListaArticoli = value;
			OnPropertyChanged("ListaArticoli");
		}
	}

	public ICommand ItemSelezionatoCommand
	{
		get { return new Command<Articolo>(ItemSelezionato); }
	}

	async void ItemSelezionato(Articolo _articoloSelezionato)
	{
		System.Diagnostics.Debug.WriteLine(">>Item Selezionato - Tipo " + _articoloSelezionato.GetType().ToString());
		System.Diagnostics.Debug.WriteLine(">>Item Selezionato - Cod Art " + _articoloSelezionato.CodArt);

	}

	public event PropertyChangedEventHandler PropertyChanged;
	public void OnPropertyChanged(string propertyName)
	{
		if (this.PropertyChanged != null)
		{
			PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
			this.PropertyChanged(this, e);
		}
	}
}
}

