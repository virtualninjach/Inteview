using Inteview.Models;
using Inteview.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Inteview.Data
{
    public class ItunesRepository
    {
        public HttpClient client;
        public ItunesRepository()
        {
            client = new HttpClient()
            {
                MaxResponseContentBufferSize = 25600
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("https://itunes.apple.com/lookup");
        }

        public async Task<ViewModels.RootObject> GetItnesInfo(string id)
        {
            client.DefaultRequestHeaders.Clear();

            string url = client.BaseAddress + "?id=" + id;
            HttpResponseMessage res = await client.GetAsync(url);

            var jwt = res.Content.ReadAsStringAsync().Result;
            ViewModels.RootObject itunesViewClass = JsonConvert.DeserializeObject<ViewModels.RootObject>(jwt);

            return itunesViewClass;

        }


    }
}
