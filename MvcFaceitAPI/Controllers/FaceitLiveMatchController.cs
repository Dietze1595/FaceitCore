using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public string Index(string steamId = "76561198257065483")
        {
            var modelFaceitmatch = new Faceitmatch();
            var _faceitAbstraction = new SimpleFaceitAverageStats();
            var _client = new SimpleFaceitLiveMatch();


            var providerFaceitDetails = _faceitAbstraction.FaceitUserDetails(steamId);      // Get FaceitGUID & FaceitNickname
            modelFaceitmatch = _client.getFaceitMatchDetails(providerFaceitDetails.Item1, providerFaceitDetails.Item2);
            if (modelFaceitmatch != null)
            {
                return "Welcome " + providerFaceitDetails.Item2 + "\n" +
                    "FaceitMatchInformation \n" + modelFaceitmatch.ownTeamName + " vs " + modelFaceitmatch.enemyTeamName + "\n" +
                    "OwnTeam: " + modelFaceitmatch.ownTeamElo + " WinPoints: " + modelFaceitmatch.ownTeamWinElo + "\n" +
                    "EnemyTeam: " + modelFaceitmatch.enemyTeamElo + " WinPoints: " + modelFaceitmatch.enemyTeamWinElo;
            }
            else
            {
                return "Welcome " + providerFaceitDetails.Item2 + ", currently no Faceit Match ongoing";
            }
            
        }
    }
}
