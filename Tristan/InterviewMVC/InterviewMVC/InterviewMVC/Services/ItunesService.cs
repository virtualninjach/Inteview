using InterviewMVC.Models;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace InterviewMVC.Services
{
    public class ItunesService
    {
        private readonly string _api = "https://itunes.apple.com/lookup?id=";

        public static HttpClient HttpClient { get; set; }

        static ItunesService()
        {
            HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<RootObject> GetResults(int? id)
        {
            var url = _api + id;
            using (HttpResponseMessage response = await HttpClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    // (Tristan): Deserialize JSON into the RootObject we created. Using Newtonsoft.Json to aid.
                    string body = await response.Content.ReadAsStringAsync();
                    RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(body);
                    return rootObject;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
