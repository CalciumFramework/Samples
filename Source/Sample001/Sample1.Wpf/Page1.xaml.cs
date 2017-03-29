using System.Windows.Controls;
using Codon;

namespace Sample1
{
	/// <summary>
	/// Interaction logic for Page1.xaml
	/// </summary>
	public partial class Page1 : Page
	{
		public Page1()
		{
			/* Using the Dependency class to resolve 
			 * the view-model automatically causes it to recieve 
			 * the services it needs via dependency injection. */
			DataContext = Dependency.Resolve<Page1ViewModel>();

			InitializeComponent();
		}
	}
}
