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
    public class FaceitLastMatchController : ControllerBase
    {
        public TodoContext Context { get; }

        public FaceitLastMatchController(TodoContext context)
        {
            Context = context;
        }

        // GET: FaceitLastMatch
        [HttpGet]
        public string GetTodoItems()
        {
            return "Please insert a SteamID64";
        }

        // GET: FaceitLastMatch/<steamId>
        [HttpGet("{id}")]
        public string GetTodoItem(string id)
        {
            var modelFaceitmatch = new Faceitmatch();
            var _faceitAbstraction = new FaceitUserAbstraction();
            var _client = new SimpleLastMatch();


            var providerFaceitDetails = _faceitAbstraction.FaceitUserDetails(id);      // Get FaceitGUID & FaceitNickname
            FaceitLastMatch[] providerFaceitStats = _client.getFaceitLastMatchDetails(providerFaceitDetails.Item1, providerFaceitDetails.Item2);
            return "" + JsonConvert.SerializeObject(providerFaceitStats);

        }
    }
}