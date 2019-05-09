using Xamarin.Forms;

namespace InfPressapochista.AppTest
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new InfPressapochista.AppTest.01Page();
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

