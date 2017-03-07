using System;
namespace OnBoarding
{
	public interface IDialogService
	{
		void ShowProgress(string message);
		void HideProgress();
		void Alert(string title, string message);
	}
}
