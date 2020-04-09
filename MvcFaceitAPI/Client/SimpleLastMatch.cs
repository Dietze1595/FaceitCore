using Faceitplayermodel.config;
using MvcFaceitAPI.ApiRequests;
using MvcFaceitAPI.Modelle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcFaceitAPI.Client
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
