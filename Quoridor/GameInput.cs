using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quoridor
{
    class GameInput
    {
        Game game;
        public GameInput(Game game)
        {
            this.game = game;

        }

        public Player GetCurrentPlayer()
        {
            return game.currentPlayer;
        }
        public Player GetNextPlayer()
        {
            return game.nextPlayer;
        }
        public bool GameEnd()
        {
            return game.gameEnd;
        }
        public bool TryPutWall(int row, int column, bool vertical)
        {
            return game.TryPutWall(row, column, vertical);
        }
        public bool TryMoveFigure(int row, int column)
        {
            return game.TryMoveFigure(row, column);
        }
        public bool TryMove(string move)
        {
            string[] parametr = move.Split(new char[] { ' ' });
            if (parametr.Length != 2) return false;
            if (parametr[0] == "jump" || parametr[0] == "move")
            {
                if (parametr[1].Length == 2)
                {
                    char[] param = parametr[1].ToCharArray();
                    if (Char.IsUpper(param[0]) && Char.IsDigit(param[1]))
                    {
                        return TryMoveFigure(param[0] - 'A', (int)Char.GetNumericValue(param[1]) - 1);
                    }
                }
            }
            if (parametr[0] == "wall")
            {
                if (parametr[1].Length == 3)
                {
                    char[] param = parametr[1].ToCharArray();
                    if (Char.IsUpper(param[0]) && Char.IsDigit(param[1]) && (param[2] == 'v' || param[2] == 'h'))
                    {
                        return TryPutWall(param[0] - 'S', (int)Char.GetNumericValue(param[1]) - 1, param[2] == 'v');
                    }
                }
            }
            return false;
        }
    }
}
