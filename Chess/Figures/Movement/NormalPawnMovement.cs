﻿using Chess.Enum;
using Chess.Interfaces;
using Chess.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Figures.Movement
{
    public class NormalPawnMovement : IMovement
    {
        private const string PawnBackwardsErrorMessage = "{0}s cannot move backwards!";
        private const string PawnInvalidMove = "{0}s cannot move this way!";

        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var color = figure.Color;
            var other = figure.Color == ChessColor.White ? ChessColor.Black : ChessColor.White;
            var from = move.From;
            var to = move.To;
            var figureAtPosition = board.GetFigureAtPosition(to);

            if (color == ChessColor.White && to.Row < from.Row)
            {
                throw new InvalidOperationException(PawnBackwardsErrorMessage);
            }

            if (color == ChessColor.Black && to.Row > from.Row)
            {
                throw new InvalidOperationException(PawnBackwardsErrorMessage);
            }

            if (color == ChessColor.White)
            {
                int p = from.Row;
                int k = to.Row;
                if (from.Row + 1 == to.Row && this.CheckDiagonalMove(from, to))
                {
                    if (this.CheckOtherFigureIfValid(board, to, other))
                    {
                        return;
                    }
                }

                if (from.Row == 2 && from.Col == to.Col)
                {
                    if (from.Row + 2 == to.Row && figureAtPosition == null)
                    {
                        return;
                    }
                }

                if (from.Row + 1 == to.Row && from.Col == to.Col)
                {
                    if (figureAtPosition == null)
                    {
                        return;
                    }
                }
            }
            else if (color == ChessColor.Black)
            {
                if (from.Row - 1 == to.Row && this.CheckDiagonalMove(from, to))
                {
                    if (this.CheckOtherFigureIfValid(board, to, other))
                    {
                        return;
                    }
                }

                if (from.Row == 7 && from.Col == to.Col)
                {
                    if (from.Row - 2 == to.Row && figureAtPosition == null)
                    {
                        return;
                    }
                }

                if (from.Row - 1 == to.Row && from.Col == to.Col)
                {
                    if (figureAtPosition == null)
                    {
                        return;
                    }
                }
            }

            throw new InvalidOperationException(PawnInvalidMove);
        }

        private bool CheckOtherFigureIfValid(IBoard board, Position to, ChessColor color)
        {
            var otherFigure = board.GetFigureAtPosition(to);
            if (otherFigure != null && otherFigure.Color == color)
            {
                return true;
            }

            return false;
        }

        private bool CheckDiagonalMove(Position from, Position to)
        {
            char p = (char)(from.Col + 1);
            char k = to.Col;
            return from.Col + 1 == to.Col || from.Col - 1 == to.Col;
        }
    }
}
