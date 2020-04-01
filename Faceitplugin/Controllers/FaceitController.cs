using Microsoft.AspNetCore.Mvc;
using System.Net;
using Newtonsoft.Json.Linq;
using FaceitAPI;
using csgoModels;
using Faceitplayermodel.config;
using TodoApi.Models;
using System;
using Faceitplugin.Abstraction;
using Faceitplugin.Client;

namespace Faceitplugin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaceitController : ControllerBase
    {
        private readonly TodoContext _context;
        private string resultContent;
        private FaceitUserAbstraction _faceitAbstraction;
        private SimpleFaceitClient _client;


        public FaceitController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Faceit
        [HttpGet]
        public string GetTodoItems()
        {
            return "Please insert a SteamID64";
        }

        // GET: api/Faceit/Steamid
        [HttpGet("{id}")]
        public string GetTodoItem(long id)
        {
            return "your steamid is: " + id;

        }

        // POST: api/TodoItems
        [HttpPost]
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

                string steamid = data.provider.steamid;
                var providerFaceitDetails = _faceitAbstraction.FaceitUserDetails(steamid);      // Get FaceitGUID & FaceitNickname

                modelFaceitmatch = _client.getFaceitMatchDetails(providerFaceitDetails.Item1, providerFaceitDetails.Item2); // Get FaceitMatchDetails
                //modelFaceitmatch.providerSteamId = steamid;
                //Database.Match.Add(modelFaceitmatch);
            }
            return data.provider.steamid;
        }
    }
}