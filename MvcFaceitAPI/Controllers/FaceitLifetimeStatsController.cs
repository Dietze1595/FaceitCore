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
        public string Index(string steamId = "0")
        {
            var _faceitAbstraction = new SimpleFaceitAverageStats();
            var _client = new SimpleFaceitLifetimeStats();

            var providerFaceitDetails = _faceitAbstraction.FaceitUserDetails(steamId);      // Get FaceitGUID & FaceitNickname

            if (providerFaceitDetails != null)
            {
                FacaeitLifetimeStats LifetimeStats = _client.getFaceitLifetimeStats(providerFaceitDetails.Item1);      // Get FaceitGUID & FaceitNickname
                return  "Welcome " + providerFaceitDetails.Item2 + ", Matches gewonnen " + LifetimeStats.lifetime.WonMatches + " von " + LifetimeStats.lifetime.PlayedMatches + " davon " + LifetimeStats.lifetime.WinPercentage +
                    "% gewonnen,\nHighest winning streak: " + LifetimeStats.lifetime.highesWinningstreak + " derzeitige winningstreak: " + LifetimeStats.lifetime.currentWinningstreak + " K/D von " + LifetimeStats.lifetime.KD;
                
            }
            else
            {
                return "Kein Faceitaccount gefunden";
            }
           
        }
    }
}
