using System;
using System.Collections.Generic;
using Realms;
using System.Linq;
namespace OnBoarding
{
	public class Employee : RealmObject
	{
		[PrimaryKey]
		public String email { get; set; }
		public String fName { get; set; }
		public String lName { get; set; }
		public String phone { get; set; }
		public Company company { get; set;}
		public Employee()
		{
		}
	}
}
