using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;

namespace CodeBuddyExtension
{
	public partial class CodeBuddyControl : UserControl
	{
		public CodeBuddyControl()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, RoutedEventArgs e)
		{
			ThreadHelper.ThrowIfNotOnUIThread();
			var dte = ServiceProvider.GlobalProvider.GetService(typeof(DTE)) as DTE2;

			MessageBox.Show(dte.Version, "CodeBuddy");
		}
	}
}