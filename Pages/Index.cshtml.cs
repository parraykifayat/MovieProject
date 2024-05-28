using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using MovieProject.Models;
using Microsoft.AspNetCore.Mvc;


namespace MovieProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
       
        public IndexModel(IHttpClientFactory clientFactory)
        {
            _clientFactory= clientFactory;
        }

        public IList<Movie>Movies { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; } = 12;
        public int TotalPages { get; set; }
        public async Task OnGet( int currentPage=1 ,string title="")
        {
            CurrentPage = currentPage;
            var request = new HttpRequestMessage(HttpMethod.Get, "https://imdb-top-100-movies.p.rapidapi.com/");
            request.Headers.Add("X-RapidAPI-Key", "a2c8cba59emshe0fdc1ac7d842f6p1764b0jsn461f47e5f2ff");
            request.Headers.Add("X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com");
            var client= _clientFactory.CreateClient();


            var response= await client.SendAsync(request);

            if(response.IsSuccessStatusCode)
            {
                var content= await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine("API Response: " + content);
                Movies = JsonConvert.DeserializeObject<IList<Movie>>(content);

                if (!string.IsNullOrEmpty(title))
                {
                    Movies=Movies.Where(m=>m.title.Contains(title,StringComparison.OrdinalIgnoreCase)).ToList();
                }

                TotalPages = (int)System.Math.Ceiling(Movies.Count / (double)PageSize);
                Movies = Movies.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
            }
            
        }
        
    }
}
