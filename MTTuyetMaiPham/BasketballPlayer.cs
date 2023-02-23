using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTTuyetMaiPham
{
    public class BasketballPlayer : Player
    {
        private int _fieldGoals;
        public int FieldGoals
        {
            get { return _fieldGoals; }
            set { _fieldGoals = value; }
        }

        private int _threePointers;
        public int ThreePointers
        {
            get { return _threePointers; }
            set { _threePointers = value; }
        }

        public BasketballPlayer(PlayerType type, int playerId, string playerName, string teamName, int gamesPlayed, int fieldGoals, int threePointers) : base(type, playerId, playerName, teamName, gamesPlayed)
        {
            FieldGoals = fieldGoals;
            ThreePointers = threePointers;
        }

        public override int Points()
        {
            int totalPoint = (FieldGoals - ThreePointers) + 2 * ThreePointers;
            return totalPoint;
        }

    }
}
