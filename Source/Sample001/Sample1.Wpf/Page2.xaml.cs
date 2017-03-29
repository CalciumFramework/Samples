using System.Windows.Controls;
using Codon;

namespace Sample1
{
	public partial class Page2 : Page
	{
		public Page2()
		{
			DataContext = Dependency.Resolve<Page2ViewModel>();

			InitializeComponent();
		}
	}
}
