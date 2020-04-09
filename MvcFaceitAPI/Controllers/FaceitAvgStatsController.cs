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
        public string Index(string steamid = "76561198257065483")
        {
            var _faceitAbstraction = new SimpleFaceitAverageStats();

            var providerFaceitDetails = _faceitAbstraction.FaceitUserDetails(steamid);      // Get FaceitGUID & FaceitNickname
            if (providerFaceitDetails != null)
            {
                FaceitUserStats providerFaceitStats = _faceitAbstraction.FaceitAvgElo(providerFaceitDetails.Item1);      // Get FaceitGUID & FaceitNickname
                return "Welcome " + providerFaceitDetails.Item2 + ", your AVG Kills:  " + providerFaceitStats.avgKills + " AVG K/D:  " + providerFaceitStats.avgKd + " AVG HS%:  " + providerFaceitStats.avgHs + " AVG K/R:  " + providerFaceitStats.avgKr;
                
            }
            else
            {
                return "Kein Faceitaccount gefunden";
            }
            
        }
    }
}
