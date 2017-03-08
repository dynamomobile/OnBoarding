using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace OnBoarding
{
	public partial class HomePage : TabbedPage
	{
		private readonly Lazy<HomeViewModel> _typedViewModel = new Lazy<HomeViewModel>();

		public ViewModelBase ViewModel => _typedViewModel.Value;

		public HomePage()
		{
			InitializeComponent();
			ViewModel.Initialize();
			BindingContext = ViewModel;
		}
	}
}
