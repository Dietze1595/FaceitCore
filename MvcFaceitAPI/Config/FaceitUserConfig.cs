namespace MvcFaceitAPI.config
{
    public class FaceitUserStats
    {
        public int avgKills { get; set; }
        public int avgHs { get; set; }
        public float avgKd { get; set; }
        public float avgKr { get; set; }
    }

    public class FaceitUserInfos
    {
        public string nickName { get; set; }
        public string GUID { get; set; }
        public string steamId { get; set; }
        public string avatar { get; set; }
        public string flag { get; set; }
        public int elo { get; set; }
        public int level { get; set; }
    }
}
