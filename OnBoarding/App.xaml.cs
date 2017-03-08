using System;
using Xamarin.Forms;
using Realms.Sync;
namespace OnBoarding
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			try
			{
				if (User.Current == null)
				{
					MainPage = new NavigationPage(new LoginPage());
				}
				else
				{
					MainPage = new NavigationPage(new HomePage());
				}
			}
			catch (Exception)
			{
				MainPage = new NavigationPage(new LoginPage());
			}
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
