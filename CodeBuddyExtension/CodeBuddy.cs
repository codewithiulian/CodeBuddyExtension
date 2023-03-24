using Microsoft.VisualStudio.Imaging;
using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;

namespace CodeBuddyExtension
{
	[Guid("d50b2fff-ef43-42a2-870b-6e104616bc33")]
	public class CodeBuddy : ToolWindowPane
	{
		public CodeBuddy() : base(null)
		{
			Caption = "CodeBuddy";
			BitmapImageMoniker = KnownMonikers.JustMyCode;

			Content = new CodeBuddyControl();
		}
	}
}
