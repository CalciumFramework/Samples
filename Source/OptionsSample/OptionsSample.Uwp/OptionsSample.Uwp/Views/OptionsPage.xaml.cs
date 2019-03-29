using Windows.UI.Xaml.Controls;
using Codon;

namespace OptionsSample.Views
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class OptionsPage : Page
	{
		public OptionsPage()
		{
			this.InitializeComponent();
			DataContext = Dependency.Resolve<OptionsViewModel, OptionsViewModel>(true);
		}

		public OptionsViewModel ViewModel
		{
			get => DataContext as OptionsViewModel;
			set => DataContext = value;
		}
	}
}
