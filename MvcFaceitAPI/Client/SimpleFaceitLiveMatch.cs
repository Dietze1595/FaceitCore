using Faceitplayermodel.config;
using MvcFaceitAPI.ApiRequests;
using MvcFaceitAPI.config;
using MvcFaceitAPI.Modelle;
using System;

namespace MvcFaceitAPI.Client
{
    public class SimpleFaceitLiveMatch
    {
        /// <summary>
        ///     
        /// </summary>
        /// <param name="faceitId"></param>
        /// <param name="historyLength"></param>
        /// <param name="calculationLength"></param>
        /// <returns></returns>
        public Faceitmatch getFaceitMatchDetails(string playerID, string nickname)
        {
            var model = new Faceitmatch();
            var _faceitApi = new Faceitapi();
            FaceitLiveMatchModel LiveMatch = _faceitApi.getFaceitLiveMatch(playerID);

            var x = LiveMatch;
            if (LiveMatch.payload.STATE != null)
            {
                var test = LiveMatch.payload.STATE[0].teams.faction1.roster;
                int ownNumber = (CheckFaction(LiveMatch.payload.STATE[0].teams.faction1.roster, playerID)) ? 1 : 2;
                int enemyNumber = (ownNumber == 1) ? 2 : 1;
                int Rostercount = LiveMatch.payload.STATE[0].teams.faction1.roster.Count;

                foreach (dynamic User in LiveMatch.payload.STATE[0].teams.faction1.roster)
                {
                    if (ownNumber == 1)
                    {
                        var FaceitUs = new FaceitUserInfos();
                        model.ownTeamName = LiveMatch.payload.STATE[0].teams.faction1.name;
                        model.ownTeamElo += _faceitApi.getFaceitUserDetails(User.nickname).payload.games.csgo.faceit_elo;
                    }
                    else
                    {
                        var FaceitUs = new FaceitUserInfos();
                        model.ownTeamName = LiveMatch.payload.STATE[0].teams.faction2.name;
                        model.ownTeamElo += _faceitApi.getFaceitUserDetails(User.nickname).payload.games.csgo.faceit_elo;
                    }
                }
                foreach (dynamic User in LiveMatch.payload.STATE[0].teams.faction2.roster)
                {
                    if (ownNumber == 2)
                    {
                        var FaceitUs = new FaceitUserInfos();
                        model.enemyTeamName = LiveMatch.payload.STATE[0].teams.faction1.name;
                        model.enemyTeamElo += _faceitApi.getFaceitUserDetails(User.nickname).payload.games.csgo.faceit_elo;
                    }
                    else
                    {
                        var FaceitUs = new FaceitUserInfos();
                        model.enemyTeamName = LiveMatch.payload.STATE[0].teams.faction2.name;
                        model.enemyTeamElo += _faceitApi.getFaceitUserDetails(User.nickname).payload.games.csgo.faceit_elo;
                    }
                }

                
                model.ownTeamElo = model.ownTeamElo / Rostercount;
                model.enemyTeamElo = model.enemyTeamElo / Rostercount;

                model.ownTeamWinElo = calculateRating(model.ownTeamElo, model.enemyTeamElo);
                model.enemyTeamWinElo = 50 - model.ownTeamWinElo;
                return model;

            }
            return null;
        }

        public int calculateRating(double own, double enemy)
        {
            double percentage = 1 / (1 + Math.Pow(10, (enemy - own) / 400));
            return Convert.ToInt16(Math.Round(50 * (1 - percentage)));
        }

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
