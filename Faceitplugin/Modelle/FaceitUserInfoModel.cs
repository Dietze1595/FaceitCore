using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Faceitplugin.Modelle
{
    public class FaceitUserInfoModel
    {
        public Payload payload { get; set; }

        public class Payload
        {

            [JsonProperty("players", Required = Required.AllowNull)]
            public Player players { get; set; }
        }

        public class Player
        {
            public List<Results> results { get; set; } = new List<Results>();
        }


        public class Results
        {
            public string nickname { get; set; }
            public string guid { get; set; }
            public List<Games> games { get; set; } = new List<Games>();
        }

        public class Games
        {
            public string name { get; set; }
        }
    }
}