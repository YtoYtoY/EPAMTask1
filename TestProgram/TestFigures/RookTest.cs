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
    public class RookTest
    {
        private IMovementStrategy movementStrategy;
        private IList<IPlayer> players;
        private IBoard board;

        IFigure rook;
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
            rook = new Rook(ChessColor.White);
            pawn = new Pawn(ChessColor.Black);
            board.AddFigure(rook, new Position(1, 'c'));
            players[1].AddFigure(rook);

            board.AddFigure(pawn, new Position(8, 'f'));
            players[0].AddFigure(pawn);
        }

        [TestMethod]
        public void RookFalseMovable_UnitTest()
        {
            Information.AddLog("***** Testing wrong move rook *****");
            var game = new GameFunction();
            ForTest();
            IFigure figure;
            try
            {
                var move = InputHandler.CreateMoveFromCommand("c1-h6");
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
                Assert.AreEqual(board.GetFigureAtPosition(new Position(1, 'c')), rook);
            }
        }

        [TestMethod]
        public void RookTrueMovableAndAttack_UnitTest()
        {
            Information.AddLog("***** Testing correct move rook *****");
            var game = new GameFunction();
            ForTest();
            IFigure figure;
            string[] moveCommands = { "c1-c8", "c8-f8" };
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
            Assert.AreEqual(board.GetFigureAtPosition(new Position(8, 'f')), rook);
        }
    }
}
