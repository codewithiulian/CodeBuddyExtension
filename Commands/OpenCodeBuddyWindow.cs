namespace CodeBuddy
{
	[Command(PackageIds.OpenCodeBuddyWindow)]
	internal sealed class OpenCodeBuddyWindow : BaseCommand<OpenCodeBuddyWindow>
	{
		protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
		{
			await CodeBuddyWindow.ShowAsync();
		}
	}
}
