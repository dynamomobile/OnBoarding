using Xamarin.Forms;
using OnBoarding;
namespace OnBoarding
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			var navigationService = DependencyService.Get<INavigationService>(DependencyFetchTarget.GlobalInstance);
			navigationService.SetMainPage<LoginViewModel>();
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
