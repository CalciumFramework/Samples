using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Codon;
using Codon.ComponentModel;
using Codon.Services;
using Codon.UIModel;
using Codon.UIModel.Input;

namespace AsyncCommandsExample
{
	public class MainViewModel : ViewModelBase, IExceptionHandler
	{
		public MainViewModel()
		{
			/* If an exception occurs during the execution of a command,
			 * the ShouldRethrowException method is called. */
			Dependency.Register<IExceptionHandler>(this);
		}

		AsyncActionCommand doWorkCommand;

		public ICommand DoWorkCommand => doWorkCommand
			?? (doWorkCommand = new AsyncActionCommand(
					DoWorkAsync, CanDoWorkAsync));

		Task<bool> CanDoWorkAsync(object arg)
		{
			return Task.FromResult(!busy);
		}

		async Task DoWorkAsync(object arg)
		{
			try
			{
				Busy = true;
				doWorkCommand.RaiseCanExecuteChanged();

				if (raiseException)
				{
					throw new Exception(
						"This exception is handled by the ShouldRethrowException method.");
				}

				/* Wait for a few seconds before completion. */
				await Task.Delay(5000);

				await Dependency.Resolve<IDialogService>().ShowMessageAsync(
					"The command has finished processing asynchronously.", "Activity Complete");
			}
			finally
			{
				Busy = false;
				doWorkCommand.RaiseCanExecuteChanged();
			}
		}

		bool raiseException;

		public bool RaiseException
		{
			get => raiseException;
			set => Set(ref raiseException, value);
		}


		bool busy;

		public bool Busy
		{
			get => busy;
			private set => Set(ref busy, value);
		}

		bool IExceptionHandler.ShouldRethrowException(Exception exception, object owner, 
			[CallerMemberName]string memberName = null, 
			[CallerFilePath]string filePath = null,
			[CallerLineNumber]int lineNumber = 0)
		{
			Dependency.Resolve<IDialogService>().ShowMessageAsync(
				"Exception thrown: " + exception.Message);
			
			return false;
		}
	}
}
