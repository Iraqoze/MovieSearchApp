using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UIApp.Model;

namespace UIApp.Services
{
    public class MovieService
    {
       
        HttpClient client;
        public MovieService()
        {
        	//initializing the httpclient instance
            client = new HttpClient();
        }
        //This async method is for retrieving the movies from the internet, it takes in a string which will be the title of the movie to search
        public async Task<List<Search>> SearchMovieAsync(string movieName)
        {
            List<Search> MovieList = new List<Search>();
            string Url = $" http://www.omdbapi.com/?s={movieName}&apikey=395d1a2c";
            var response = await client.GetAsync(Url);
            var json = response.Content.ReadAsStringAsync().Result;
            var searchResult = JsonConvert.DeserializeObject<MovieSearch>(json);
            MovieList = searchResult.search as List<Search>;
            
            return MovieList;
        }
    }
}
