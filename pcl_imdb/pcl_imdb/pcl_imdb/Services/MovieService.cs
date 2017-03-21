using pcl_imdb.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace pcl_imdb.Services
{
    public class MovieService
    {
        private readonly HttpClient httpClient;

        public const string BaseURL = "http://www.omdbapi.com?apikey={0}&s={1}&r=json";

        public const string ApiKey = "d4ddde0d";

        public MovieService()
        {
            httpClient = new HttpClient();
        }

        //public async Task<IEnumerable<Movie>> SearchMovieAsync(string filter)
        //public string SearchMovieAsync(string filter)
        //{
        //    //Task<string> response = httpClient.GetStringAsync(string.Format(BaseURL, ApiKey, filter));
        //    //response.ContinueWith()
        //}

        public string SearchMovie(string filter)
        {
            return httpClient.GetStringAsync(string.Format(BaseURL, ApiKey, filter)).Result;
        }

        public async Task<string> SearchMoviesAsync(string filter)
        {
            var result = await httpClient.GetStringAsync(string.Format(BaseURL, ApiKey, filter));

            string movies = string.Empty;
            JavaScriptSerializer

            List <Movie> = oJS.Deserialize<ImdbEntity>(json);
            if (obj.Response == "True")
            {
                txtActor.Text = obj.Actors;
                txtDirector.Text = obj.Director;
                txtYear.Text = obj.Year;

            }

            return result;
        }

        /*public string SearchMovie(string filter)
        {
            string result = string.Empty;
            Task<string> getStringTask = httpClient.GetStringAsync(string.Format(BaseURL, ApiKey, filter));
            getStringTask.ContinueWith(
                task =>
                {
                    result = task.Result;
                },
                TaskScheduler.FromCurrentSynchronizationContext()
            );

            return result;*/
        
    }
}
