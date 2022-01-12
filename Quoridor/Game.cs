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

        WallType[][] Board = {
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
        public bool TryPutWall(int row, int column, bool vertical)
        {
            if (Board[row][column] != WallType.Empty || currentPlayer.CountOfWalls == 0) return false;
            if (vertical)
            {
                if (row != 0)
                {
                    if (Board[row - 1][column] == WallType.Vertical) return false;
                }
                if (row != 7)
                {
                    if (Board[row + 1][column] == WallType.Vertical) return false;
                }
            }
            else
            {
                if (column != 0)
                {
                    if (Board[row][column - 1] == WallType.Horizontal) return false;
                }
                if (column != 7)
                {
                    if (Board[row][column + 1] == WallType.Horizontal) return false;
                }
            }
            if (vertical)
            {
                Board[row][column] = WallType.Vertical;
            }
            else
            {
                Board[row][column] = WallType.Horizontal;
            }
            //A*
            currentPlayer.CountOfWalls--;
            ChangePLayer();
            return true;
        }
        void ChangePLayer()
        {
            Player buffer = currentPlayer;
            currentPlayer = nextPlayer;
            nextPlayer = buffer;
        }
    }
    enum WallType
    {
        Empty,
        Horizontal,
        Vertical
    }
}
