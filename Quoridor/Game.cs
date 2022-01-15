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
        public bool TryMoveFigure(int row, int column)
        {
            if (nextPlayer.Column == column && nextPlayer.Row == row) return false;

            if (!CheckNeightbor(currentPlayer.Row, currentPlayer.Column, row, column))
            {
                if(!CheckJump(row, column))
                {
                    return false;
                }
            }
            else
            {
                if (CheckWall(currentPlayer.Row, currentPlayer.Column, row, column))
                {
                    return false;
                }
            }

            currentPlayer.Row = row;
            currentPlayer.Column = column;
            ChangePLayer();
            return true;
        }
        bool CheckJump(int row, int column)
        {
            if (CheckNeightbor(currentPlayer.Row, currentPlayer.Column, nextPlayer.Row, nextPlayer.Column) && CheckNeightbor(row, column, nextPlayer.Row, nextPlayer.Column))
            {
                if (CheckWall(currentPlayer.Row, currentPlayer.Column, nextPlayer.Row, nextPlayer.Column) || CheckWall(row, column, nextPlayer.Row, nextPlayer.Column))
                {
                    return false;
                }
                if (!(currentPlayer.Row == row && nextPlayer.Row == row) && !(currentPlayer.Column == column && nextPlayer.Column == column))
                {
                    if (!CheckWallJump())
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        bool CheckNeightbor(int row, int column, int newRow, int newColumn)
        {
            if (Math.Abs(row - newRow) == 1 && column == newColumn) return true;
            if (Math.Abs(column - newColumn) == 1 && row == newRow) return true;
            return false;
        }
        bool CheckWallJump()
        {
            int row = nextPlayer.Row + nextPlayer.Row - currentPlayer.Row;
            int column = nextPlayer.Column + nextPlayer.Column - currentPlayer.Column;
            if (row < 0 || row > 8 || column < 0 || column > 8) return true;
            return CheckWall(nextPlayer.Row, nextPlayer.Column, row, column);
        }
        bool CheckWall(int row, int column, int newRow, int newColumn)
        {
            if (!CheckNeightbor(row, column, newRow, newColumn)) throw new Exception();
            if (row == newRow)
            {
                column = Math.Min(newColumn, column);
                if (row != 0)
                {
                    if (Board[row - 1][column] == WallType.Vertical) return true;
                }
                if (row != 8)
                {
                    if (Board[row][column] == WallType.Vertical) return true;
                }
            }
            else if (column == newColumn)
            {
                row = Math.Min(newRow, row);
                if (column != 0)
                {
                    if (Board[row][column - 1] == WallType.Horizontal) return true;
                }
                if (column != 8)
                {
                    if (Board[row][column] == WallType.Horizontal) return true;
                }
            }
            return false;
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
