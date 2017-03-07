﻿using System;
using System.Threading.Tasks;
using ThreadingTask = System.Threading.Tasks.Task;
namespace OnBoarding
{
	public interface INavigationService
	{
		ThreadingTask Navigate<T>(Action<T> setup = null) where T : ViewModelBase;

		ThreadingTask GoBack();

		void SetMainPage<T>() where T : ViewModelBase;

		Task<TResult> Prompt<TViewModel, TResult>() where TViewModel : ViewModelBase, IPromptable<TResult>;
	}
}
