using System;
using System.Collections.Generic;
using Chess.Classes;
using Chess.Enum;
using Chess.Figures;
using Chess.Game;
using Chess.Interfaces;
using Chess.Logging;
using Chess.Structs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProgram.TestFigures
{
    [TestClass]
    public class KnightTest
    {

        private IMovementStrategy movementStrategy;
        private IList<IPlayer> players;
        private IBoard board;

        IFigure knight;
        IFigure pawn;

        public void ForTest()
        {
            movementStrategy = new NormalMovementStrategy();
            board = new Board();
            players = new List<IPlayer>
            {
                new Player("1", ChessColor.Black),
                new Player("2", ChessColor.White)
            };
            knight = new Knight(ChessColor.White);
            pawn = new Pawn(ChessColor.Black);
            board.AddFigure(knight, new Position(2, 'c'));
            players[1].AddFigure(knight);

            board.AddFigure(pawn, new Position(6, 'e'));
            players[0].AddFigure(pawn);
        }

        [TestMethod]
        public void KnightFalseMovable_UnitTest()
        {
            Information.AddLog("***** Testing wrong move knight *****");
            var game = new GameFunction();
            ForTest();
            IFigure figure;
            try
            {
                var move = InputHandler.CreateMoveFromCommand("c2-e6");
                var from = move.From;
                var to = move.To;

                figure = board.GetFigureAtPosition(from);
                game.CheckIfPlayerOwnsFigure(players[1], figure, from);
                game.CheckIfToPositionIsEmpty(figure, to);

                var availableMovements = figure.Move(movementStrategy);
                game.ValidateMovements(figure, availableMovements, move);

                board.MoveFigureAtPosition(figure, from, to);
            }
            catch (Exception ex)
            {
                Information.AddLog(ex.Message);
                Assert.AreEqual(board.GetFigureAtPosition(new Position(2, 'c')), knight);
                Assert.AreEqual(board.GetFigureAtPosition(new Position(6, 'e')), pawn);
            }
        }

        [TestMethod]
        public void KnightTrueMovableAndAttack_UnitTest()
        {
            Information.AddLog("***** Testing correct move knight *****");
            var game = new GameFunction();
            ForTest();
            IFigure figure;
            string[] moveCommands = { "c2-d4", "d4-e6" };
            int index = 0;
            while (index < 2)
            {
                var move = InputHandler.CreateMoveFromCommand(moveCommands[index]);
                var from = move.From;
                var to = move.To;

                figure = board.GetFigureAtPosition(from);
                game.CheckIfPlayerOwnsFigure(players[1], figure, from);
                game.CheckIfToPositionIsEmpty(figure, to);

                var availableMovements = figure.Move(movementStrategy);
                game.ValidateMovements(figure, availableMovements, move);

                board.MoveFigureAtPosition(figure, from, to);
                index++;
            }
            Assert.AreEqual(board.GetFigureAtPosition(new Position(6, 'e')), knight);
        }
    }
}
