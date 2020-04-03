using FaceitAPI;
using Faceitplayermodel.config;
using Faceitplugin.Modelle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Faceitplugin.Client
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
