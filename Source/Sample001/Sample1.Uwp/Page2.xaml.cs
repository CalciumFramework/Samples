using Windows.UI.Xaml.Controls;
using Codon;

namespace Sample1
{
	public sealed partial class Page2 : Page
	{
		public Page2()
		{
			DataContext = Dependency.Resolve<Page2ViewModel>();

			InitializeComponent();
		}

		public Page2ViewModel ViewModel => (Page2ViewModel)DataContext;
	}
}
