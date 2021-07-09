using System;
using System.Collections.Generic;
using Chess.Enum;
using Chess.Figures;
using Chess.Game;
using Chess.Interfaces;
using Chess.Logging;
using Chess.Structs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProgram.TestGame
{
    [TestClass]
    public class GameUnitTest
    {
        /// <summary>
        /// You can find data about the created game in the logs
        /// </summary>
        [TestMethod]
        public void Board_UnitTest()
        {
            Information.AddLog("***** Testing the start of the game *****");
            var chessEngine = new GameFunction();
            var gameInitializationStrategy = new GameInitialization();

            chessEngine.Initialize(gameInitializationStrategy);
        }

        /// <summary>
        /// Checking the position of the piece on the board and on the player
        /// </summary>
        [TestMethod]
        public void FigureAddOnBoard_UnitTest()
        {
            Information.AddLog("***** Testing adding a figure *****");
            var player = new Player("FigureOnBoard_UnitTest", ChessColor.Black);
            var position = new Position(8, 'a');
            var board = new Board();
            var pawn = new Pawn(ChessColor.Black);

            player.AddFigure(pawn);
            board.AddFigure(pawn, position);
            Assert.AreEqual(board.GetFigureAtPosition(position), pawn);
            Assert.AreEqual(player.figures.Count, 1);
        }

        /// <summary>
        /// Checking the removal of a piece on the board and on the player
        /// </summary>
        [TestMethod]
        public void FigureRemoveFromBoard_UnitTest()
        {
            Information.AddLog("***** Testing removing a figure *****");
            var player = new Player("FigureRemoveFromBoard_UnitTest", ChessColor.Black);
            var board = new Board();
            var position = new Position(8, 'b');
            var king = new King(ChessColor.Black);

            player.AddFigure(king);
            board.AddFigure(king, position);
            player.RemoveFigure(king);
            board.RemoveFigure(position);

            Assert.AreEqual(board.GetFigureAtPosition(position), null);
            Assert.AreEqual(player.figures.Count, 0);
            
        }
    }
}
