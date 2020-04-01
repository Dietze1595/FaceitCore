using FaceitAPI;
using Faceitplayermodel.config;
using Faceitplugin.config;
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

            foreach (var Player in getFaceitPlayer.payload.players.results)
            {
                if (Player.games.Where(i => i.name == "csgo") != null)
                {
                    getPlayerName = Player.nickname;
                    getPlayerGuid = Player.guid;
                }
            }
            return Tuple.Create(getPlayerGuid, getPlayerName);
        }

        public FaceitUserStats FaceitAvgElo(string faceitId, int historyLength = 50, int calculationLength = 20)
        {
            int count = 0;
            var userStats = new FaceitUserStats();
            var _faceitApi = new Faceitapi();

            dynamic UserHistory = _faceitApi.getFaceitHistory(faceitId, historyLength);   //get Object of all Matches

            foreach (var Matches in UserHistory)
            {
                if (Matches.gameMode == "5v5")
                {
                    count++;
                    userStats = getSumOfStats(Matches, userStats);

                    if (count >= calculationLength)
                    {
                        break;
                    }
                }
            }
            userStats = getAvgStats(userStats, count);
            return userStats;
        }

        public FaceitUserStats getSumOfStats(dynamic matchStats, dynamic stats)
        {
            stats.avgKills += Convert.ToInt16(matchStats.i6);
            stats.avgHs += Convert.ToInt16(matchStats.c4);
            stats.avgKd += Convert.ToInt32(Convert.ToSingle(matchStats.c2) * 100);
            stats.avgKr += Convert.ToInt32(Convert.ToSingle(matchStats.c3) * 100);
            return stats;
        }

        public FaceitUserStats getAvgStats(FaceitUserStats user, int count)
        {
            var Userstats = new FaceitUserStats();
            Userstats.avgKills = user.avgKills / count;
            Userstats.avgHs = user.avgHs / count;
            Userstats.avgKd = (float)Math.Round(user.avgKd / 100 / count, 2);
            Userstats.avgKr = (float)Math.Round(user.avgKr / 100 / count, 2);
            return Userstats;
        }
    }
}
