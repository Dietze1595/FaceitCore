using Microsoft.AspNetCore.Mvc;
using Faceitplayermodel.config;
using TodoApi.Models;
using Faceitplugin.Abstraction;
using Faceitplugin.Client;
using Faceitplugin.config;
using Faceitplugin.Modelle;
using Newtonsoft.Json;

namespace Faceitplugin.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FaceitLiveMatchController : ControllerBase
    {
        public TodoContext Context { get; }

        public FaceitLiveMatchController(TodoContext context)
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