using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class List : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IRestaurantData _restaurantData;
        private readonly ILogger<List> _logger;

        // Output models
        //public string Message { get; set; }
        [TempData]
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public List(IConfiguration config,
                    IRestaurantData restaurantData,
                    ILogger<List> logger)
        {
            _config = config;
            _restaurantData = restaurantData;
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogError("Executing ListModel");
            Message = Message ?? _config["Message"];
            Restaurants = _restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}