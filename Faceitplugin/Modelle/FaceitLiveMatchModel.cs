using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Faceitplugin.Modelle
{
    public class FaceitLiveMatchModel
    {
        [JsonProperty("payload", Required = Required.AllowNull)]
        public Payload payload { get; set; }

        public class Payload
        {
            [JsonProperty("STATE", Required = Required.Default)]
            public List<State> STATE { get; set;}
        }


        public class State
        {
            public  Teams teams { get; set; }

            public string id { get; set; }
        }
        public class Teams
        {

            [JsonProperty("faction1", Required = Required.Default)]
            public  Faction faction1 { get; set; }

            [JsonProperty("faction2", Required = Required.Default)]
            public Faction faction2 { get; set; }
        }
        public class Faction
        {
            public  string name { get; set; }
            public List<Roster> roster { get; set; }
        }
        public class Roster
        {
            public  string nickname { get; set; }
            public string id { get; set; }
        }
    }
}
