using System.Collections.ObjectModel;
using Windows.UI.Xaml;

namespace OptionsSample
{
	/// <summary>
	/// This class is used in XAML to define
	/// a named <see cref="DataTemplate"/>.
	/// </summary>
	public class NamedTemplate
	{
		public string Name { get; set; }

		public DataTemplate DataTemplate { get; set; }
	}

	/// <summary>
	/// A collection of <see cref="NamedTemplate"/> objects
	/// that is defined in XAML.
	/// </summary>
	public class NamedTemplateCollection : Collection<NamedTemplate>
	{
	}
}