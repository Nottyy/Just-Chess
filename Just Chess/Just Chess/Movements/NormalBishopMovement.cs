namespace Just_Chess.Movements
{
    using Just_Chess.Board;
    using Just_Chess.Common;
    using Just_Chess.Figures.Contracts;
    using Just_Chess.Movements.Contracts;
    using System;

    public class NormalBishopMovement : IMovement
    {

        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var rowDistance = Math.Abs(move.From.Row - move.To.Row);
            var colDistance = Math.Abs(move.From.Col - move.To.Col);

            if (rowDistance != colDistance)
            {
                throw new InvalidOperationException(string.Format(GlobalErrorMessages.InvalidMove, figure.GetType().Name));
            }

            var from = move.From;
            var to = move.To;

            int rowIndex = from.Row;
            char collIndex = from.Col;

            var rowDirection = to.Row > from.Row ? 1 : -1;
            var colDirection = to.Col > from.Col ? 1 : -1;

            //top-right
            while (true)
            {
                rowIndex += rowDirection;
                collIndex += (char)colDirection;

                // This is the finish position of the movement(TO position)
                // We already check if the position we want to move is owned by our figure, which means we always can move as there can be only opponent figure or null at this position
                if (rowIndex == to.Row && collIndex == to.Col)
                {
                    return;
                }

                var position = Position.FromChessCoordinates(rowIndex, collIndex);

                if (board.CheckIfThereIsFigureAtPosition(position))
                {
                    throw new InvalidOperationException("There is a figure on your way!");
                }
            }
        }
    }
}
