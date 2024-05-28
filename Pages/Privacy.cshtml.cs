using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MovieProject.Models;
using Newtonsoft.Json;

namespace MovieProject.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public PrivacyModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public IList<Details> details { get; set; }
        public async Task  OnGet()
        {
            
        }

    }

}
