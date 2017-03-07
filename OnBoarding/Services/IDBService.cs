using System;
namespace OnBoarding
{
	public interface IDBService
	{
		Company getCompany();
		void saveCompany(Company company);
	}
}
