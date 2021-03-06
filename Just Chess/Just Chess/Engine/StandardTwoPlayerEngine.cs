﻿namespace Just_Chess.Engine.Contracts
{
    using System;
    using System.Linq;
    using Just_Chess.Common;
    using Just_Chess.Board;
    using Just_Chess.Engine.Initializations;
    using Just_Chess.InputProviders.Contracts;
    using Just_Chess.Players.Contracts;
    using Just_Chess.Renderers.Contracts;
    using System.Collections.Generic;
    using Just_Chess.Players;
    using Just_Chess.Figures.Contracts;
    using Just_Chess.Movements.Contracts;
    using Just_Chess.Movements.Strategies;
    using System.Collections;

    public class StandardTwoPlayerEngine : IChessEngine
    {
        private IList<IPlayer> players;
        private readonly IRenderer renderer;
        private readonly IInputProvider input;
        private readonly IBoard board;
        private readonly IMovementStrategy strategy;

        private int currentPlayerIndex;

        public StandardTwoPlayerEngine(IRenderer renderer, IInputProvider inputProvider)
        {
            this.renderer = renderer;
            this.input = inputProvider;
            this.board = new Board();
            this.strategy = new NormalMovementStrategy();
        }

        public IEnumerable<IPlayer> Players
        {
            get
            {
                return new List<IPlayer>(this.players);
            }
        }

        public void Initialize(IGameInitializationStrategy gameInitializationStrategy)
        {
            // TODO: remove using Just_Chess.Players; and use input
            this.players = new List<IPlayer>
            {
                new Player("GoshoBlack", ChessColor.Black),
                new Player("PeshoWhite", ChessColor.White)
            };

            this.GetFirstPlayerIndex();
            //this.input.GetPlayers(GlobalConstants.StandardGameNumberOfPlayers);
            gameInitializationStrategy.Initialize(this.players, this.board);
            this.renderer.RenderBoard(board);
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var player = this.GetNextPlayer();
                    var move = this.input.GetNextPlayerMove(player);
                    var from = move.From;
                    var to = move.To;
                    var figure = this.board.GetFigureAtPosition(from);
                    this.CheckIfPlayerOwnsFigure(player, figure, from);
                    this.CheckIfToPositionIsEmpty(figure, to);

                    var availableMovements = figure.Move(this.strategy);
                    this.ValidateMoves(availableMovements, figure, move);

                    board.MoveFigureAtPosition(figure, from, to);
                    this.renderer.RenderBoard(board);

                    // TODO: If not castle - move figure ( check castle - check if castle is valid, check pawn for An-Pasa.
                    // TODO: Check check
                    // TODO: If in check - check checkmate
                    // TODO: if not in check - check draw
                    // TODO: Continue
                }
                catch (Exception ex)
                {
                    this.currentPlayerIndex--;
                    this.renderer.PrintErrorMessage(ex.Message);
                }
            }
        }

        private void ValidateMoves(IEnumerable<IMovement> availableMovements, IFigure figure, Move move)
        {
            bool isMoveValid = false;
            var exceptionFound = new Exception();

            foreach (var movement in availableMovements)
            {
                try
                {
                    movement.ValidateMove(figure, this.board, move);
                    isMoveValid = true;
                    break;
                }
                catch (Exception ex)
                {
                    exceptionFound = ex;
                }
            }

            if (!isMoveValid)
            {
                throw exceptionFound;
            }
        }


        public bool? WinningConditions()
        {
            throw new System.NotImplementedException();
        }

        private void GetFirstPlayerIndex()
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
                throw new InvalidOperationException(string.Format("You already have figure at position {0}{1}!", to.Col, to.Row));
            }
        }
    }
}
