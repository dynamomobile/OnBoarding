using System;
using System.Collections.Generic;
using Realms.Sync;
using Xamarin.Forms;
using Acr.Settings;

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
			Title = Settings.Local.Get("EMAIL", "");
		}
	}
}
