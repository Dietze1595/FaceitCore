using Faceitplayermodel.config;
using MvcFaceitAPI.config;
using MvcFaceitAPI.Modelle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcFaceitAPI.Models
{
    public class Streamplugin
    {
        public Streamplugin()
        {

        }
        public Streamplugin(Faceitmatch model, FacaeitLifetimeStats lifetime, FaceitUserStats stats) : this()
        {
            if (model != null)
            {
                _ownTeamName = model.ownTeamName;
                _ownTeamElo = model.ownTeamElo;
                _ownTeamWinElo = model.ownTeamWinElo;
                _enemyTeamName = model.enemyTeamName;
                _enemyTeamElo = model.enemyTeamElo;
                _enemyTeamWinElo = model.enemyTeamWinElo;
            }
            _elo = lifetime.lifetime.Elo;
            _WonMatches = lifetime.lifetime.WonMatches;
            _PlayedMatches = lifetime.lifetime.PlayedMatches;
            _WinPercentage = lifetime.lifetime.WinPercentage;
            _avgKills = stats.avgKills;
            _avgHs = stats.avgHs;
            _avgKd = stats.avgKd;
            _avgKr = stats.avgKr;
        }


        int _enemyTeamElo;
        public int enemyTeamElo
        {
            get => _enemyTeamElo;
            set 
            {
                if(_enemyTeamElo == value)
                {
                    return;
                }
                _enemyTeamElo = value;
            }
        }

        int _enemyTeamWinElo;
        public int enemyTeamWinElo
        {
            get => _enemyTeamWinElo;
            set
            {
                if (_enemyTeamWinElo == value)
                {
                    return;
                }
                _enemyTeamWinElo = value;
            }
        }

        string _enemyTeamName;
        public string enemyTeamName
        {
            get => _enemyTeamName;
            set
            {
                if (_enemyTeamName == value)
                {
                    return;
                }
                _enemyTeamName = value;
            }
        }


        int _ownTeamElo;
        public int ownTeamElo
        {
            get => _ownTeamElo;
            set
            {
                if (_ownTeamElo == value)
                {
                    return;
                }
                _ownTeamElo = value;
            }
        }
        
        int _ownTeamWinElo;
        public int ownTeamWinElo
        {
            get => _ownTeamWinElo;
            set
            {
                if (_ownTeamWinElo == value)
                {
                    return;
                }
                _ownTeamWinElo = value;
            }
        }

        string _ownTeamName;
        public string ownTeamName
        {
            get => _ownTeamName;
            set
            {
                if (_ownTeamName == value)
                {
                    return;
                }
                _ownTeamName = value;
            }
        }


        
        int _elo;
        public int Elo
        {
            get => _elo;
            set
            {
                if (_elo == value)
                {
                    return;
                }
                _elo = value;
            }
        }

        string _WonMatches;
        public string WonMatches
        {
            get => _WonMatches;
            set
            {
                if (_WonMatches == value)
                {
                    return;
                }
                _WonMatches = value;
            }
        }

        string _PlayedMatches;
        public string PlayedMatches
        {
            get => _PlayedMatches;
            set
            {
                if (_PlayedMatches == value)
                {
                    return;
                }
                _PlayedMatches = value;
            }
        }
        string _WinPercentage;
        public string WinPercentage
        {
            get => _WinPercentage;
            set
            {
                if (_WinPercentage == value)
                {
                    return;
                }
                _WinPercentage = value;
            }
        }




        int _avgKills;
        public int avgKills
        {
            get => _avgKills;
            set
            {
                if (_avgKills == value)
                {
                    return;
                }
                _avgKills = value;
            }
        }


        int _avgHs;
        public int avgHs
        {
            get => _avgHs;
            set
            {
                if (_avgHs == value)
                {
                    return;
                }
                _avgHs = value;
            }
        }

        float _avgKd;
        public float avgKd
        {
            get => _avgKd;
            set
            {
                if (_avgKd == value)
                {
                    return;
                }
                _avgKd = value;
            }
        }

        float _avgKr;
        public float avgKr
        {
            get => _avgKr;
            set
            {
                if (_avgKr == value)
                {
                    return;
                }
                _avgKr = value;
            }
        }
        public int Live { get; set; }


    }
}
