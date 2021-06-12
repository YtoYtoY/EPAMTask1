using Chess.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Interfaces
{
    public interface IMovement
    {
        void ValidateMove(IFigure figure, IBoard board, Move move);
    }
}
