using MvcFaceitAPI.ApiRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcFaceitAPI.Client
{
    public class getSteamId
    {
        public string SteamId(string steamname)
        {
            var _steamApi = new SteamApi();
            string steamid = "";
            dynamic steamUser = _steamApi.getSteamUser(steamname);

            if (steamUser.response.success == 1)
            {
                steamid = steamUser.response.steamid;
            }
            else
            {
                steamid = steamname;
            }
            return steamid;
        }
    }
}
