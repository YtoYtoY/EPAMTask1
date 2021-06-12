using Chess.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Interfaces
{
    public interface IBoard
    {
        int TotalRows { get; }
        int TotalCols { get; }
        void AddFigure(IFigure figure, Position position);
        void RemoveFigure(Position position);
        IFigure GetFigureAtPosition(Position position);
        void MoveFigureAtPosition(IFigure figure, Position from, Position to);
    }
}
