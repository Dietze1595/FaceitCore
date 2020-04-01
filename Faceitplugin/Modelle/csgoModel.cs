namespace csgoModels
{
    public class CSGOJson
    {
        public Provider provider { get; set; }
        public Map map { get; set; }
        public Player player { get; set; }
        public Auth auth { get; set; }

        public class Provider
        {
            public string name { get; set; }
            public int appid { get; set; }
            public int version { get; set; }
            public string steamid { get; set; }
            public long timestamp { get; set; }
        }

        public class Map
        {
            public string mode { get; set; }
            public string name { get; set; }
            public string phase { get; set; }
            public int round { get; set; }
        }


        public class Player
        {
            public string steamid { get; set; }
            public string name { get; set; }
            public string activity { get; set; }
            //public Weapons weapons { get; set; }
            public State state { get; set; }
            public MatchStats match_stats { get; set; }
        }
        public class State
        {
            public int round_kills { get; set; }
        }

        public class MatchStats
        {
            public int kills { get; set; }
            public int assists { get; set; }
            public int deaths { get; set; }
            public int mvps { get; set; }
            public int score { get; set; }
        }
        public class Auth
        {
            public string token { get; set; }
        }
    }
}