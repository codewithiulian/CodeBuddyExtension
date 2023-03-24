using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using Task = System.Threading.Tasks.Task;

namespace CodeBuddyExtension
{
	[PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
	[Guid("ccde062b-8797-4fdb-a583-e5c4b30d781e")]
	[ProvideMenuResource("Menus.ctmenu", 1)]
	[ProvideToolWindow(typeof(CodeBuddy), Orientation = ToolWindowOrientation.Right, Style = VsDockStyle.Tabbed)]
	public sealed class CodeBuddyExtensionPackage : AsyncPackage
	{
		protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
		{
			await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
		    await CodeBuddyCommand.InitializeAsync(this);
		}
	}
}
