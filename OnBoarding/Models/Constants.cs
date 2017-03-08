using System;
namespace OnBoarding
{
	public static class Constants
	{
		public static String email;
		public static class Server
		{
			public static string SyncHost { get; set; } = "54.172.70.246:9080";

			public static Uri SyncServerUri => new Uri($"realm://{SyncHost}/DynaBoarding");

			public static Uri AuthServerUri => new Uri($"http://{SyncHost}");

		}
	}
}
