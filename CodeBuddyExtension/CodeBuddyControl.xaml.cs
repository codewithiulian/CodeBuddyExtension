using CodeBuddyExtension.Data;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
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

		private async void button1_Click(object sender, RoutedEventArgs e)
		{
			//ThreadHelper.ThrowIfNotOnUIThread();
			//var dte = ServiceProvider.GlobalProvider.GetService(typeof(DTE)) as DTE2;

			try
			{
				using (HttpClient client = new HttpClient())
				{

					HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/completions");
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey.Password);

					RequestModel requestModel = new RequestModel(
						model: "text-davinci-003",
						prompt: promptText.Text,
						max_tokens: 2048, // ~ 1500 words
						temperature: 0, // 0: exact and repetitive. 1: creative and random
						frequency_penalty: 0.2 // -2 to 2. The smaller the number, the less likely to repeat lines
					);

					var requestModelJson = JsonConvert.SerializeObject(requestModel);
					request.Content = new StringContent(requestModelJson, Encoding.UTF8, "application/json");

					var result = await client.SendAsync(request);

					if (result.IsSuccessStatusCode)
					{
						var responseString = await result.Content.ReadAsStringAsync();
						var response = JsonConvert.DeserializeObject<ResponseModel>(responseString);
						var responseText = response.choices[0].text;

						promptText.Text += responseText;
					}
				}
			}
			catch (System.Exception)
			{

				throw;
			}

			//MessageBox.Show(promptText.Text, "CodeBuddy");
		}
	}
}