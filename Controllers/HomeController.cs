using Microsoft.AspNetCore.Mvc;
using MyFavoritePlaces.Models;
using System.Diagnostics;
using System.Text.Json;

namespace MyFavoritePlaces.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string pathData = "Data/collection.json";

            using var jsonFile = System.IO.File.OpenRead(pathData);

            var items = JsonSerializer.Deserialize<List<PlaceCollectionItem>>(jsonFile);

            return View(items);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}