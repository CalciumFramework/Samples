using Codon;
using Codon.Services;
using Codon.UserOptionsModel;

namespace OptionsSample.Views
{
	public class OptionsViewModel : CustomViewModel
	{
		public IUserOptionGroupings Groupings => 
			Dependency.Resolve<IUserOptionsService>().UserOptionGroupings;
	}
}
