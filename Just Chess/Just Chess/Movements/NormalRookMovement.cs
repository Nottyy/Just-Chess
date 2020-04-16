namespace Just_Chess.Movements
{
    using Just_Chess.Board;
    using Just_Chess.Common;
    using Just_Chess.Figures.Contracts;
    using Just_Chess.Movements.Contracts;
    using System;

    public class NormalRookMovement : IMovement
    {
        private const string RookInvalidMove = "Rooks cannot move this way!";
        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var from = move.From;
            var to = move.To;

            if (from.Col != to.Col && from.Row != to.Row)
            {
                throw new InvalidOperationException(RookInvalidMove);
            }

            var colDirection = to.Row == from.Row ? (to.Col > from.Col ? 1 : -1) : from.Col;
            var rowDirection = to.Col == from.Col ? (to.Row > from.Row ? 1 : -1) : from.Row;

            var rowIndex = from.Row;
            var colIndex = from.Col;
            
            while (true)
            {
                if (to.Row == from.Row)
                {
                    colIndex += (char)colDirection;
                }
                else
                {
                    rowIndex += rowDirection;
                }

                if (rowIndex == to.Row && colIndex == to.Col)
                {
                    return;
                }

                var position = new Position(rowIndex, colIndex);
                
                if (board.CheckIfThereIsFigureAtPosition(position))
                {
                    throw new InvalidOperationException("There is a figure on your way!");
                }
            }
        }
    }
}
