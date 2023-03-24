using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddyExtension.Data
{
	public class RequestModel
	{
		public string model { get; set; }
		public string prompt { get; set; }
		public double temperature { get; set; }
		public int max_tokens { get; set; }
		public double frequency_penalty { get; set; }

		public RequestModel(string model, string prompt, double temperature, int max_tokens, double frequency_penalty)
		{
			this.model = model;
			this.prompt = prompt;
			this.temperature = temperature;
			this.max_tokens = max_tokens;
			this.frequency_penalty = frequency_penalty;
		}
	}
}
