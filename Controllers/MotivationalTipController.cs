using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OpenAI_PureData.Controllers
{
    public class MotivationalTipController : ApiController
    {
        public Task<string> Post([FromBody] Models.ApiRequest request)
        {
            if(request == null)
            {
                return Task.FromResult("Invalid request.");
            }
            string courselist = "";
            
            if(request.getCourses()[0] != null)
            {                
                foreach (Models.Courses course in request.getCourses())
                {
                    courselist += course.getLetter() + " in " + course.getName() + ". ";
                }
            }
            
            string prompt = "Create motivational tips for students with the following current information. " +
                "The student attendance rate is "+request.getAttendance()+"% The grade level is " + request.getGradeLevel() + ". " + courselist+
                "Include emojis.";         


            return  SendCompletionRequest(prompt);
        }

        public async Task<string> SendCompletionRequest(string promptText)
        {
            // Create an HttpClient object
            using (HttpClient client = new HttpClient())
            {
                // Set the URL
                string url = "https://api.openai.com/v1/completions";

                // Create the request content
                Models.RequestBody requestData = new Models.RequestBody(promptText);
                
                string json = JsonConvert.SerializeObject(requestData);
                //string json = JsonSerializer.Serialize(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Add the authorization key to the HTTP headers
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "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");

                // Send the POST request and get the response
                HttpResponseMessage response = await client.PostAsync(url, content);

                // Read the response as a string
                string responseString = await response.Content.ReadAsStringAsync();

                return responseString;
                
            }
        }
    }
}
