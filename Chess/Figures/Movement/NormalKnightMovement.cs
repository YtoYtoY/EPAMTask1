using Chess.Interfaces;
using Chess.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Figures.Movement
{
    public class NormalKnightMovement : IMovement
    {
        private const string KnightInvalidMove = "{0}s cannot move this way!";

        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var rowDistance = Math.Abs(move.From.Row - move.To.Row);
            var colDistance = Math.Abs(move.From.Col - move.To.Col);
            var color = figure.Color;
            var to = move.To;
            var figureAtPosition = board.GetFigureAtPosition(to);

            if (figureAtPosition == null || color != figureAtPosition.Color)
            {
                if (rowDistance == 2 && colDistance == 1)
                {
                    return;
                }
                else if (colDistance == 2 && rowDistance == 1)
                {
                    return;
                }
            }

            throw new InvalidOperationException(KnightInvalidMove);
        }
    }
}
