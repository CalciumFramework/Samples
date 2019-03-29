using Codon;
using Codon.Services;

namespace OptionsSample
{
	public class Bootstrapper
	{
		public void Run()
		{
			Dependency.Register<AppSettings, AppSettings>(true);

			var appSettings = Dependency.Resolve<AppSettings>();
			appSettings.ConfigureUserOptions(Dependency.Resolve<IUserOptionsService>(), UserRoles.User);
		}
	}
}
