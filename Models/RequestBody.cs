using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenAI_PureData.Models
{
    public class RequestBody
    {
        public string model { get; set; }
        public string prompt { get; set; }
        public float temperature { get; set; }
        public int max_tokens { get; set; }
        public int top_p { get; set; }
        public int frequency_penalty { get; set; }
        public float presence_penalty { get; set; }

        public RequestBody(string promptText)
        {
            model = "text-davinci-003";
            prompt = promptText;
            temperature = 0.9f;
            max_tokens = 150;
            top_p = 1;
            frequency_penalty = 0;
            presence_penalty = 0.6f;
        }
    }
}