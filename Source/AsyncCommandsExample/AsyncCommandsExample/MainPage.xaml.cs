using Windows.UI.Xaml.Controls;
using Codon;

namespace AsyncCommandsExample
{
	public sealed partial class MainPage : Page
	{
		public MainPage()
		{
			this.InitializeComponent();

			DataContext = Dependency.Resolve<MainViewModel>();
		}

		public MainViewModel ViewModel => (MainViewModel)DataContext;
	}
}
