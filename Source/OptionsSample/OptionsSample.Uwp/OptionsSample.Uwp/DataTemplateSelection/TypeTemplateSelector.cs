using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace OptionsSample
{
	public class TypeTemplate
	{
		public Type DataType { get; set; }

		public DataTemplate DataTemplate { get; set; }
	}

	public class TypeTemplateCollection : Collection<TypeTemplate>
	{
	}

	/// <summary>
	/// A template selector that selects templates based on the data type
	/// of the object that is displayed by the template.
	/// </summary>
	public class TypeTemplateSelector : DataTemplateSelector
	{
		public TypeTemplateCollection Templates { get; set; }

		Dictionary<Type, TypeTemplate> templateCache { get; set; }

		void InitTemplateCollection()
		{
			templateCache = Templates?.ToDictionary(x => x.DataType) 
								?? new Dictionary<Type, TypeTemplate>();
		}

		protected override DataTemplate SelectTemplateCore(
			object item, DependencyObject container)
		{
			if (templateCache == null)
			{
				InitTemplateCollection();
			}

			if (item != null)
			{
				var dataType = item.GetType();
				templateCache.TryGetValue(dataType, out TypeTemplate match);

				if (match != null)
				{
					return match.DataTemplate;
				}
			}

			DataTemplate result = base.SelectTemplateCore(item, container);
			return result;
		}
	}
}