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
    public class WelcomeController : ControllerBase
    {
        public TodoContext Context { get; }

        public WelcomeController(TodoContext context)
        {
            Context = context;
        }

        // GET: FaceitLivetimeStats
        [HttpGet]
        public string GetTodoItems()
        {
            return "We currently have the following API's \n" +
                "FaceitLifetimeStats/<steamId> \n" +
                "FaceitAvgStats/<steamId> \n" +
                "FaceitLastMatch/<steamId> \n" +
                "FaceitLiveMatch/<steamId> \n";
        }
    }
}