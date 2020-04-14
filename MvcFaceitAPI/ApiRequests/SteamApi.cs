using MvcFaceitAPI.Modelle;
using MvcFaceitAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MvcFaceitAPI.ApiRequests
{
    public class SteamApi
    {

        public dynamic getSteamUser(string steamUser)
        {
            WebClient webClient = GetWebClient();
            dynamic User = JsonConvert.DeserializeObject(webClient.DownloadString("http://api.steampowered.com/ISteamUser/ResolveVanityURL/v0001/?key=4D853E750C7A6B3B5DDBB719DD87E915&vanityurl=" + steamUser));
            return User;
        }



        private static WebClient GetWebClient()
        {
            return new WebClient();
        }

    }
}
