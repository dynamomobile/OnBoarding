using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace OnBoarding
{
	public partial class MessagePage : ContentPage
	{
		private readonly Lazy<MessageViewModel> _typedViewModel = new Lazy<MessageViewModel>();
		public MessageViewModel ViewModel => _typedViewModel.Value;
		public MessagePage()
		{
			InitializeComponent();
			Title = "Message";
			ViewModel.Initialize();
			BindingContext = ViewModel;
		}



		void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
		{
			ViewModel.OnValueChanged(sender, e);
		}
	}
}
