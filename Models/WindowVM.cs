using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddy.Models
{
	internal class WindowVM
	{
        public string Prompt { get; set; }
        public string Response { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
