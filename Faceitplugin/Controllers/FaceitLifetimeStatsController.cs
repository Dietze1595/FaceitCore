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
    public class FaceitLifetimeStatsController : ControllerBase
    {
        public TodoContext Context { get; }

        public FaceitLifetimeStatsController(TodoContext context)
        {
            Context = context;
        }

        // GET: FaceitLivetimeStats
        [HttpGet]
        public string GetTodoItems()
        {
            return "Please insert a SteamID64";
        }

        // GET: FaceitLifetimeStats/<steamid>
        [HttpGet("{id}")]
        public string GetTodoItem(string id)
        {
            var _faceitAbstraction = new SimpleFaceitAverageStats();
            var _client = new SimpleFaceitLifetimeStats();

            var providerFaceitDetails = _faceitAbstraction.FaceitUserDetails(id);      // Get FaceitGUID & FaceitNickname

            if (providerFaceitDetails != null)
            {
                FacaeitLifetimeStats LifetimeStats = _client.getFaceitLifetimeStats(providerFaceitDetails.Item1);      // Get FaceitGUID & FaceitNickname
                return "Welcome " + providerFaceitDetails.Item2 + ", " + JsonConvert.SerializeObject(LifetimeStats);
            }
            else
            {
                return "Welcome, I cant find any Faceitaccount with your inserted SteamId";
            }
        }
    }
}