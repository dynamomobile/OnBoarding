﻿using System;
using Acr.UserDialogs;
using OnBoarding;
using Xamarin.Forms;

[assembly: Dependency(typeof(DialogService))]
namespace OnBoarding
{
	public class DialogService : IDialogService
	{
		public void HideProgress()
		{
			UserDialogs.Instance.HideLoading();
		}

		public void ShowProgress(string message)
		{
			UserDialogs.Instance.ShowLoading(message);
		}

		public void Alert(string title, string message)
		{
			UserDialogs.Instance.Alert(message, title);
		}
	}
}
