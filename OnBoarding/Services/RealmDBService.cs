using System;
using System.Linq;
using Realms;
namespace OnBoarding
{
	public class RealmDBService : IDBService
	{
		protected Realm RealmInstance;
		private Uri authURL = new Uri("http://54.172.70.246:9080/auth");
		private Uri syncURL = new Uri("realm://54.172.70.246:9080/~/default");
		public RealmDBService()
		{
			RealmInstance = Realm.GetInstance();
		}

		public Company getCompany()
		{
			return RealmInstance.All<Company>().First();
		}

		public void saveCompany(Company company)
		{
			RealmInstance.Write(() =>{
				RealmInstance.Add(company, update: true);
			});
		}
	}
}
