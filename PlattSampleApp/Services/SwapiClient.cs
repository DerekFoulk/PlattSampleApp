using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PlattSampleApp.Services
{
    public class SwapiClient
    {
        public SwapiClient()
        {
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri("https://swapi.co/api/")
            };

            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpClient HttpClient { get; set; }
    }
}
