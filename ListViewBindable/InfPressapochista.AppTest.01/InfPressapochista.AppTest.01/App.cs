using System;
using Xamarin.Forms;
using InfPressapochista.AppTest01.Pages;

namespace InfPressapochista.AppTest01
{
	public class App : Application
	{
		public App()
		{

			MainPage = new ListaArticoliPage();

		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

