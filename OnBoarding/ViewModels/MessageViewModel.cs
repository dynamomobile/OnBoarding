using System;
using Realms;
using Realms.Sync;
using Xamarin.Forms;
using System.Linq;
using System.ComponentModel;
using System.Threading.Tasks;
namespace OnBoarding
{
	public class MessageViewModel :ViewModelBase, INotifyPropertyChanged
	{
		public Command LogOutCommand { get; }

		private string _message = "";
		private string _input = "";
		private Message RealmMessage;

		public string Message
		{
			get
			{
				return _message;
			}
			set
			{
				Set(ref _message, value);
			}
		}

		public string Input
		{
			get
			{
				return _input;
			}
			set
			{
				Set(ref _input, value);
			}
		}

		public MessageViewModel()
		{
			LogOutCommand = new Command(logout, () => !IsBusy);
		}

		public override void Initialize()
		{
			base.Initialize();
			PerformTask(setupListener, (obj) =>
			{
			});
		}
		private void loadMessage()
		{
			if (RealmMessage != null)
			{
				_message = RealmMessage.text;
				RaisePropertyChanged("Message");
			}
		}

		private void logout()
		{
			foreach (User user in User.AllLoggedIn)
			{
				user.LogOut();
			}
			App.Current.MainPage = new NavigationPage(new LoginPage());
		}

		public void OnValueChanged(object sender, Xamarin.Forms.TextChangedEventArgs args)
		{
			try
			{
				using (var trans = _realm.BeginWrite())
				{
					RealmMessage.text = args.NewTextValue;
					trans.Commit();
				}
			}
			catch (Exception ex)
			{
				//DialogService.Alert("Error", ex.ToString());
			}
		}

		private async Task setupListener()
		{
			await Task.Delay(1000);

			RealmMessage = _realm.All<Message>().First();
			if (RealmMessage == null)
			{
				_realm.Write(() =>
				{
					RealmMessage = new Message();
					_realm.Add(RealmMessage);
				});
			}
			RealmMessage.PropertyChanged += (sender, e) =>
			{
				loadMessage();
			};
		}
	}
}
