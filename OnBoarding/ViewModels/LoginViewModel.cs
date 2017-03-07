using System;
using Realms;
using Realms.Sync;
using Xamarin.Forms;
namespace OnBoarding
{
	public class LoginViewModel : ViewModelBase,IPromptable<User>
	{
		public Command LoginCommand { get; }
		private string _password;
		public string Password
		{
			get
			{
				return _password;
			}

			set
			{
				Set(ref _password, value);
			}
		}

		private string _username;
		public string Username
		{
			get
			{
				return _username;
			}

			set
			{
				Set(ref _username, value);
			}
		}

		public LoginViewModel()
		{
			LoginCommand = new Command(Login, () => !IsBusy);
		}

		private void Login()
		{
			PerformTask(async () =>
			{
				var credentials = Credentials.UsernamePassword(Username, Password, false);
				await User.LoginAsync(credentials, Constants.Server.AuthServerUri);
				//var user = await User.LoginAsync(credentials, Constants.Server.AuthServerUri);
				//Success(user);
				NavigationService.SetMainPage<HomeViewModel>();
			}, onError: ex =>
			{
				// TODO: show alert.

				DialogService.Alert("Unable to login", ex.Message);
				HandleException(ex);
			}, progressMessage: "Logging in...");
		}


		#region Promptable

		public Action<User> Success { get; set; }

		public Action Cancel { get; set; }

		public Action<Exception> Error { get; set; }

		#endregion
	}
}
