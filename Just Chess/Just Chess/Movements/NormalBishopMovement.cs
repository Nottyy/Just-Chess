namespace Just_Chess.Movements
{
    using Just_Chess.Board;
    using Just_Chess.Common;
    using Just_Chess.Figures.Contracts;
    using Just_Chess.Movements.Contracts;
    using System;

    public class NormalBishopMovement : IMovement
    {
        private const string BishopInvalidMove = "Bishops cannot move this way!";

        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var rowDistance = Math.Abs(move.From.Row - move.To.Row);
            var colDistance = Math.Abs(move.From.Col - move.To.Col);

            if (rowDistance != colDistance)
            {
                throw new InvalidOperationException(BishopInvalidMove);
            }

            var from = move.From;
            var to = move.To;

            int rowIndex = from.Row;
            char collIndex = from.Col;

            //top-right
            while (true)
            {
                rowIndex++;
                collIndex++;

                this.CheckDiagonalDirections(rowIndex, collIndex, to, board);
            }
        }

        private void CheckDiagonalDirections(int rowIndex, char colIndex, Position to, IBoard board)
        {
            // This is the finish position of the movement (TO position)
            if (rowIndex == to.Row && colIndex == to.Col)
            {
                return;
            }

            var position = Position.FromChessCoordinates(rowIndex, colIndex);
            var figureAtPosition = board.GetFigureAtPosition(position);

            if (figureAtPosition != null)
            {
                throw new InvalidOperationException("There is a figure on your way!");
            }
        }
    }
}
