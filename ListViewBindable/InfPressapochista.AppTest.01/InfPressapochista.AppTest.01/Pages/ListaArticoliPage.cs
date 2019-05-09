using System;
using InfPressapochista.AppTest01.Pages;
using Xamarin.Forms;
using InfPressapochista.AppTest01.ViewModels;
using InfPressapochista.AppTest01.Views;


namespace InfPressapochista.AppTest01.Pages
{
	public class ListaArticoliPage: ContentPage
	{
		ArticoliListaViewModel _ArticoliListaViewModel;
		protected ListViewExt listView;

		public ListaArticoliPage()
		{
			BindingContext = _ArticoliListaViewModel = new ArticoliListaViewModel();
			listView = new ListViewExt()
			{
				ItemTemplate = new DataTemplate(() => new ListaArticoliViewCell())
			};

			listView.SetBinding<ArticoliListaViewModel>(ListViewExt.ItemsSourceProperty, x=>x.ListaArticoli, BindingMode.OneWay);

			listView.SetBinding<ArticoliListaViewModel>(ListViewExt.ItemSelezionatoCommandProperty, x=>x.ItemSelezionatoCommand, BindingMode.OneWay);

			var stackLayout = new StackLayout()
			{
				Orientation = StackOrientation.Vertical,
				Children = {  listView }
			};

			this.Content = stackLayout;

		}
	}
}

