namespace Just_Chess.Movements
{
    using Just_Chess.Board;
    using Just_Chess.Common;
    using Just_Chess.Figures.Contracts;
    using Just_Chess.Movements.Contracts;
    using System;

    public class NormalKnightMovement : IMovement
    {
        private const string InvalidKnightMovement = "Knights cannot move this way!";
        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var from = move.From;
            var to = move.To;

            var rowDistance = Math.Abs(from.Row - to.Row);
            var colDistance = Math.Abs(from.Col - to.Col);

            if (rowDistance == 2 && colDistance == 1)
            {
                return;
            }
            else if (rowDistance == 1 && colDistance == 2)
            {
                return;
            }

            throw new InvalidOperationException(InvalidKnightMovement);
        }
    }
}
