using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
            ViewData["steamid"] = model.SteamId;
            return View();
        }

        [HttpPost]
        public ActionResult Subscribe(SubscribeModel model)
        {
            if (ModelState.IsValid)
            {
                ViewData["steamid"] = model.SteamId;
                return View("PostHome");
            } else
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
