using Chess.Logging;
using Chess.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes
{
    public static class InputHandler
    {
        public static Move CreateMoveFromCommand(string command)
        {
            var positionAsStringParts = command.Split('-');
            if (positionAsStringParts.Length != 2)
            {
                string ex = "Invalid command!";
                Information.AddLog("Exception: " + ex);
                throw new InvalidOperationException(ex);
            }

            var fromAsString = positionAsStringParts[0];
            var toAsString = positionAsStringParts[1];

            var fromPosition = Position.FromChessCoordinates(fromAsString[1] - '0', fromAsString[0]);
            var toPosition = Position.FromChessCoordinates(toAsString[1] - '0', toAsString[0]);

            return new Move(fromPosition, toPosition);
        }
    }
}
