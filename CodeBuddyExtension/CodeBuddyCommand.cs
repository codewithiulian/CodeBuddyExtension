﻿using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.ComponentModel.Design;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace CodeBuddyExtension
{
	internal sealed class CodeBuddyCommand
	{
		public const int CommandId = 0x0100;

		public static readonly Guid CommandSet = new Guid("36617ba4-4e12-407d-bf77-1c48c660b238");

		private readonly AsyncPackage package;

		private CodeBuddyCommand(AsyncPackage package, OleMenuCommandService commandService)
		{
			this.package = package ?? throw new ArgumentNullException(nameof(package));
			commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

			var menuCommandID = new CommandID(CommandSet, CommandId);
			var menuItem = new MenuCommand(this.Execute, menuCommandID);
			commandService.AddCommand(menuItem);
		}

		public static CodeBuddyCommand Instance
		{
			get;
			private set;
		}

		private Microsoft.VisualStudio.Shell.IAsyncServiceProvider ServiceProvider
		{
			get
			{
				return this.package;
			}
		}

		public static async Task InitializeAsync(AsyncPackage package)
		{
			await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

			OleMenuCommandService commandService = await package.GetServiceAsync((typeof(IMenuCommandService))) as OleMenuCommandService;
			Instance = new CodeBuddyCommand(package, commandService);
		}

		private void Execute(object sender, EventArgs e)
		{
			this.package.JoinableTaskFactory.RunAsync(async delegate
			{
				ToolWindowPane window = await this.package.ShowToolWindowAsync(typeof(CodeBuddy), 0, true, this.package.DisposalToken);
				if ((null == window) || (null == window.Frame))
				{
					throw new NotSupportedException("Cannot create tool window");
				}
			});
		}
	}
}
