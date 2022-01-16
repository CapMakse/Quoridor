using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quoridor
{
    interface IBot
    {
        IMove GetMove();
    }
    class RandomBot : IBot
    {
        Game game;
        public RandomBot(Game game)
        {
            this.game = game;
        }
        public IMove GetMove()
        {
            Random rnd = new Random();
            if (game.currentPlayer.CountOfWalls != 0 && rnd.Next() % 4 == 0)
            {
                while (true)
                {
                    int row = rnd.Next() % 8;
                    int column = rnd.Next() % 8;
                    bool vertical = rnd.Next() % 2 == 0;
                    if (game.CheckLegalWall(row, column, vertical)) return new WallMove() { Column = column, Row = row, Vertical = vertical };
                }
            }
            List<FigureMove> moves = new List<FigureMove>();
            if (game.CheckNeightbor(game.currentPlayer.Row, game.currentPlayer.Column, game.nextPlayer.Row, game.nextPlayer.Column))
            {
                for (int i = -1; i < 2; i+=2)
                {
                    if (game.CheckLegalFigureMove(game.nextPlayer.Row + i, game.nextPlayer.Column)) moves.Add(new FigureMove() { Row = game.nextPlayer.Row + i, Column = game.nextPlayer.Column });
                    if (game.CheckLegalFigureMove(game.nextPlayer.Row, game.nextPlayer.Column + i)) moves.Add(new FigureMove() { Row = game.nextPlayer.Row, Column = game.nextPlayer.Column + i });
                }
            }
            for (int i = -1; i < 2; i += 2)
            {
                if (game.CheckLegalFigureMove(game.currentPlayer.Row + i, game.currentPlayer.Column)) moves.Add(new FigureMove() { Row = game.currentPlayer.Row + i, Column = game.currentPlayer.Column });
                if (game.CheckLegalFigureMove(game.currentPlayer.Row, game.currentPlayer.Column + i)) moves.Add(new FigureMove() { Row = game.currentPlayer.Row, Column = game.currentPlayer.Column + i });
            }
            return moves[rnd.Next() % moves.Count()];
        }
    }
    interface IMove 
    {
        int Row { get; set; }
        int Column { get; set; }
    }
    class WallMove : IMove
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public bool Vertical { get; set; }
    }
    class FigureMove : IMove
    {
        public int Row { get; set; }
        public int Column { get; set; }
    }
}
