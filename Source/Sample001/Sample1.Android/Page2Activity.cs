using Android.App;
using Android.OS;
using Android.Views;
using Codon;
using Codon.UI.Data;

namespace Sample1
{
	[Activity(Label = "Page 2")]
	public class Page2Activity : Activity
	{
		readonly XmlBindingApplicator applicator
					= new XmlBindingApplicator();
		int layoutId = Resource.Layout.Page2;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			/* For documentation about what's going on here, 
			 * please see Page1Activity. */

			var bootstrapper = new Bootstrapper();
			bootstrapper.Run();

			Dependency.Register<Activity>(this);

			var view = View.Inflate(this, layoutId, null);
			SetContentView(view);

			var viewModel = Dependency.Resolve<Page2ViewModel>();
			applicator.ApplyBindings(view, viewModel, layoutId);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();

			/* Disconnect the view from its view-model. */
			applicator.RemoveBindings();
		}
	}
}