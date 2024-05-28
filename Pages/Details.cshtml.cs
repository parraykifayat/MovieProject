using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieProject.Models;
using Newtonsoft.Json;
using System.Collections;


namespace MovieProject.Pages
{
    
    public class DetailsModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;


        public DetailsModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
       
        public Details MoviesDetail { get; set; }
        public async Task OnGet(string id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://imdb-top-100-movies.p.rapidapi.com/"+id);
            request.Headers.Add("X-RapidAPI-Key", "a2c8cba59emshe0fdc1ac7d842f6p1764b0jsn461f47e5f2ff");
            request.Headers.Add("X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com");
            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine("API Response: " + content);
                MoviesDetail = JsonConvert.DeserializeObject<Details>(content);
                //+Movie = JsonConvert.DeserializeObject<MovieDetails>(content);

                /*if (!string.IsNullOrEmpty(title))
                {
                    Movies = Movies.Where(m => m.title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
                }*/

                /* TotalPages = (int)System.Math.Ceiling(Movies.Count / (double)PageSize);
                 Movies = Movies.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();*/
            }
        }
        
       

    }
}
