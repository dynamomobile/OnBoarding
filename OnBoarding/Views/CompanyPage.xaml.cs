using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace OnBoarding
{
	public partial class CompanyPage : ContentPage
	{
		private readonly Lazy<CompanyViewModel> _typedViewModel = new Lazy<CompanyViewModel>();
		public ViewModelBase ViewModel => _typedViewModel.Value;
		public CompanyPage()
		{
			InitializeComponent();
			Title = "Company";
			ViewModel.Initialize();
			BindingContext = ViewModel;
		}
	}
}
