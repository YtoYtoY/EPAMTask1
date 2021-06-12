using Chess.Classes;
using Chess.Enum;
using Chess.Interfaces;
using Chess.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Game
{
    public class GameFunction : IGameFunction
    {
        private readonly IInputProvider input;
        private readonly IBoard board;
        private readonly IMovementStrategy movementStrategy;

        private IList<IPlayer> players;

        private int currentPlayerIndex;

        public GameFunction(IInputProvider inputProvider)
        {
            this.input = inputProvider;
            this.movementStrategy = new NormalMovementStrategy();
            this.board = new Board();
        }

        public IEnumerable<IPlayer> Players
        {
            get
            {
                return new List<IPlayer>(this.players);
            }
        }

        public void Initialize(IGameInitialization gameInitializationStrategy)
        {
            // TODO: remove using JustChess.Players and use the input for players
            // TODO: BUG: if players are changed - board is reversed
            this.players = new List<IPlayer>
            {
                new Player("1", ChessColor.Black),
                new Player("2", ChessColor.White)
            }; // this.input.GetPlayers(GlobalConstants.StandardGameNumberOfPlayers);

            this.SetFirstPlayerIndex();
            gameInitializationStrategy.Initialize(this.players, this.board);
        }

        public void Start()
        {
            while (true)
            {
                IFigure figure = null;
                try
                {
                    var player = this.GetNextPlayer();
                    var move = this.input.GetNextPlayerMove(player);
                    var from = move.From;
                    var to = move.To;
                    figure = this.board.GetFigureAtPosition(from);
                    this.CheckIfPlayerOwnsFigure(player, figure, from);
                    this.CheckIfToPositionIsEmpty(figure, to);

                    var availableMovements = figure.Move(this.movementStrategy);
                    this.ValidateMovements(figure, availableMovements, move);

                    this.board.MoveFigureAtPosition(figure, from, to);
                }
                catch (Exception ex)
                {
                    this.currentPlayerIndex--;
                }
            }
        }

        public void WinningConditions()
        {
            throw new NotImplementedException();
        }

        private void ValidateMovements(IFigure figure, IEnumerable<IMovement> availableMovements, Move move)
        {
            var validMoveFound = false;
            var foundException = new Exception();
            foreach (var movement in availableMovements)
            {
                try
                {
                    movement.ValidateMove(figure, this.board, move);
                    validMoveFound = true;
                    break;
                }
                catch (Exception ex)
                {
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
            for (int i = 0; i < this.players.Count; i++)
            {
                if (this.players[i].Color == ChessColor.White)
                {
                    this.currentPlayerIndex = i - 1;
                    return;
                }
            }
        }

        private IPlayer GetNextPlayer()
        {
            this.currentPlayerIndex++;
            if (this.currentPlayerIndex >= this.players.Count)
            {
                this.currentPlayerIndex = 0;
            }

            return this.players[this.currentPlayerIndex];
        }

        private void CheckIfPlayerOwnsFigure(IPlayer player, IFigure figure, Position from)
        {
            if (figure == null)
            {
                throw new InvalidOperationException(string.Format("Position {0}{1} is empty!", from.Col, from.Row));
            }

            if (figure.Color != player.Color)
            {
                throw new InvalidOperationException(string.Format("Figure at {0}{1} is not yours!", from.Col, from.Row));
            }
        }

        private void CheckIfToPositionIsEmpty(IFigure figure, Position to)
        {
            var figureAtPosition = this.board.GetFigureAtPosition(to);
            if (figureAtPosition != null && figureAtPosition.Color == figure.Color)
            {
                throw new InvalidOperationException(string.Format("You already have a figure at {0}{1}!", to.Col, to.Row));
            }
        }
    }
}
