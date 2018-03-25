using System.Windows.Input;
using Codon;
using Codon.Services;
using Codon.UIModel;
using Codon.UIModel.Input;

namespace CustomDialogServiceExample
{
	public sealed class MainViewModel : ViewModelBase
	{
		ActionCommand showNotificationCommand;

		public ICommand ShowNotificationCommand => showNotificationCommand
				?? (showNotificationCommand = new ActionCommand(ShowNotification));

		void ShowNotification(object arg)
		{
			Dependency.Resolve<IDialogService>().ShowToastAsync("This is a toast notification via Codon.");
		}
	}
}