using System.Windows;

namespace Sample1
{
	public partial class App : Application
	{
		void App_OnStartup(object sender, StartupEventArgs e)
		{
			/* The bootstrapper initializes the routes 
			 * for the navigation service. */
			var bootstrapper = new Bootstrapper();
			bootstrapper.Run();
		}
	}
}
