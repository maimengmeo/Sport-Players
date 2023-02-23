using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTTuyetMaiPham
{
    public class BaseballPlayer : Player
    {
        private int _runs;
        public int Runs
        {
            get { return _runs; }
            set { _runs = value; }
        }

        private int _homeRuns;
        public int HomeRuns
        {
            get { return _homeRuns; }
            set { _homeRuns = value; }
        }

        public BaseballPlayer(PlayerType type, int playerId, string playerName, string teamName, int gamesPlayed, int runs, int homeRuns) : base(type, playerId, playerName, teamName, gamesPlayed)
        {
            Runs = runs;
            HomeRuns = homeRuns;
        }

        public override int Points()
        {
            int totalPoint = (Runs - HomeRuns) + 2 * HomeRuns;
            return totalPoint;
        }
    }
}
