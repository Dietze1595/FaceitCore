using Faceitplayermodel.config;
using Microsoft.AspNetCore.Mvc;
using MvcFaceitAPI.Abstraction;
using MvcFaceitAPI.Client;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcFaceitAPI.Controllers
{
    public class FaceitLiveMatchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index(string steamId = "76561198257065483")
        {
            var modelFaceitmatch = new Faceitmatch();
            var _faceitAbstraction = new SimpleFaceitAverageStats();
            var _client = new SimpleFaceitLiveMatch();


            var providerFaceitDetails = _faceitAbstraction.FaceitUserDetails(steamId);      // Get FaceitGUID & FaceitNickname
            if (providerFaceitDetails != null)
            {
                modelFaceitmatch = _client.getFaceitMatchDetails(providerFaceitDetails.Item1, providerFaceitDetails.Item2);
                if (modelFaceitmatch != null)
                {
                    ViewData["name"] = providerFaceitDetails.Item2;
                    ViewData["enemyTeamElo"] = modelFaceitmatch.enemyTeamElo;
                    ViewData["enemyTeamName"] = modelFaceitmatch.enemyTeamName;
                    ViewData["enemyTeamWinElo"] = modelFaceitmatch.enemyTeamWinElo;
                    ViewData["ownTeamElo"] = modelFaceitmatch.ownTeamElo;
                    ViewData["ownTeamName"] = modelFaceitmatch.ownTeamName;
                    ViewData["ownTeamWinElo"] = modelFaceitmatch.ownTeamWinElo;
                    return View();
                }
                else
                {
                    ViewData["name"] = providerFaceitDetails.Item2;
                    return View("noLive");
                }
            }
            else
            {
                ViewData["Name"] = steamId;
                return View("noFaceit");
            }
            
        }
    }
}
