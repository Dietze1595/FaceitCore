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
    public class FaceitLastMatchController : Controller
    {
        // GET: /FaceitLastMatch?steamId=<steamId>
        public IActionResult Index(string steamId)
        {
            var _faceitAbstraction = new SimpleFaceitAverageStats();
            var _client = new SimpleLastMatch();


            var providerFaceitDetails = _faceitAbstraction.FaceitUserDetails(steamId);      // Get FaceitGUID & FaceitNickname
            if (providerFaceitDetails != null)
            {
                FaceitLastMatch[] providerFaceitStats = _client.getFaceitLastMatchDetails(providerFaceitDetails.Item1, providerFaceitDetails.Item2);
                var end = (providerFaceitStats[0].Win_Bool == 1) ? "won" : "lost";
                ViewData["Name"] = providerFaceitDetails.Item2;
                ViewData["Kills"] = providerFaceitStats[0].Kills;
                ViewData["Deaths"] = providerFaceitStats[0].Deaths;
                ViewData["Assists"] = providerFaceitStats[0].Assists;
                ViewData["Map"] = providerFaceitStats[0].Map;
                ViewData["gameMode"] = providerFaceitStats[0].gameMode;
                ViewData["Headshot"] = providerFaceitStats[0].Headshot;
                ViewData["HS"] = providerFaceitStats[0].HS;
                ViewData["KD"] = providerFaceitStats[0].KD;
                ViewData["KR"] = providerFaceitStats[0].KR;
                ViewData["MVP's"] = providerFaceitStats[0].MVPs;
                ViewData["Score"] = providerFaceitStats[0].Score;
                ViewData["Teamname"] = providerFaceitStats[0].Teamname;
                ViewData["Result"] = end;

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
