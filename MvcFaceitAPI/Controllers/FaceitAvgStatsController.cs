using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcFaceitAPI.Abstraction;
using MvcFaceitAPI.config;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcFaceitAPI.Controllers
{
    public class FaceitAvgStatsController : Controller
    {
        // GET: /FaceitAvgStats/
        public IActionResult Index(string steamId)
        {
            var _faceitAbstraction = new SimpleFaceitAverageStats();

            var providerFaceitDetails = _faceitAbstraction.FaceitUserDetails(steamId);      // Get FaceitGUID & FaceitNickname
            if (providerFaceitDetails != null)
            {
                FaceitUserStats providerFaceitStats = _faceitAbstraction.FaceitAvgElo(providerFaceitDetails.Item1);      // Get FaceitGUID & FaceitNickname
                ViewData["Name"] = providerFaceitDetails.Item2;
                ViewData["Kills"] = providerFaceitStats.avgKills;
                ViewData["HS"] = providerFaceitStats.avgHs;
                ViewData["KD"] = providerFaceitStats.avgKd;
                ViewData["KR"] = providerFaceitStats.avgKr;

                return View();
            }
            else
            {
                ViewData["Name"] = steamId;
                return View("noFaceit");
            }
            
        }
    }
}
