using System;
using Realms;
using Realms.Sync;
using Xamarin.Forms;
using System.Linq;
using System.ComponentModel;
namespace OnBoarding
{
	public class MessageViewModel :ViewModelBase, INotifyPropertyChanged
	{
		public Command SendMessageCommand { get; }
		private string _messages = "";
		private string _message = "";
		private IQueryable<Message> RealmMessages;

		public string Messages
		{
			get
			{
				return _messages;
			}
			set
			{
				Set(ref _messages, value);
			}
		}

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

		public MessageViewModel()
		{
			SendMessageCommand = new Command(SendMessage, () => !IsBusy);
		}

		public override void Initialize()
		{
			base.Initialize();
			/*using (var trans = _realm.BeginWrite())
			{
				_realm.RemoveAll<Company>();
				trans.Commit();
			}*/
			RealmMessages = _realm.All<Message>();
			RealmMessages.SubscribeForNotifications((sender, changes, error) =>
			{
				// Access changes.InsertedIndices, changes.DeletedIndices, and changes.ModifiedIndices
				loadMessages();
			});
			loadMessages();
		}

		private void loadMessages()
		{
			_messages = "";
			var temp = _realm.All<Message>();
			foreach (var message in temp)
			{
				_messages = _messages + message.text + ", ";
			}
			if (_messages.Length > 0)
			{
				RaisePropertyChanged("Messages");
			}
		}

		private void SendMessage()
		{
			try
			{
				_realm.Write(() =>
				{
					Message message = new Message();
					message.text = _message;
					_realm.Add(message, false);
				});
			}
			catch (Exception ex)
			{
				DialogService.Alert("Error", ex.ToString());
			}
		}
	}
}
