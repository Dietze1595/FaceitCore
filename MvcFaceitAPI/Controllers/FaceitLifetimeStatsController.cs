using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcFaceitAPI.Abstraction;
using MvcFaceitAPI.Client;
using MvcFaceitAPI.Modelle;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcFaceitAPI.Controllers
{
    public class FaceitLifetimeStatsController : Controller
    {
        // GET: /FaceitLifetimeStats/
        public IActionResult Index(string steamId = "76561198257065483")
        {
            var _faceitAbstraction = new SimpleFaceitAverageStats();
            var _client = new SimpleFaceitLifetimeStats();

            var providerFaceitDetails = _faceitAbstraction.FaceitUserDetails(steamId);      // Get FaceitGUID & FaceitNickname

            if (providerFaceitDetails != null)
            {
                FacaeitLifetimeStats LifetimeStats = _client.getFaceitLifetimeStats(providerFaceitDetails.Item1);      // Get FaceitGUID & FaceitNickname
                ViewData["Name"] = providerFaceitDetails.Item2;
                ViewData["WonMatches"] = LifetimeStats.lifetime.WonMatches;
                ViewData["PlayedMatches"] = LifetimeStats.lifetime.PlayedMatches;
                ViewData["WinPercentage"] = LifetimeStats.lifetime.WinPercentage;
                ViewData["highesWinningstreak"] = LifetimeStats.lifetime.highesWinningstreak;
                ViewData["currentWinningstreak"] = LifetimeStats.lifetime.currentWinningstreak;
                ViewData["KD"] = LifetimeStats.lifetime.KD;
                ViewData["Elo"] = "Kommt noch";

                return View();
            }
            else
            {
                return View();
            }
           
        }
    }
}
