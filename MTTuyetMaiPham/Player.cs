using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTTuyetMaiPham
{
        public enum PlayerType
        {
            HockeyPlayer,
            BasketballPlayer,
            BaseballPlayer
        }
        public abstract class Player
        {

            private PlayerType _type;
            public PlayerType PlayerType
            {
                get { return _type; }
                set { _type = value; }

            }

            private int _playerId;
            public int PlayerId
            {
                get { return _playerId; }
                set { _playerId = value; }
            }

            private string _playerName;
            public string PlayerName
            {
                get { return _playerName; }
                set { _playerName = value; }
            }

            private string _teamName;
            public string TeamName
            {
                get { return _teamName; }
                set { _teamName = value; }
            }

            private int _gamesPlayed;
            public int GamesPlayed
            {
                get { return _gamesPlayed; }
                set { _gamesPlayed = value; }
            }

            public Player()
            {

            }

            public Player(PlayerType type, int playerId, string playerName, string teamName, int gamesPlayed)
            {
                PlayerType = type;
                PlayerId = playerId;
                PlayerName = playerName;
                TeamName = teamName;
                GamesPlayed = gamesPlayed;
            }

            public abstract int Points();
        }

}
