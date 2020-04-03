using Newtonsoft.Json;
using System.Collections.Generic;

namespace Faceitplugin.Modelle
{
    public class FaceitUserinfoModel
    {
        public Payload payload { get; set; }

        public class Payload
        {

            public Games games { get; set; }
        }

        public class Games
        {
            public CsGo csgo { get;set;}
        }

        
        public class CsGo
        {
            public int skill_level { get; set; }
            public int faceit_elo { get; set; }
        }
    }
}