using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
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
		/// <summary>
		/// This method should be called when your app starts.
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
			/* Navigation in UWP is achieved using the root Frame. */
			var frame = (Frame)Window.Current.Content;
			frame.Navigate(pageType);
		}
	}
}