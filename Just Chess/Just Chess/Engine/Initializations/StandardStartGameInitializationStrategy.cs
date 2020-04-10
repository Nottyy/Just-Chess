namespace Just_Chess.Engine.Initializations
{
    using System;
    using Just_Chess.Board;
    using Just_Chess.Figures;
    using Just_Chess.Players.Contracts;
    using System.Collections.Generic;
    using Just_Chess.Common;
    using Just_Chess.Figures.Contracts;

    public class StandardStartGameInitializationStrategy : IGameInitializationStrategy
    {
        private const int BoardTotalRowsAndCols = 8;

        private IList<Type> figureTypes;

        public StandardStartGameInitializationStrategy()
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

            // First player army row (8th);
            this.AddArmyToBoardRow(firstPlayer, board, 8);
            // First player pawns row (7th);
            this.AddPawnsToBoardRow(firstPlayer, board, 7);

            // First Player army row (1st)
            this.AddArmyToBoardRow(secondPlayer, board, 1);
            // Second player pawns row (2th);
            this.AddPawnsToBoardRow(secondPlayer, board, 2);
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
        }

        private void ValidateStrategy(ICollection<IPlayer> players, IBoard board)
        {
            if (players.Count != GlobalConstants.StandardGameNumberOfPlayers)
            {
                throw new InvalidOperationException("Standard Start Game Initialization Strategy needs exactly 2 players!");
            }

            if (board.TotalRows != BoardTotalRowsAndCols || board.TotalCols != BoardTotalRowsAndCols)
            {
                throw new InvalidOperationException("Standard Start Game Initialization Strategy needs 8x8 board!");
            }
        }
    }
}
