using MvcFaceitAPI.config;
using MvcFaceitAPI.Modelle;
using System;
using MvcFaceitAPI.ApiRequests;

namespace MvcFaceitAPI.Abstraction
{
    public class SimpleFaceitAverageStats
    {
        /// <summary>
        /// return of the FaceitGUID and FaceitName based on the SteamID
        /// </summary>
        /// <param name="steamID"></param>
        /// <returns></returns>
        public Tuple<string, string> FaceitUserDetails(string steamID)
        {
            try
            {
                var _faceitApi = new Faceitapi();
                string getPlayerGuid = "";
                string getPlayerName = "";
                FaceitGameModel getFaceitPlayer = _faceitApi.getFaceitUserInfo(steamID);

                foreach (var Player in getFaceitPlayer.payload.players.results)
                {
                    if (Player.games.Count == 0) continue;
                    for (int i = 0; i < Player.games.Count; i++)
                    {
                        if (Player.games[i].name == "csgo")
                        {
                            getPlayerName = Player.nickname;
                            getPlayerGuid = Player.guid;
                            return Tuple.Create(getPlayerGuid, getPlayerName);
                        }
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Get FaceitAvg Stats with the historyLength and the calculationLength
        /// </summary>
        /// <param name="faceitId"></param>
        /// <param name="historyLength"></param>
        /// <param name="calculationLength"></param>
        /// <returns></returns>
        public FaceitUserStats FaceitAvgElo(string faceitId, int historyLength = 50, int calculationLength = 20)
        {
            int count = 0;
            var userStats = new FaceitUserStats();
            var _faceitApi = new Faceitapi();

            FaceitLastMatch[] UserHistory = _faceitApi.getFaceitHistory(faceitId, historyLength);   //get Object of all Matches

            foreach (dynamic Matches in UserHistory)
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

        /// <summary>
        /// Addition der Stats
        /// </summary>
        /// <param name="matchStats"></param>
        /// <param name="stats"></param>
        /// <returns></returns>
        public FaceitUserStats getSumOfStats(dynamic matchStats, dynamic stats)
        {
            stats.avgKills += Convert.ToInt16(matchStats.Kills);
            stats.avgHs += Convert.ToInt16(matchStats.Headshot);
            stats.avgKd += Convert.ToInt32(Convert.ToSingle(matchStats.KD) * 100);
            stats.avgKr += Convert.ToInt32(Convert.ToSingle(matchStats.KR) * 100);
            return stats;
        }

        /// <summary>
        /// Rückgabe des Mittelwertes der Stats
        /// </summary>
        /// <param name="user"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public FaceitUserStats getAvgStats(FaceitUserStats user, int count)
        {
            var Userstats = new FaceitUserStats();
            if(count == 0)
            {
                count = 1;
            }
            Userstats.avgKills = user.avgKills / count;
            Userstats.avgHs = user.avgHs / count;
            Userstats.avgKd = (float)Math.Round(user.avgKd / 100 / count, 2);
            Userstats.avgKr = (float)Math.Round(user.avgKr / 100 / count, 2);
            return Userstats;
        }
    }
}
