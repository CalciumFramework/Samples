using System.Threading.Tasks;
using Codon.DialogModel;
using Microsoft.Toolkit.Uwp.UI.Controls;

namespace CustomDialogServiceExample.Services
{
	public class CustomDialogService : DialogService
	{
		public InAppNotification InAppNotification { get; set; }
		public uint ToastHideMS { get; set; } = 3000;

		public override Task<object> ShowToastAsync(ToastParameters toastParameters)
		{
			if (InAppNotification != null)
			{
				int hiddenMS = 0;
				if (toastParameters.MillisecondsUntilHidden.HasValue)
				{
					hiddenMS = toastParameters.MillisecondsUntilHidden.Value;
				}

				InAppNotification.Show(toastParameters.Caption?.ToString(),
					hiddenMS > 0 ? hiddenMS : (int)ToastHideMS);

				return Task.FromResult(new object());
			}

			return base.ShowToastAsync(toastParameters);
		}
	}
}
