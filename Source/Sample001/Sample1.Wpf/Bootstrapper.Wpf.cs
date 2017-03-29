using System;

using Codon;
using Codon.Navigation;
using Codon.Services;
using NavigationService = Codon.Navigation.NavigationService;

namespace Sample1
{
	/// <summary>
	/// This class is used to set up the navigation 
	/// routes within the app.
	/// </summary>
	class Bootstrapper
	{
		/// <summary>
		/// Codon does not require bootstrapping.
		/// However, if your app makes use of the 
		/// <see cref="Codon.Services.INavigationService"/>,
		/// as this one does, then you need to register 
		/// the navigation routes with the <see cref="IRoutingService"/>.
		/// </summary>
		public void Run()
		{
			/* This method should be called when your app starts. 
			 * The IoC container knows about several default types, 
			 * that's why no type registrations are necessary. */
			var routingService = Dependency.Resolve<IRoutingService>();

			/* When the navigation service receives a request for "/Page2", 
			 * it uses the routing service to look up the path 
			 * and calls Navigate<Page2>(). */
			routingService.RegisterPath(Routes.Page2, Navigate<Page2>);
		}

		void Navigate<TPage>()
		{
			Navigate(typeof(TPage));
		}

		void Navigate(Type pageType)
		{
			var navigationService = (NavigationService)Dependency.Resolve<INavigationService>();
			var page = Dependency.ResolveWithType(pageType);

			/* The platform specific implementation of INavigationService 
			 * has a Navigate(object) method that we can use navigate. 
			 * It automatically resolves the root Frame or NavigationPage. */
			navigationService.Navigate(page);
		}
	}
}