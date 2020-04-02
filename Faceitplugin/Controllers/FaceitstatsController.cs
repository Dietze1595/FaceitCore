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

        // GET: Faceitstats
        [HttpGet]
        public string GetTodoItems()
        {
            return "Please insert a SteamID64";
        }

        // GET: Faceitstats/<steamid>
        [HttpGet("{id}")]
        public string GetTodoItem(string id)
        {
            var modelFaceitmatch = new Faceitmatch();
            var _faceitAbstraction = new FaceitUserAbstraction();
            var _client = new SimpleFaceitClient();

            var providerFaceitDetails = _faceitAbstraction.FaceitUserDetails(id);      // Get FaceitGUID & FaceitNickname

            if (providerFaceitDetails != null)
            {
                FaceitUserStats providerFaceitStats = _faceitAbstraction.FaceitAvgElo(providerFaceitDetails.Item1);      // Get FaceitGUID & FaceitNickname
                return "Welcome " + providerFaceitDetails.Item2 + ", your AVG Kills:  " + providerFaceitStats.avgKills + " AVG K/D:  " + providerFaceitStats.avgKd + " AVG HS%:  " + providerFaceitStats.avgHs + " AVG K/R:  " + providerFaceitStats.avgKr;
            }
            else
            {
                return "Welcome, I cant find any Faceitaccount with your inserted SteamId";
            }
        }
    }
}