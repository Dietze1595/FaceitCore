using FaceitAPI;
using Faceitplugin.Modelle;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Faceitplugin.Abstraction
{
    public class FaceitUserAbstraction
    {
        /// <summary>
        /// return of the FaceitGUID and FaceitName based on the SteamID
        /// </summary>
        /// <param name="steamID"></param>
        /// <returns></returns>
        public Tuple<string, string> FaceitUserDetails(string steamID)
        {
            var _faceitApi = new Faceitapi();
            string getPlayerGuid = "";
            string getPlayerName = "";
            FaceitUserInfoModel getFaceitPlayer = _faceitApi.getFaceitUserInfo(steamID);

            foreach(var Player in getFaceitPlayer.payload.players.results)
            {
                if (Player.games.Where(i => i.name == "csgo") != null)
                {
                    getPlayerName = Player.nickname;
                    getPlayerGuid = Player.guid;
                }
            }
            return Tuple.Create(getPlayerGuid, getPlayerName);
        }
    }
}
