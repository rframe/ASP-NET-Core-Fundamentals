using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace OdeToFood.Pages.Restaurants
{
    public class List : PageModel
    {
        private readonly IConfiguration _config;
        public string Message { get; set; }

        public List(IConfiguration config)
        {
            _config = config;
        }
        public void OnGet()
        {
            Message = _config["Message"];
        }
    }
}