using System;

namespace OptionsSample
{
	[Flags]
	public enum UserRoles
	{
		None = 0,
		Administrator = 1,
		User = 2,
	}
}