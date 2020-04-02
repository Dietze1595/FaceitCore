using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using csgoModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Faceitplugin.Controllers
{
    [Route("[controller]")]
    public class PostCsgoData : Controller
    {
        // GET: <controller>
        [HttpGet]
        public string Get()
        {
            return "You have to change the URL in the File gamestateintegration to xyz:3001. You can find the File in your CSGO Folder \n" +
                "Please insert your correct steam64Id behind the URL";
        }

        // GET <controller>
        [HttpGet("{id}")]
        public ContentResult Get(int id)
        {
            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK,
                Content = System.IO.File.ReadAllText("C:/_/FacecitCore/Faceitplugin/HTMLPage/htmlpage.html"),
            };
        }

        // POST <controller>
        [HttpPost]
        public string PostTodoItem(CSGOJson data)
        {
            if (data.player.state == null)
            {
                // Datenbank mit der ProvidersteamId löschen
            }
            else
            {
                /*var modelFaceitmatch = new Faceitmatch();
                var _faceitAbstraction = new FaceitUserAbstraction();
                var _client = new SimpleFaceitClient();

                //string steamid = data.provider.steamid;
                //var providerFaceitDetails = _faceitAbstraction.FaceitUserDetails(steamid);      // Get FaceitGUID & FaceitNickname

                modelFaceitmatch = _client.getFaceitMatchDetails(providerFaceitDetails.Item1, providerFaceitDetails.Item2); // Get FaceitMatchDetails
                                                                                                                            //modelFaceitmatch.providerSteamId = steamid;
                                                                                                                            //Database.Match.Add(modelFaceitmatch);*/
            }
            return data.provider.steamid;
        }
    }
}
