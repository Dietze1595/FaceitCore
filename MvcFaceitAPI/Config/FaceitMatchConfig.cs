using System.Collections.Generic;

namespace Faceitplayermodel.config
{

    public class Faceitmatch
    {
        public string ownTeamName { get; set; }
        public int ownTeamElo { get; set; }
        public int ownTeamWinElo { get; set; }
        public string enemyTeamName { get; set; }
        public int enemyTeamElo { get; set; }
        public int enemyTeamWinElo { get; set; }
    }
}
