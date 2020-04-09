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
        public string Index(string steamId = "0")
        {
            var _faceitAbstraction = new SimpleFaceitAverageStats();
            var _client = new SimpleLastMatch();


            var providerFaceitDetails = _faceitAbstraction.FaceitUserDetails(steamId);      // Get FaceitGUID & FaceitNickname
            if (providerFaceitDetails != null)
            {
                FaceitLastMatch[] providerFaceitStats = _client.getFaceitLastMatchDetails(providerFaceitDetails.Item1, providerFaceitDetails.Item2);
                var end = (providerFaceitStats[0].Win_Bool == 1) ? "gewonnen" : "verloren";

                return "Welcome: " + providerFaceitStats[0].nickname + " your last map: " + providerFaceitStats[0].Map + " " + end + " Score: " + providerFaceitStats[0].Score +
                    "\nKills: " + providerFaceitStats[0].Kills + " Deaths: " + providerFaceitStats[0].Deaths + " Assists: " + providerFaceitStats[0].Assists +
                    " HS%: " + providerFaceitStats[0].HS + " KD: " + providerFaceitStats[0].KD + " KR: " + providerFaceitStats[0].KR;
            }
            else
            {
                return "Kein Faceitaccount gefunden";
            }
        }
    }
}
