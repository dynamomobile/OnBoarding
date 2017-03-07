using System;
using System.Collections.Generic;
using System.Linq;
using Realms;
namespace OnBoarding
{
	public class Team : RealmObject
	{
		[PrimaryKey]
		public String name { get; set; }

		public Company company { get; set; }
		public IList<Employee> employees { get;}

		[Backlink(nameof(Employee.teams))]
		public IQueryable<Employee> teamEmployees { get; }

		public Team()
		{
		}
	}
}
