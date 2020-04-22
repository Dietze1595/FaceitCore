using Faceitplayermodel.config;
using Microsoft.AspNetCore.Mvc;
using MvcFaceitAPI.Abstraction;
using MvcFaceitAPI.Client;
using MvcFaceitAPI.config;
using MvcFaceitAPI.Modelle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcFaceitAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcFaceitAPI.Controllers
{
    public class FaceitStreamPluginController : Controller
    {
        // 
        // GET: /FaceitStreamPlugin?steamId=<steamId>
        // GET: /<controller>/
        public Streamplugin Plugin { get; set; }

        public ActionResult Index(string steamId = "76561198257065483")
        {
            var modelFaceitmatch = new Faceitmatch();
            var _faceitAbstraction = new SimpleFaceitAverageStats();
            var _client = new SimpleFaceitLiveMatch();
            var _Lifetime = new SimpleFaceitLifetimeStats();

            var providerFaceitDetails = _faceitAbstraction.FaceitUserDetails(steamId);      // Get FaceitGUID & FaceitNickname
            if (providerFaceitDetails != null)
            {
                modelFaceitmatch = _client.getFaceitMatchDetails(providerFaceitDetails.Item1, providerFaceitDetails.Item2);
                FacaeitLifetimeStats LifetimeStats = _Lifetime.getFaceitLifetimeStats(providerFaceitDetails.Item1, providerFaceitDetails.Item2);
                FaceitUserStats providerFaceitStats = _faceitAbstraction.FaceitAvgElo(providerFaceitDetails.Item1);

                if (modelFaceitmatch != null)
                {
                    Plugin = new Streamplugin(modelFaceitmatch, LifetimeStats, providerFaceitStats);
                    Plugin.Live = 1;
                }
                else {
                    Plugin = new Streamplugin(null, LifetimeStats, providerFaceitStats);
                    Plugin.Live = 0; 
                }           
                

                return View(Plugin);
            }
            else
            {
                ViewData["Name"] = steamId;
                return View("noFaceit");
            }
        }
    }
}