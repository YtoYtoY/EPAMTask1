using Chess.Enum;
using Chess.Interfaces;
using Chess.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes
{
    public abstract class Figure : IFigure
    {
        public ChessColor Color { get; private set; }
        protected Figure(ChessColor color)
        {
            Color = color;
            Information.AddLog("Created " + color + " figure - " + this.GetType().Name);
        }
        public abstract ICollection<IMovement> Move(IMovementStrategy strategy);
        public override string ToString()
        {
            return Color.ToString() + "; " + this.GetType().Name;
        }
    }
}
