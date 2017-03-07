using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace OnBoarding
{
	public partial class LoginPage : ContentPage
	{
		private readonly Lazy<LoginViewModel> _typedViewModel = new Lazy<LoginViewModel>();

		public ViewModelBase ViewModel => _typedViewModel.Value;

		public LoginPage()
		{
			InitializeComponent();
			BindingContext = ViewModel;
		}
	}
}
