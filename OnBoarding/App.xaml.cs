using Xamarin.Forms;
using OnBoarding;
using Realms;
using Realms.Sync;
namespace OnBoarding
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			/*if (User.Current == null)
			{
				User.Current.LogOut();
				//MainPage = new NavigationPage(new LoginPage());
			}
			else
			{
				//MainPage = new NavigationPage(new HomePage());
			}*/
			foreach (User user in User.AllLoggedIn)
			{
				user.LogOut();
			}

			MainPage = new NavigationPage(new LoginPage());
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
