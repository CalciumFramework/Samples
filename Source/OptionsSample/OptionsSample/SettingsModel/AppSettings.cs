using System;
using Codon.Services;

namespace OptionsSample
{
	/// <summary>
	/// This class allows you to retrieve and store settings using strongly typed properties.
	/// </summary>
	public partial class AppSettings
	{
		readonly ISettingsService settingsService;

		internal AppSettings(ISettingsService settingsService)
		{
			this.settingsService = settingsService 
				?? throw new ArgumentNullException(nameof(settingsService));
		}

		public const string String1Key = "String1";
		static readonly string string1DefaultValue = string.Empty;

		public string String1
		{
			get => settingsService.GetSetting(String1Key, string1DefaultValue);
			private set => settingsService.SetSetting(String1Key, value);
		}

		public const string Boolean1Key = "Boolean1";
		static bool boolean1DefaultValue = false;

		public bool Boolean1
		{
			get => settingsService.GetSetting(Boolean1Key, boolean1DefaultValue);
			private set => settingsService.SetSetting(Boolean1Key, value);
		}
	}
}
