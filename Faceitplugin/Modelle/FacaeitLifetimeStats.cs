using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Faceitplugin.Modelle
{
    public class FacaeitLifetimeStats
    {
        public Lifetime lifetime { get; set; }

        public class Lifetime
        {
            [JsonProperty("m1", Required = Required.AllowNull)]
            public int PlayedMatches { get; set; }

            [JsonProperty("m2", Required = Required.AllowNull)]
            public int WonMatches { get; set; }

            [JsonProperty("k6", Required = Required.AllowNull)]
            public int WinPercentage { get; set; }

            [JsonProperty("k5", Required = Required.AllowNull)]
            public int KD { get; set; }

            [JsonProperty("k8", Required = Required.AllowNull)]
            public int HSPercentage { get; set; }

            [JsonProperty("s2", Required = Required.AllowNull)]
            public int Winningstreak { get; set; }
        }
    }
}
