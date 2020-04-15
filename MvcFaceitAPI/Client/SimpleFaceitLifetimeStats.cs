using Faceitplayermodel.config;
using MvcFaceitAPI.ApiRequests;
using MvcFaceitAPI.Modelle;

namespace MvcFaceitAPI.Client
{
    public class SimpleFaceitLifetimeStats
    {
        public FacaeitLifetimeStats getFaceitLifetimeStats(string faceitId, string faceitName)
        {
            var model = new Faceitmatch();
            var _faceitApi = new Faceitapi();

            FacaeitLifetimeStats LastMatch = _faceitApi.getFaceitLifetimeStats(faceitId);
            LastMatch.lifetime.Elo = _faceitApi.getFaceitUserDetails(faceitName).payload.games.csgo.faceit_elo;
            LastMatch.lifetime.Level = _faceitApi.getFaceitUserDetails(faceitName).payload.games.csgo.skill_level;
            return LastMatch;
        }
    }
}
