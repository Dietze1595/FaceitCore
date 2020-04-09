using Faceitplayermodel.config;
using MvcFaceitAPI.ApiRequests;
using MvcFaceitAPI.Modelle;

namespace MvcFaceitAPI.Client
{
    public class SimpleFaceitLifetimeStats
    {
        public FacaeitLifetimeStats getFaceitLifetimeStats(string faceitId)
        {
            var model = new Faceitmatch();
            var _faceitApi = new Faceitapi();

            dynamic LastMatch = _faceitApi.getFaceitLifetimeStats(faceitId);
            return LastMatch;
        }
    }
}
