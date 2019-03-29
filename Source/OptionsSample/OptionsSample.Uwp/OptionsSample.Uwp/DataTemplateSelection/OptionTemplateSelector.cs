using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Codon.UserOptionsModel;

namespace OptionsSample
{
	/// <summary>
	/// This class retrieves <see cref="NamedTemplate"/> objects
	/// based on the name defined by a <see cref="IUserOption"/>.
	/// </summary>
	public class OptionTemplateSelector : DataTemplateSelector
	{
		public NamedTemplateCollection Templates { get; set; }

		IDictionary<string, NamedTemplate> cache { get; set; }

		void InitTemplateCollection()
		{
			cache = Templates?.ToDictionary(x => x.Name) 
								?? new Dictionary<string, NamedTemplate>();
		}

		protected override DataTemplate SelectTemplateCore(
						object item, DependencyObject container)
		{
			if (cache == null)
			{
				InitTemplateCollection();
			}

			if (item != null)
			{
				var readerWriter = (IUserOptionReaderWriter)item;
				var template = readerWriter.UserOption.TemplateName;

				cache.TryGetValue(template, out NamedTemplate keyedTemplate);
				
				if (keyedTemplate != null)
				{
					return keyedTemplate.DataTemplate;
				}
			}

			DataTemplate result = base.SelectTemplateCore(item, container);
			return result;
		}
	}
}
