using System;
using Realms;
using Realms.Sync;
using Xamarin.Forms;
using Acr.Settings;
namespace OnBoarding
{
	public class LoginViewModel : ViewModelBase
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
				try
				{
					var permissionChange = new PermissionChange("*",
					                                            "*",
					                                            mayRead: true,
					                                            mayWrite: true,
					                                            mayManage: true);

					User.Current.GetManagementRealm().Write(() =>
					{
						User.Current.GetManagementRealm().Add(permissionChange);
					});
					Settings.Local.SetValue("EMAIL", Username);
				}
				catch (Exception ex)
				{
					DialogService.Alert("Error", ex.ToString());
				}

				App.Current.MainPage = new NavigationPage(new HomePage());
			}, onError: ex =>
			{
				// TODO: show alert.

				DialogService.Alert("Unable to login", ex.Message);
				HandleException(ex);
			}, progressMessage: "Logging in...");
		}
	}
}
