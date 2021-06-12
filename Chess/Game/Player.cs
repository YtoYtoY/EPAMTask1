using Chess.Classes;
using Chess.Enum;
using Chess.Interfaces;
using Chess.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Game
{
    public class Player : IPlayer
    {
        public string Name { get; private set; }
        public ChessColor Color { get; private set; }

        private readonly ICollection<IFigure> figures;

        public Player(string name, ChessColor color)
        {
            Name = name;
            figures = new List<IFigure>();
            Color = color;
            Information.AddLog("New " + color.ToString() + "chess player: " + name);
        }

        public void AddFigure(IFigure figure)
        {
            ObjectValidator.CheckIfObjectIsNull(figure, GlobalErrorMessages.NullFigureErrorMessage);
            this.CheckIfFigureExists(figure);
            this.figures.Add(figure);
        }

        public void RemoveFigure(IFigure figure)
        {
            ObjectValidator.CheckIfObjectIsNull(figure, GlobalErrorMessages.NullFigureErrorMessage);
            this.CheckIfFigureDoesNotExist(figure);
            this.figures.Remove(figure);
        }

        private void CheckIfFigureExists(IFigure figure)
        {
            if (this.figures.Contains(figure))
            {
                string ex = Name + ": This player already owns this figure!";
                Information.AddLog(ex + " - " +figure.ToString());
                throw new InvalidOperationException(ex);
            }
        }

        private void CheckIfFigureDoesNotExist(IFigure figure)
        {
            if (!this.figures.Contains(figure))
            {
                string ex = Name + ": This player does not own this figure!";
                Information.AddLog(ex + " - " + figure.ToString());
                throw new InvalidOperationException(ex);
            }
        }
    }
}
