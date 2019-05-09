using System;
using Xamarin.Forms;
using InfPressapochista.AppTest01.Models;

namespace InfPressapochista.AppTest01.Views
{
	public class ListaArticoliViewCell: ViewCell
	{
		public ListaArticoliViewCell()
		{
			Label CodArt = new Label();
			CodArt.SetBinding<Articolo>(Label.TextProperty, x=>x.CodArt);

			Label Descrizione = new Label();
			Descrizione.SetBinding<Articolo>(Label.TextProperty, x => x.Descrizione);

			var view = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal,
				Children =
				{
					CodArt,
					Descrizione
				}
			};

			View = view;
		}
	}
}

