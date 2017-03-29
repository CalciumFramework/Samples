using System;
using Android.App;
using Android.Content;

using Codon;
using Codon.Navigation;

namespace Sample1
{
	/// <summary>
	/// Codon does not require bootstrapping.
	/// However, if your app makes use of the 
	/// <see cref="Codon.Services.INavigationService"/>,
	/// as this one does, then you need to register 
	/// the navigation routes with the <see cref="IRoutingService"/>.
	/// </summary>
	class Bootstrapper
	{
		static bool ran;

		/// <summary>
		/// This method should be called when your app starts.
		/// </summary>
		public void Run()
		{
			if (ran)
			{
				return;
			}

			ran = true;

			/* This method should be called when your app starts. 
			 * The IoC container knows about several default types, 
			 * that's why no type registrations are necessary. */
			var routingService = Dependency.Resolve<IRoutingService>();

			/* When the navigation service receives a request for "/Page2", 
			 * it uses the routing service to look up the path 
			 * and calls LaunchActivity<Page2Activity>(). */
			routingService.RegisterPath(Routes.Page2, () => LaunchActivity<Page2Activity>(1));
		}

		void LaunchActivity<TActivity>(int requestCode)
		{
			LaunchActivity(typeof(TActivity), requestCode);
		}

		void LaunchActivity(Type activityType, int requestCode)
		{
			var activity = Dependency.Resolve<Activity>();
			
			/* Launch an intent for the activity. */
			Intent intent = new Intent(activity, activityType);
			activity.StartActivityForResult(intent, requestCode);
		}
	}
}