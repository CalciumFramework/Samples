using Windows.UI.Xaml.Controls;

using Codon;

namespace Sample1
{
    public sealed partial class Page1 : Page
    {
        public Page1()
        {
			/* Using the Dependency class to resolve 
			 * the view-model automatically causes it to recieve 
			 * the services it needs via dependency injection. */
			DataContext = Dependency.Resolve<Page1ViewModel>();
	        
            InitializeComponent();
        }

	    public Page1ViewModel ViewModel => (Page1ViewModel)DataContext;
    }
}
