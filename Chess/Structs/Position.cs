using Chess.Classes;
using Chess.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Structs
{
    public struct Position
    {
        public Position(int row, char col)
            : this()
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; private set; }

        public char Col { get; private set; }

        public static Position FromArrayCoordinates(int arrRow, int arrCol, int totalRows)
        {
            return new Position(totalRows - arrRow, (char)(arrCol + 'a'));
        }

        public static Position FromChessCoordinates(int chessRow, char chessCol)
        {
            var newPosition = new Position(chessRow, chessCol);
            CheckIfValid(newPosition);
            return newPosition;
        }

        public static void CheckIfValid(Position position)
        {
            if (position.Row < GlobalConstants.FirstRowNum
                || position.Row > GlobalConstants.LastRowNum)
            {
                string ex = "Selected row position on the board is not valid!";
                Information.AddLog("Exception: " + ex);
                throw new IndexOutOfRangeException(ex);
            }

            if (position.Col < GlobalConstants.FirstColNum
                || position.Col > GlobalConstants.LastColNum)
            {
                string ex = "Selected column position on the board is not valid!";
                Information.AddLog("Exception: " + ex);
                throw new IndexOutOfRangeException(ex);
            }
        }
    }
}
