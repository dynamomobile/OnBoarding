using System;
using Realms;
namespace OnBoarding
{
	public class Message : RealmObject
	{
		public String text { get; set; }
		public Message()
		{
		}
	}
}
