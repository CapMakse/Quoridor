using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quoridor
{
    class SearchPathAlgoritm
    {
        int row;
        Game game;
        bool[][] Board;
        public SearchPathAlgoritm(Game game)
        {
            this.game = game; 
            Board = new bool[9][];
            for (int i = 0; i < Board.Length; i++)
            {
                Board[i] = new bool[9];
            }
        }
        public bool CheckPathToRow(int row, int playerRow, int playerColumn)
        {
            this.row = row;
            for (int i = 0; i < Board.Length; i++)
            {
                for (int j = 0; j < Board[i].Length; j++)
                {
                    Board[i][j] = false;
                }
            }
            return CheckPath(playerRow, playerColumn); 
        }
        bool CheckPath(int playerRow, int playerColumn)
        {
            Board[playerRow][playerColumn] = true;
            if (playerRow == row) return true;
            if (playerRow > row)
            {
                if (!Board[playerRow - 1][playerColumn])
                {
                    if (!game.CheckWall(playerRow, playerColumn, playerRow - 1, playerColumn))
                    {
                        if (CheckPath(playerRow - 1, playerColumn)) return true;
                    }
                }
            }
            else
            {
                if (!Board[playerRow + 1][playerColumn])
                {
                    if (!game.CheckWall(playerRow, playerColumn, playerRow + 1, playerColumn))
                    {
                        if (CheckPath(playerRow + 1, playerColumn)) return true;
                    }
                }
            }

            if (playerColumn != 0)
            {
                if (!Board[playerRow][playerColumn - 1])
                {
                    if (!game.CheckWall(playerRow, playerColumn, playerRow, playerColumn - 1))
                    {
                        if (CheckPath(playerRow, playerColumn - 1)) return true;
                    }
                }
            }


            if (playerColumn != 8)
            {
                if (!Board[playerRow][playerColumn + 1])
                {
                    if (!game.CheckWall(playerRow, playerColumn, playerRow, playerColumn + 1))
                    {
                        if (CheckPath(playerRow, playerColumn + 1)) return true;
                    }
                }
            }

            if (playerRow < row)
            {
                if (playerRow != 0 && !Board[playerRow - 1][playerColumn])
                {
                    if (!game.CheckWall(playerRow, playerColumn, playerRow - 1, playerColumn))
                    {
                        if (CheckPath(playerRow - 1, playerColumn)) return true;
                    }
                }
            }
            else
            {
                if (playerRow != 8 && !Board[playerRow + 1][playerColumn])
                {
                    if (!game.CheckWall(playerRow, playerColumn, playerRow + 1, playerColumn))
                    {
                        if (CheckPath(playerRow + 1, playerColumn)) return true;
                    }
                }
            }

            return false;
        }
    }
}
