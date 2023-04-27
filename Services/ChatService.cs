using CodeBuddy.Models;
using OpenAI_API;
using OpenAI_API.Completions;
using OpenAI_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddy.Services
{
	internal class ChatService
	{
        private readonly General options;
        private OpenAIAPI api;

        internal ChatService(General options)
        {
            this.options = options;

			// Initialize OpenAI if we've got an API key stored
			if (!string.IsNullOrEmpty(options.OpenAiApiKey))
			{
				api = new(options.OpenAiApiKey);
			}
		}

        internal async Task<WindowVM> SendGptRequestAsync(string prompt)
        {
            var toReturn = new WindowVM();

            if (string.IsNullOrEmpty(options.OpenAiApiKey))
            {
                toReturn.Errors.Add("Your OpenAI API key is missing. To add it go to Tools > Options > Code Buddy.");
				return toReturn;
            }

			if (string.IsNullOrEmpty(prompt))
			{
                toReturn.Errors.Add("The prompt is empty, add one such as: 'What is javascript?'");
                return toReturn;
			}

            // Initialize OpenAI and chat service if they're not already
			api ??= new(options.OpenAiApiKey);

			try
			{
				var result = await api.Completions.CreateCompletionAsync(new CompletionRequest(prompt, model: Model.DavinciText, max_tokens: 2048));
				toReturn.Response = result.ToString(); // Gets the first Completion if not null

				// Remove the initial new lines if present
				if (toReturn.Response.StartsWith("\n\n"))
				{
					toReturn.Response = toReturn.Response.Remove(0, 2);
				}
			}
			catch (AuthenticationException ex)
			{
				// Nullify the api and chat services so they can be reinitialized with a valid key.
				api = null;
				toReturn.Errors.Add("Your OpenAI API Key is invalid. Either generate a new one or ensure it is correct. This can be generated at platform.openai.com/account/api-keys. Then go to Tools > Options > Code Buddy and paste it.");
			}
			catch (HttpRequestException ex)
			{
				toReturn.Errors.Add("There was an error processing your request. Make sure you are connected to the interet.");
			}
			catch (Exception e)
			{
				toReturn.Errors.Add("There was an error processing your request. Reload the environment and try again.");
			}

			return toReturn;
		}
    }
}
