using System;
using Realms;
using Realms.Sync;
using Xamarin.Forms;
namespace OnBoarding
{
	public class CompanyViewModel :ViewModelBase
	{
		public Command CreateCompanyCommand { get; }

		public CompanyViewModel()
		{
			CreateCompanyCommand = new Command(CreateCompany, () => !IsBusy);
		}

		private void CreateCompany()
		{
			try
			{
				_realm.Write(() =>
				{
					Company company = new Company();
					company.name = "Dynamo";
					_realm.Add(company);
				});
			}
			catch (Exception ex)
			{
				DialogService.Alert("Error", ex.ToString());
			}
		}
	}
}
