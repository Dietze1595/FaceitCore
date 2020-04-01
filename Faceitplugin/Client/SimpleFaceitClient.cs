using FaceitAPI;
using Faceitplayermodel.config;
using Faceitplugin.config;
using Faceitplugin.Modelle;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Faceitplugin.Client
{
    public class SimpleFaceitClient
    {
        string[] matchStates = new string[]{"READY", "VOTING", "ONGOING"};
        public Faceitmatch getFaceitMatchDetails(string playerID, string nickname)
        {
            
            var model = new Faceitmatch();
            var _faceitApi = new Faceitapi();
            FaceitLiveMatchModel LiveMatch = _faceitApi.getFaceitLiveMatch(playerID);

            var x = LiveMatch;
            //int ownNumber = (CheckFaction(LiveMatch.payload.STATE[0].teams.faction1.roster, playerID)) ? 1 : 2;
            //int enemyNumber = (ownNumber == 1) ? 2 : 1;

            /*
            for (int i = 1; i <= 2; i++)
            {
                foreach (dynamic User in FaceitMatch[0].teams["faction" + i].roster)
                {
                    var FaceitUs = new FaceitPlayer();
                    if (i == ownNumber)
                    {
                        FaceitUs = FaceitUserElo(Convert.ToString(User.nickname), playerID);
                        model.ownTeamName = FaceitMatch[0].teams["faction" + i].name;
                        model.ownTeamElo = FaceitUs.elo;
                        model.ownTeammembers.Add(FaceitUs);
                    }
                    else
                    {
                        FaceitUs = FaceitUserElo(Convert.ToString(User.nickname));
                        model.enemyTeamName = FaceitMatch[0].teams["faction" + i].name;
                        model.enemyTeamElo = FaceitUs.elo;
                    }
                }
            }
            model.ownTeamElo = model.ownTeamElo / FaceitMatch[0].teams["faction1"].roster.Count;
            model.enemyTeamElo = model.enemyTeamElo / FaceitMatch[0].teams["faction1"].roster.Count;

            model.ownTeamWinElo = calculateRating(model.ownTeamElo, model.enemyTeamElo);
            model.enemyTeamWinElo = 50 - model.ownTeamWinElo;*/
            return model;
        }

        /*public CompleteFaceitUser getFaceitUser(string faceitName, string playerid)
        {
            var Play = new CompleteFaceitUser();
            dynamic UserDetails = _faceitApi.getFaceitUserInfo(faceitName);

            return Play;
        }*/

        /// <summary>
        ///     
        /// </summary>
        /// <param name="faceitId"></param>
        /// <param name="historyLength"></param>
        /// <param name="calculationLength"></param>
        /// <returns></returns>
        /* public FaceitUserStats FaceitAvgElo(string faceitId, int historyLength = 50, int calculationLength = 20)    
         {
             int count = 0;
             var userStats = new FaceitUserStats();

             dynamic UserHistory = _faceitApi.getFaceitHistory(faceitId, historyLength);   //get Object of all Matches

             foreach (var Matches in UserHistory)
             {
                 if (Matches.gameMode == "5v5")
                 {
                     count++;
                     userStats = getSumOfStats(Matches);

                     if (count >= calculationLength)
                     {
                         break;
                     }
                 }
             }

             userStats = getAvgStats(userStats, count);

             return userStats;
         }


         public FaceitUserStats getSumOfStats(dynamic matchStats)
         {
             var Userstats = new FaceitUserStats();
             Userstats.avgKills += Convert.ToInt16(matchStats.i6);
             Userstats.avgHs += Convert.ToInt16(matchStats.c4);
             Userstats.avgKd += Convert.ToInt32(Convert.ToSingle(matchStats.c2) * 100);
             Userstats.avgKr += Convert.ToInt32(Convert.ToSingle(matchStats.c3) * 100);
             return Userstats;
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

         public int calculateRating(double own, double enemy)
         {
             double percentage = 1 / (1 + Math.Pow(10, (enemy - own) / 400));
             return Convert.ToInt16(Math.Round(50 * (1 - percentage)));
         }*/

        public bool CheckFaction(dynamic Object, string player)
        {
            foreach (dynamic User in Object)
            {
                if (User.id == player) return true;
            }
            return false;
        }
    }
}
