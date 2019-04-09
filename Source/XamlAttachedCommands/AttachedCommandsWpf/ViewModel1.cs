using System.Windows.Input;
using Codon;
using Codon.Services;
using Codon.UIModel;
using Codon.UIModel.Input;

namespace CommandBehaviorDemo
{
	public class ViewModel1 : ViewModelBase
	{
		ActionCommand showDialogCommand;

		public ICommand ShowDialogCommand => showDialogCommand
				?? (showDialogCommand = new ActionCommand(ShowDialog));

		void ShowDialog(object arg)
		{
			Dependency.Resolve<IDialogService>().ShowMessageAsync("Image clicked.");
		}
	}
}
