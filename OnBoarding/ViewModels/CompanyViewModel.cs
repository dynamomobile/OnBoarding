using System;
using Realms;
using Realms.Sync;
using Xamarin.Forms;
using System.Linq;
using System.ComponentModel;
namespace OnBoarding
{
	public class CompanyViewModel :ViewModelBase,INotifyPropertyChanged
	{
		public Command CreateCompanyCommand { get; }
		private string _companies = "";
		private string _company = "";
		private IQueryable<Company> RealmCompanies;
		public string Companies
		{
			get
			{
				return _companies;
			}
			set
			{
				Set(ref _companies, value);
			}
		}

		public string Company
		{
			get
			{
				return _company;
			}
			set
			{
				Set(ref _company, value);
			}
		}

		public CompanyViewModel()
		{
			CreateCompanyCommand = new Command(CreateCompany, () => !IsBusy);
		}

		public override void Initialize()
		{
			base.Initialize();
			/*using (var trans = _realm.BeginWrite())
			{
				_realm.RemoveAll<Company>();
				trans.Commit();
			}*/
			RealmCompanies = _realm.All<Company>();
			RealmCompanies.SubscribeForNotifications((sender, changes, error) =>
			{
				// Access changes.InsertedIndices, changes.DeletedIndices, and changes.ModifiedIndices
				loadCompanies();
			});
			loadCompanies();
		}

		private void loadCompanies()
		{
			_companies = "";
			var temp = _realm.All<Company>();
			foreach (var company in temp)
			{
				_companies = _companies + ", " +company.name;
			}
			if (_companies.Length > 0)
			{
				RaisePropertyChanged("Companies");
			}
		}

		private void CreateCompany()
		{
			try
			{
				_realm.Write(() =>
				{
					Company company = new Company();
					company.name = _company;
					_realm.Add(company, false);
				});
			}
			catch (Exception ex)
			{
				DialogService.Alert("Error", ex.ToString());
			}
		}
	}
}
