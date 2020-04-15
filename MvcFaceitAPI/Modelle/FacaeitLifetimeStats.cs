using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcFaceitAPI.Modelle
{
    public class FacaeitLifetimeStats
    {
        public Lifetime lifetime { get; set; }

        public class Lifetime
        {
            [JsonProperty("m1", Required = Required.AllowNull)]
            public string PlayedMatches { get; set; }

            [JsonProperty("m2", Required = Required.AllowNull)]
            public string WonMatches { get; set; }

            [JsonProperty("k6", Required = Required.AllowNull)]
            public string WinPercentage { get; set; }

            [JsonProperty("k5", Required = Required.AllowNull)]
            public string KD { get; set; }

            [JsonProperty("k8", Required = Required.AllowNull)]
            public string HSPercentage { get; set; }

            [JsonProperty("s2", Required = Required.AllowNull)]
            public string highesWinningstreak { get; set; }
            [JsonProperty("s1", Required = Required.AllowNull)]
            public string currentWinningstreak { get; set; }

            public int Elo { get; set; }

            public int Level { get; set; }
        }
    }
}
