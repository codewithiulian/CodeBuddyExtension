using System.ComponentModel;
using System.Runtime.InteropServices;

namespace CodeBuddy
{
	internal partial class OptionsProvider
	{
		// Register the options with this attribute on your package class:
		// [ProvideOptionPage(typeof(OptionsProvider.GeneralOptions), "CodeBuddy", "General", 0, 0, true, SupportsProfiles = true)]
		[ComVisible(true)]
		public class GeneralOptions : BaseOptionPage<General> { }
	}

	public class General : BaseOptionModel<General>
	{
		[Category("Code Buddy")]
		[DisplayName("OpenAI API Key")]
		[Description("This can be generated at platform.openai.com/account/api-keys.")]
		public string OpenAiApiKey { get; set; }
	}
}
