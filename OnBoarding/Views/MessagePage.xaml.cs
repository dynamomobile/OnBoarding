using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace OnBoarding
{
	public partial class MessagePage : ContentPage
	{
		private readonly Lazy<MessageViewModel> _typedViewModel = new Lazy<MessageViewModel>();
		public MessagePage()
		{
			InitializeComponent();
			Title = "Message";
			_typedViewModel.Value.Initialize();
			BindingContext = _typedViewModel.Value;
		}

		void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
		{
			_typedViewModel.Value.OnValueChanged(sender, e);
		}
	}
}
