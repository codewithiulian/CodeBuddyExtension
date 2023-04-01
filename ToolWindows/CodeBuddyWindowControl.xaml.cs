using CodeBuddy.Models;
using CodeBuddy.Services;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CodeBuddy
{
	public partial class CodeBuddyWindowControl : UserControl
	{
		private General options;
		private ChatService chatService;
		private WindowVM windowModel;

		public CodeBuddyWindowControl()
		{
			InitializeComponent();
		}

		protected override async void OnInitialized(EventArgs e)
		{
			base.OnInitialized(e);

			options = await General.GetLiveInstanceAsync();
			chatService = new ChatService(options);
			windowModel = new WindowVM();
		}

		private async void button1_Click(object sender, RoutedEventArgs e)
		{
			Error.Text = ""; // clear the error
			Error.Visibility = Visibility.Hidden;

			windowModel = await chatService.SendGptRequestAsync(promptText.Text);

			if (windowModel.Errors.Any())
			{
				foreach (var error in windowModel.Errors)
				{
					Error.Text += error + "  ";
				}
				Error.Visibility = Visibility.Visible;
			}
		}
	}
}
