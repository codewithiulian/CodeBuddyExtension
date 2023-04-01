using CodeBuddy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddy.Services
{
	internal class ChatService
	{
        private readonly General options;

        internal ChatService(General options)
        {
            this.options = options;
        }

        internal async Task<WindowVM> SendGptRequestAsync(string prompt)
        {
            var toReturn = new WindowVM();

            if (string.IsNullOrEmpty(options.OpenAiApiKey))
            {
                toReturn.Errors.Add("Your OpenAI API key is missing. To add it go to Tools > Options > Code Buddy.");
            }

			if (string.IsNullOrEmpty(prompt))
			{
                toReturn.Errors.Add("The prompt is empty, add one such as: 'What is javascript?'");
                return toReturn;
			}



			return toReturn;
		}
    }
}
