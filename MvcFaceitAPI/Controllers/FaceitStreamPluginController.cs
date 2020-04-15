using Faceitplayermodel.config;
using Microsoft.AspNetCore.Mvc;
using MvcFaceitAPI.Abstraction;
using MvcFaceitAPI.Client;
using MvcFaceitAPI.config;
using MvcFaceitAPI.Modelle;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcFaceitAPI.Controllers
{
    public class FaceitStreamPluginController : Controller
    {
        // 
        // GET: /FaceitStreamPlugin?steamId=<steamId>

        // GET: /<controller>/
        public IActionResult Index(string steamId = "76561198257065483")
        {
            var modelFaceitmatch = new Faceitmatch();
            var _faceitAbstraction = new SimpleFaceitAverageStats();
            var _client = new SimpleFaceitLiveMatch();
            var _Lifetime = new SimpleFaceitLifetimeStats();


            var providerFaceitDetails = _faceitAbstraction.FaceitUserDetails(steamId);      // Get FaceitGUID & FaceitNickname
            if (providerFaceitDetails != null)
            {
                modelFaceitmatch = _client.getFaceitMatchDetails(providerFaceitDetails.Item1, providerFaceitDetails.Item2);
                FacaeitLifetimeStats LifetimeStats = _Lifetime.getFaceitLifetimeStats(providerFaceitDetails.Item1, providerFaceitDetails.Item2);
                FaceitUserStats providerFaceitStats = _faceitAbstraction.FaceitAvgElo(providerFaceitDetails.Item1);

                if (modelFaceitmatch != null)
                {
                    ViewData["enemyTeamElo"] = modelFaceitmatch.enemyTeamElo;
                    ViewData["enemyTeamName"] = modelFaceitmatch.enemyTeamName;
                    ViewData["enemyTeamWinElo"] = modelFaceitmatch.enemyTeamWinElo;
                    ViewData["ownTeamElo"] = modelFaceitmatch.ownTeamElo;
                    ViewData["ownTeamName"] = modelFaceitmatch.ownTeamName;
                    ViewData["ownTeamWinElo"] = modelFaceitmatch.ownTeamWinElo;
                    ViewData["Live"] = 1;
                }
                else { 
                    ViewData["Live"] = 0; 
                }

                ViewData["Elo"] = LifetimeStats.lifetime.Elo;
                ViewData["WonMatches"] = LifetimeStats.lifetime.WonMatches;
                ViewData["PlayedMatches"] = LifetimeStats.lifetime.PlayedMatches;
                ViewData["WinPercentage"] = LifetimeStats.lifetime.WinPercentage;
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
