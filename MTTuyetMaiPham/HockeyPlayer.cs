using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTTuyetMaiPham
{
    public class HockeyPlayer : Player
    {
        private int _assists;
        public int Assists
        {
            get { return _assists; }
            set { _assists = value; }
        }

        private int _goals;
        public int Goals
        {
            get { return _goals; }
            set { _goals = value; }
        }

        public HockeyPlayer(PlayerType type, int playerId, string playerName, string teamName, int gamesPlayed,
                            int assists, int goals) : base(type, playerId, playerName, teamName, gamesPlayed)
        {
            Assists = assists;
            Goals = goals;
        }

        public override int Points()
        {
            int totalPoints = Assists + 2 * Goals;
            return totalPoints;
        }
    }
}
