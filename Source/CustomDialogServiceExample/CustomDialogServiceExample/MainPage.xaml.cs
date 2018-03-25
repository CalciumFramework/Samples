using Windows.UI.Xaml.Controls;
using Codon;
using Codon.Services;
using CustomDialogServiceExample.Services;

namespace CustomDialogServiceExample
{
	public sealed partial class MainPage : Page
	{
		public MainPage()
		{
			this.InitializeComponent();

			DataContext = Dependency.Resolve<MainViewModel>();

			var dialogService = (CustomDialogService)Dependency.Resolve<IDialogService>();
			dialogService.InAppNotification = InAppNotification;
		}

		public MainViewModel ViewModel => (MainViewModel)DataContext;
	}
}
