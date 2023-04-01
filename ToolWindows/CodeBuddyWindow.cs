using Microsoft.VisualStudio.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CodeBuddy
{
	public class CodeBuddyWindow : BaseToolWindow<CodeBuddyWindow>
	{
		public override string GetTitle(int toolWindowId) => "Code Buddy";

		public override Type PaneType => typeof(Pane);

		public override Task<FrameworkElement> CreateAsync(int toolWindowId, CancellationToken cancellationToken)
		{
			return Task.FromResult<FrameworkElement>(new CodeBuddyWindowControl());
		}

		[Guid("b608ca19-3a41-40aa-af13-321e79a96579")]
		internal class Pane : ToolkitToolWindowPane
		{
			public Pane()
			{
				BitmapImageMoniker = KnownMonikers.JustMyCode;
			}
		}
	}
}
