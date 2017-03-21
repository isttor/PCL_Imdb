using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    public class MovieResponse
    {
        public Movie[] Search { get; set; }
        public string totalResults { get; set; }
        public string Response { get; set; }
    }

    public class Movie
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
    }

    class Program
    {
        private readonly HttpClient httpClient;
        public const string BaseURL = "http://www.omdbapi.com?apikey={0}&s={1}&r=json";
        public const string ApiKey = "d4ddde0d";

        static void Main(string[] args)
        {
            // Sync();
            var l = GetAsync().Result;
            Console.WriteLine(l);

            var res = JsonConvert.DeserializeObject<MovieResponse>(l);

            int i = 0;
        }


        private static async Task<string> GetAsync()
        {
            var httpClient = new HttpClient();

            //return await httpClient.GetStringAsync(string.Format(BaseURL, ApiKey, "Limitless"));
            var response = await httpClient.GetAsync(string.Format(BaseURL, ApiKey, "Limitless"));

            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                return resp;
            }
            return "";
        }
    }
}
