using Codon.Services;
using Codon.UserOptionsModel;
using Codon.UserOptionsModel.UserOptions;
using System.Collections.Generic;

namespace OptionsSample
{
	partial class AppSettings
	{
		public void ConfigureUserOptions(IUserOptionsService userOptionsService, UserRoles userRoles)
		{
			OptionCategory defaultCategory = new OptionCategory(OptionCategoryIds.General, () => "General");

			/* Add options to the following collection and they will be 
			 * automatically displayed on the options page. 
			 * Each UserOption object must have a unique key. 
			 * Lambda expression are used for most of the properties 
			 * to allow your app to switch languages without requiring a restart. 
			 * You can specify a template for the option by setting its TemplateFunc property.
			 * See the UserOptionBase implementations. */
			var generalOptions = new List<IUserOption>
			{
				new StringUserOption(() => "String 1", String1Key, () => string1DefaultValue),
				new BooleanUserOption(() => "Boolean 1", Boolean1Key, () => boolean1DefaultValue)
			};
			
			userOptionsService.Register(generalOptions, defaultCategory);
		}
	}

	public class OptionCategoryIds
	{
		public const string Privacy = "Privacy";
		public const string General = "General";
		public const string Appearance = "Appearance";
		public const string Advanced = "Advanced";
	}
}
