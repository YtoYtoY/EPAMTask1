using Chess.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Interfaces
{
    public interface IFigure
    {
        ChessColor Color { get; }
        ICollection<IMovement> Move(IMovementStrategy movementStrategy);
    }
}
