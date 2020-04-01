using Microsoft.AspNetCore.Mvc;
using Faceitplayermodel.config;
using TodoApi.Models;
using Faceitplugin.Abstraction;
using Faceitplugin.Client;
using Faceitplugin.config;

namespace Faceitplugin.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FaceitstatsController : ControllerBase
    {
        public TodoContext Context { get; }

        public FaceitstatsController(TodoContext context)
        {
            Context = context;
        }

        // GET: api/Faceit
        [HttpGet]
        public string GetTodoItems()
        {
            return "Please insert a SteamID64";
        }

        // GET: api/Faceit/Steamid
        [HttpGet("{id}")]
        public string GetTodoItem(string id)
        {
            var modelFaceitmatch = new Faceitmatch();
            var _faceitAbstraction = new FaceitUserAbstraction();
            var _client = new SimpleFaceitClient();

            var providerFaceitDetails = _faceitAbstraction.FaceitUserDetails(id);      // Get FaceitGUID & FaceitNickname
            FaceitUserStats providerFaceitStats = _faceitAbstraction.FaceitAvgElo(providerFaceitDetails.Item1);      // Get FaceitGUID & FaceitNickname
            modelFaceitmatch = _client.getFaceitMatchDetails(providerFaceitDetails.Item1, providerFaceitDetails.Item2);

            if (modelFaceitmatch != null)
            {
                return "Welcome " + providerFaceitDetails.Item2 + ", your AVG Kills:  " + providerFaceitStats.avgKills + " AVG K/D:  " + providerFaceitStats.avgKd + " AVG HS%:  " + providerFaceitStats.avgHs + " AVG K/R:  " + providerFaceitStats.avgKr + "\n" +
                    "FaceitMatchInformation \n" + modelFaceitmatch.ownTeamName + " vs " + modelFaceitmatch.enemyTeamName + "\n" +
                    "OwnTeam: " + modelFaceitmatch.ownTeamElo + " WinPoints: " + modelFaceitmatch.ownTeamWinElo + "\n" +
                    "EnemyTeam: " + modelFaceitmatch.enemyTeamElo + " WinPoints: " + modelFaceitmatch.enemyTeamWinElo;
            }
            else
            {
                return "Welcome " + providerFaceitDetails.Item2 + ", your AVG Kills:  " + providerFaceitStats.avgKills + " AVG K/D:  " + providerFaceitStats.avgKd + " AVG HS%:  " + providerFaceitStats.avgHs + " AVG K/R:  " + providerFaceitStats.avgKr;
            }
        }


        // POST: api/TodoItems
        /*[HttpPost]
        public string PostTodoItem(CSGOJson data)
        {
            if (data.player.state == null)
            {
                // Datenbank mit der ProvidersteamId löschen
            }
            else
            {
                var modelFaceitmatch = new Faceitmatch();
                var _faceitAbstraction = new FaceitUserAbstraction();
                var _client = new SimpleFaceitClient();

                //string steamid = data.provider.steamid;
                //var providerFaceitDetails = _faceitAbstraction.FaceitUserDetails(steamid);      // Get FaceitGUID & FaceitNickname

                modelFaceitmatch = _client.getFaceitMatchDetails(providerFaceitDetails.Item1, providerFaceitDetails.Item2); // Get FaceitMatchDetails
                //modelFaceitmatch.providerSteamId = steamid;
                //Database.Match.Add(modelFaceitmatch);
            }
            return data.provider.steamid;
        }*/
    }
}