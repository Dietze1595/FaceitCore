using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Faceitplugin.Modelle
{
    public class FaceitLastMatch
    {
        [JsonProperty("gameMode", Required = Required.AllowNull)]
        public string gameMode { get; set; }
        [JsonProperty("i9", Required = Required.AllowNull)]
        public int MVPs { get; set; }
        [JsonProperty("nickname", Required = Required.AllowNull)]
        public string nickname { get; set; }
        [JsonProperty("i13", Required = Required.AllowNull)]
        public int Headshot { get; set; }
        [JsonProperty("i6", Required = Required.AllowNull)]
        public int Kills { get; set; }
        [JsonProperty("i7", Required = Required.AllowNull)]
        public int Assists { get; set; }
        [JsonProperty("i8", Required = Required.AllowNull)]
        public int Deaths { get; set; }
        [JsonProperty("c3", Required = Required.AllowNull)]
        public float KR { get; set; }
        [JsonProperty("c2", Required = Required.AllowNull)]
        public float KD { get; set; }
        [JsonProperty("c4", Required = Required.AllowNull)]
        public int HS { get; set; }
        [JsonProperty("i5", Required = Required.AllowNull)]
        public string Teamname { get; set; }
        [JsonProperty("i1", Required = Required.AllowNull)]
        public string Map { get; set; }
        [JsonProperty("i18", Required = Required.AllowNull)]
        public string Score { get; set; }
        [JsonProperty("i10", Required = Required.AllowNull)]
        public int Win_Bool { get; set; }
        [JsonProperty("i14", Required = Required.AllowNull)]
        public int TripleKills { get; set; }
        [JsonProperty("i15", Required = Required.AllowNull)]
        public int QuadroKills { get; set; }
        [JsonProperty("i16", Required = Required.AllowNull)]
        public int PentaKills { get; set; }
        [JsonProperty("c1", Required = Required.AllowNull)]
        public int Overtime_Bool { get; set; }
        [JsonProperty("i19", Required = Required.AllowNull)]
        public int TeamOvertimeRounds { get; set; }
    }
}
