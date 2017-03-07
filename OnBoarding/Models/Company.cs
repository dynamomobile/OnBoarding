using System;
using System.Linq;
using Realms;
namespace OnBoarding
{
	public class Company : RealmObject
	{
		[PrimaryKey]
		public String name { get; set;}

		public String address {get; set; }

		public String webLink { get; set; }

		public String phone { get; set; }

		[Backlink(nameof(Employee.company))]
		public IQueryable<Employee> employees { get; }

		[Backlink(nameof(Team.company))]
		public IQueryable<Team> teams { get; }

		public Company()
		{
		}
	}
}
