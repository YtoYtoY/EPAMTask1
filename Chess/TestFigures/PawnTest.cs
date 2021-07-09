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
    public class PawnTest
    {
        private IMovementStrategy movementStrategy;
        private IList<IPlayer> players;
        private IBoard board;

        IFigure pawn1;
        IFigure pawn2;

        public void ForTest()
        {
            movementStrategy = new NormalMovementStrategy();
            board = new Board();
            players = new List<IPlayer>
            {
                new Player("1", ChessColor.Black),
                new Player("2", ChessColor.White)
            };
            pawn1 = new Pawn(ChessColor.White);
            pawn2 = new Pawn(ChessColor.Black);
            board.AddFigure(pawn1, new Position(1, 'c'));
            players[1].AddFigure(pawn1);

            board.AddFigure(pawn2, new Position(3, 'd'));
            players[0].AddFigure(pawn2);
        }

        [TestMethod]
        public void PawnFalseMovable_UnitTest()
        {
            Information.AddLog("***** Testing wrong move pawn *****");
            var game = new GameFunction();
            ForTest();
            IFigure figure;
            try
            {
                var move = InputHandler.CreateMoveFromCommand("c1-d3");
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
                Assert.AreEqual(board.GetFigureAtPosition(new Position(1, 'c')), pawn1);
                Assert.AreEqual(board.GetFigureAtPosition(new Position(3, 'd')), pawn2);
            }
        }

        [TestMethod]
        public void PawnTrueMovableAndAttack_UnitTest()
        {
            Information.AddLog("***** Testing correct move pawn *****");
            var game = new GameFunction();
            ForTest();
            IFigure figure;
            string[] moveCommands = { "c1-c2", "c2-d3" };
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
            Assert.AreEqual(board.GetFigureAtPosition(new Position(3, 'd')), pawn1);
        }
    }
}
