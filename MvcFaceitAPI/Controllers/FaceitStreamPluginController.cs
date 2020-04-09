using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcFaceitAPI.Controllers
{
    public class FaceitStreamPluginController : Controller
    {
        // 
        // GET: /FaceitStreamPlugin?steamId=<steamId>

        public IActionResult Index(string steamId = "76561198257065483")
        {
            ViewData["Live"] = 1;
            ViewData["Elo"] = 1450;
            ViewData["Matches"] = "350/450";
            ViewData["WinPercentage"] = "89%";
            ViewData["Kills"] = 22;
            ViewData["HSPercentage"] = "60%";
            ViewData["K/D"] = 0.95;
            ViewData["K/R"] = 0.89;

            return View();
        }
    }
}
