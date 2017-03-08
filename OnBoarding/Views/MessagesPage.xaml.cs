using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace OnBoarding
{
	public partial class MessagesPage : ContentPage
	{
		private readonly Lazy<MessageViewModel> _typedViewModel = new Lazy<MessageViewModel>();
		public ViewModelBase ViewModel => _typedViewModel.Value;
		public MessagesPage()
		{
			InitializeComponent();
			Title = "Messages";
			ViewModel.Initialize();
			BindingContext = ViewModel;
		}
	}
}
