namespace Faceitplayermodel.config
{
    using Faceitplugin.config;
    using System.Collections.Generic;

    // --> include Database
    public static class Database
    {
        public static List<Faceitmatch> Match { get; } = new List<Faceitmatch>();
    }


    public class Faceitmatch
    {
        public string providerSteamId { get; set; }
        public string ownTeamName { get; set; }
        public int ownTeamElo { get; set; }
        public int ownTeamWinElo { get; set; }
        public List<CompleteFaceitUser> ownTeammembers { get; } = new List<CompleteFaceitUser>();
        public string enemyTeamName { get; set; }
        public int enemyTeamElo { get; set; }
        public int enemyTeamWinElo { get; set; }
    }
}
