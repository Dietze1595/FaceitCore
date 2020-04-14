using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcFaceitAPI.Client;
using MvcFaceitAPI.Models;

namespace MvcFaceitAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(SubscribeModel model)
        {
            return View();
        }

        public IActionResult Subscribe(SubscribeModel model)
        {
            if (ModelState.IsValid)
            {
                var _client = new getSteamId();
                ViewData["steamid"] = _client.SteamId(model.SteamId);
                return View("Services");
            }
            else
            {
                return View("Error");
            }
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
