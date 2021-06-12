using Chess.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Interfaces
{
    public interface IPlayer
    {
        string Name { get; }
        ChessColor Color { get; }
        void AddFigure(IFigure figure);
        void RemoveFigure(IFigure figure);
    }
}
