using FaceitAPI;
using Faceitplayermodel.config;
using Faceitplugin.Modelle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Faceitplugin.Client
{
    public class SimpleLastMatch
    {
        public FaceitLastMatch[] getFaceitLastMatchDetails(string playerID, string nickname)
        {
            var model = new Faceitmatch();
            var _faceitApi = new Faceitapi();

            FaceitLastMatch[] LastMatch = _faceitApi.getFaceitHistory(playerID,1);

            return LastMatch;
        }
    }
}
