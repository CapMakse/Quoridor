using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quoridor
{
    class Game
    {
        public Player currentPlayer { get; private set; }
        public Player nextPlayer { get;  private set; }

        public WallType[][] Board = {
             new WallType[8],
             new WallType[8],
             new WallType[8],
             new WallType[8],
             new WallType[8],
             new WallType[8],
             new WallType[8],
             new WallType[8]
            };
        public Game(string redPlayer, string bluePlayer)
        {
            Random rnd = new Random();
            if (rnd.Next() % 2 == 0)
            {
                currentPlayer = new Player() { Row = 0, Column = 4, Name = redPlayer };
                nextPlayer = new Player() { Row = 8, Column = 4, Name = bluePlayer };
            }
            else
            {
                nextPlayer = new Player() { Row = 0, Column = 4, Name = redPlayer };
                currentPlayer = new Player() { Row = 8, Column = 4, Name = bluePlayer };
            }
        }
    }
    enum WallType
    {
        Horizontal,
        Vertical
    }
}
