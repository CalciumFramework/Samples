using System.Windows.Input;

using Codon.Services;
using Codon.UIModel;
using Codon.UIModel.Input;

namespace Sample1
{
	public class Page2ViewModel : ViewModelBase
	{
		readonly INavigationService navigationService;

		/// <summary>
		/// The IoC container uses dependency injection
		/// to pass instances of the specified services.
		/// </summary>
		/// <param name="navigationService">
		/// The cross-platform navigation service allows back navigation.
		/// </param>
		public Page2ViewModel(INavigationService navigationService)
		{
			this.navigationService = navigationService;

			//object argumentPassedFromPage1 = navigationService.NavigationArgument;
		}

		ActionCommand navigateBackCommand;

		public ICommand NavigateBackCommand => navigateBackCommand
			?? (navigateBackCommand = new ActionCommand(NavigateBack));

		void NavigateBack(object arg)
		{
			navigationService.GoBack();
		}
	}
}