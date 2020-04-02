using Faceitplugin.Modelle;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace FaceitAPI
{
    public class Faceitapi
    {
        private const string state = "\"STATE\":";
        private const string ongoing = "\"ONGOING\":";
        private const string ready = "\"READY\":";
        private const string voting = "\"VOTING\":";

        /// <summary>
        /// return FaceitUserGUID and FaceitUserName based on SteamId
        /// </summary>
        /// <param name="steamID"></param>
        /// <returns>FaceitUserGuid / FaceitUserName</returns>
        public FaceitUserInfoModel getFaceitUserInfo(string steamID)
        {
            WebClient webClient = GetWebClient();
            FaceitUserInfoModel returnFaceitUserDetails = JsonConvert.DeserializeObject<FaceitUserInfoModel>(webClient.DownloadString("https://api.faceit.com/search/v1?limit=5&query=" + steamID));
            return returnFaceitUserDetails;
        }

        public FaceitNickname getFaceitUserDetails(string faceitName)
        {
            WebClient webClient = GetWebClient();
            FaceitNickname UserDetails = JsonConvert.DeserializeObject<FaceitNickname>(webClient.DownloadString("https://api.faceit.com/core/v1/nicknames/" + faceitName));
            return UserDetails;
        }

        /// <summary>
        /// returns two Teamnames with their Roster (Faction1 / Faction2)
        /// </summary>
        /// <param name="playerID"></param>
        /// <returns>Teamnames with roster</returns>
        public FaceitLiveMatchModel getFaceitLiveMatch(string playerID)
        {
            WebClient webClient = GetWebClient();
            string returnFaceitMatchString = webClient.DownloadString("https://api.faceit.com/match/v1/matches/groupByState?userId=" + playerID).Replace(ongoing, state).Replace(ready, state).Replace(voting, state).ToString();
            FaceitLiveMatchModel returnFaceitMatch = JsonConvert.DeserializeObject<FaceitLiveMatchModel>(returnFaceitMatchString);
            return returnFaceitMatch;
        }

        /// <summary>
        /// returns the faceit history with the count of history
        /// </summary>
        /// <param name="faceitId"></param>
        /// <param name="history"></param>
        /// <returns>Returns the stats of your last Faceitmatches</returns>
        public FaceitLastMatch[] getFaceitHistory(string faceitId, int historyCounter = 1)
        {
            WebClient webClient = GetWebClient();
            FaceitLastMatch[] FaceitUserMatches = JsonConvert.DeserializeObject<FaceitLastMatch[]>(webClient.DownloadString("https://api.faceit.com/stats/v1/stats/time/users/" + faceitId + "/games/csgo?size=" + historyCounter));
            return FaceitUserMatches;
        }

        private static WebClient GetWebClient()
        {
            return new WebClient();
        }
    }
}