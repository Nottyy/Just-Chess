namespace Just_Chess.Movements
{
    using Just_Chess.Board;
    using Just_Chess.Common;
    using Just_Chess.Figures.Contracts;
    using Just_Chess.Movements.Contracts;
    using System;

    public class NormalPawnMovement : IMovement
    {
        private const string PawnsBackwardsErrorMessage = "Pawns cannot move backwards!";
        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var color = figure.Color;
            var other = figure.Color == ChessColor.White ? ChessColor.Black : ChessColor.White;
            var from = move.From;
            var to = move.To;

            if (color == ChessColor.White && move.To.Row < move.From.Row)
            {
                throw new InvalidOperationException(PawnsBackwardsErrorMessage);
            }

            if (color == ChessColor.Black && move.To.Row > move.From.Row)
            {
                throw new InvalidOperationException(PawnsBackwardsErrorMessage);
            }

            if (color == ChessColor.White)
            {
                if (from.Row + 1 == to.Row && this.CheckDiagonalMove(from,to))
                {
                    if (this.CheckOtherFigureIfValid(board, to, other))
                    {
                        return;
                    }
                }
            }
            else if(color == ChessColor.Black)
            {
                if (from.Row - 1 == to.Row && this.CheckDiagonalMove(from, to))
                {
                    if (this.CheckOtherFigureIfValid(board, to, other))
                    {
                        return;
                    }
                }
            }

            // TODO: add these magic numbers as constants!
            if (from.Row == 2 && color == ChessColor.White) 
            {
                if (from.Row + 2 == to.Row && this.CheckOtherFigureIfValid(board,to, other))
                {
                    return;
                }
            }
            else if (from.Row == 7 && color == ChessColor.Black)
            {
                if (from.Row - 2 == to.Row && this.CheckOtherFigureIfValid(board, to, other))
                {
                    return;
                }
            }

            if (from.Row + 1 == to.Row && color == ChessColor.White)
            {
                if (this.CheckOtherFigureIfValid(board, to, other))
                {
                    return;
                }
            }
            else if (from.Row - 1 == to.Row && color == ChessColor.Black)
            {
                if (this.CheckOtherFigureIfValid(board, to, other))
                {
                    return;
                }
            }

            /////
        }

        private bool CheckOtherFigureIfValid(IBoard board, Position to, ChessColor color)
        {
            var otherFigure = board.GetFigureAtPosition(to);
            if (otherFigure != null && otherFigure.Color == color)
            {
                return false;
            }

            return true;
        }

        private bool CheckDiagonalMove(Position from, Position to)
        {
            return (from.Col + 1 == to.Col || from.Col - 1 == to.Col);
        }
    }
}
