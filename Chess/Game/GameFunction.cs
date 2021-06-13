using Chess.Classes;
using Chess.Enum;
using Chess.Interfaces;
using Chess.Logging;
using Chess.Structs;
using Chess.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Game
{
    public class GameFunction : IGameFunction
    {
        private readonly IBoard board;
        public string Command { get; private set; }
        private readonly IMovementStrategy movementStrategy;

        private IList<IPlayer> players;

        private int currentPlayerIndex;

        public GameFunction()
        {
            movementStrategy = new NormalMovementStrategy();
            board = new Board();
        }

        public IEnumerable<IPlayer> Players
        {
            get
            {
                return new List<IPlayer>(players);
            }
        }
        public IBoard Board
        {
            get
            {
                return this.Board;
            }
        }

        public void Initialize(IGameInitialization gameInitializationStrategy)
        {
            players = new List<IPlayer>
            {
                new Player("1", ChessColor.Black),
                new Player("2", ChessColor.White)
            };

            SetFirstPlayerIndex();
            gameInitializationStrategy.Initialize(this.players, this.board);
        }

        public void Start()
        {
            while (true)
            {
                IFigure figure = null;
                try
                {
                    var player = GetNextPlayer();
                    var move = InputHandler.CreateMoveFromCommand(Command);
                    var from = move.From;
                    var to = move.To;
                    figure = board.GetFigureAtPosition(from);
                    CheckIfPlayerOwnsFigure(player, figure, from);
                    CheckIfToPositionIsEmpty(figure, to);

                    var availableMovements = figure.Move(movementStrategy);
                    ValidateMovements(figure, availableMovements, move);

                    board.MoveFigureAtPosition(figure, from, to);
                }
                catch (Exception ex)
                {
                    Information.AddLog(ex.Message);
                    currentPlayerIndex--;
                }
            }
        }

        public void WinningConditions()
        {
            throw new NotImplementedException();
        }

        public void ValidateMovements(IFigure figure, IEnumerable<IMovement> availableMovements, Move move)
        {
            var validMoveFound = false;
            var foundException = new Exception();
            foreach (var movement in availableMovements)
            {
                try
                {
                    movement.ValidateMove(figure, board, move);
                    validMoveFound = true;
                    break;
                }
                catch (Exception ex)
                {
                    Information.AddLog(ex.Message);
                    foundException = ex;
                }
            }

            if (!validMoveFound)
            {
                throw foundException;
            }
        }

        private void SetFirstPlayerIndex()
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Color == ChessColor.White)
                {
                    currentPlayerIndex = i - 1;
                    return;
                }
            }
        }

        private IPlayer GetNextPlayer()
        {
            currentPlayerIndex++;
            if (currentPlayerIndex >= players.Count)
            {
                currentPlayerIndex = 0;
            }

            return players[currentPlayerIndex];
        }

        public void CheckIfPlayerOwnsFigure(IPlayer player, IFigure figure, Position from)
        {
            if (figure == null)
            {
                string ex = string.Format("Position {0}{1} is empty!", from.Col, from.Row);
                Information.AddLog(ex);
                throw new InvalidOperationException(ex);
            }

            if (figure.Color != player.Color)
            {
                string ex = string.Format("Figure at {0}{1} is not yours!", from.Col, from.Row);
                Information.AddLog(ex);
                throw new InvalidOperationException(ex);
            }
        }

        public void CheckIfToPositionIsEmpty(IFigure figure, Position to)
        {
            var figureAtPosition = board.GetFigureAtPosition(to);
            if (figureAtPosition != null && figureAtPosition.Color == figure.Color)
            {
                throw new InvalidOperationException(string.Format("You already have a figure at {0}{1}!", to.Col, to.Row));
            }
        }
    }
}
