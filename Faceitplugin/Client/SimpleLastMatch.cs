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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="playerID"></param>
        /// <param name="nickname"></param>
        /// <returns>Last FaceitMatch</returns>
        public FaceitLastMatch[] getFaceitLastMatchDetails(string playerID, string nickname)
        {
            var model = new Faceitmatch();
            var _faceitApi = new Faceitapi();
            
            FaceitLastMatch[] LastMatch = _faceitApi.getFaceitHistory(playerID);

            return LastMatch;
        }
    }
}
