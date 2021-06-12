using Chess.Classes;
using Chess.Figures;
using Chess.Interfaces;
using Chess.Logging;
using Chess.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Game
{
    public class GameInitialization : IGameInitialization
    {
        private const int BoardTotalRowsAndCols = 8;

        private readonly IList<Type> figureTypes;

        public GameInitialization()
        {
            this.figureTypes = new List<Type>
            {
                typeof(Rook),
                typeof(Knight),
                typeof(Bishop),
                typeof(Queen),
                typeof(King),
                typeof(Bishop),
                typeof(Knight),
                typeof(Rook)
            };
        }

        public void Initialize(IList<IPlayer> players, IBoard board)
        {
            this.ValidateStrategy(players, board);

            var firstPlayer = players[0];
            var secondPlayer = players[1];

            this.AddArmyToBoardRow(firstPlayer, board, 8);
            this.AddPawnsToBoardRow(firstPlayer, board, 7);

            this.AddPawnsToBoardRow(secondPlayer, board, 2);
            this.AddArmyToBoardRow(secondPlayer, board, 1);
            Information.AddLog("Game created");
        }

        private void AddPawnsToBoardRow(IPlayer player, IBoard board, int chessRow)
        {
            for (int i = 0; i < BoardTotalRowsAndCols; i++)
            {
                var pawn = new Pawn(player.Color);
                player.AddFigure(pawn);
                var position = new Position(chessRow, (char)(i + 'a'));
                board.AddFigure(pawn, position);
            }
            Information.AddLog("Pawns added");
        }

        private void AddArmyToBoardRow(IPlayer player, IBoard board, int chessRow)
        {
            for (int i = 0; i < BoardTotalRowsAndCols; i++)
            {
                var figureType = this.figureTypes[i];
                var figureInstance = (IFigure)Activator.CreateInstance(figureType, player.Color);
                player.AddFigure(figureInstance);
                var position = new Position(chessRow, (char)(i + 'a'));
                board.AddFigure(figureInstance, position);
            }
            Information.AddLog("Army added");
        }

        private void ValidateStrategy(ICollection<IPlayer> players, IBoard board)
        {
            if (players.Count != 2)
            {
                string ex = "Standard Start Game Initialization Strategy needs exactly two players!";
                Information.AddLog("Exception: " + ex);
                throw new InvalidOperationException(ex);
            }

            if (board.TotalRows != BoardTotalRowsAndCols || board.TotalCols != BoardTotalRowsAndCols)
            {
                string ex = "Standard Start Game Initialization Strategy needs 8x8 board!";
                Information.AddLog("Exception: " + ex);
                throw new InvalidOperationException(ex);
            }
        }
    }
}
