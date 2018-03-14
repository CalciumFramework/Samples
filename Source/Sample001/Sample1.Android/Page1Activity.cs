using Android.App;
using Android.OS;
using Android.Views;

using Codon;
using Codon.UI.Data;

namespace Sample1
{
	[Activity(Label = "Page 1", 
		MainLauncher = true, Icon = "@drawable/icon")]
	public class Page1Activity : Activity
	{
		readonly XmlBindingApplicator applicator 
					= new XmlBindingApplicator();
		int layoutId = Resource.Layout.Page1;
		
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			/* Register the routes for the app. */
			var bootstrapper = new Bootstrapper();
			bootstrapper.Run();

			/* It's important to always register the current activity 
			 * as there isn't a global way to retrieve the current activity. 
			 * Services, such as the DialogService, rely on being able 
			 * to resolve the current activity. */
			Dependency.Register<Activity>(this);
			
			/* We use the View.Inflate method to create the view immediately 
			 * so that we can bind it to a view-model. */
			var view = View.Inflate(this, layoutId, null);
			SetContentView(view);

			/* Using the Dependency class to resolve 
			 * the view-model automatically causes it to recieve 
			 * the services it needs via dependency injection. */
			var viewModel = Dependency.Resolve<Page1ViewModel>();

			/* Use Codon's data-binding system to bind the view 
			 * to the view-model. */
			applicator.ApplyBindings(view, viewModel, layoutId);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();

			/* Disconnect the view from its view-model. */
			applicator.RemoveBindings();
		}

		protected override void OnResume()
		{
			base.OnResume();

			Dependency.Register<Activity>(this);
		}
	}
}

