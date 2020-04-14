namespace Just_Chess.Movements
{
    using Just_Chess.Board;
    using Just_Chess.Common;
    using Just_Chess.Figures.Contracts;
    using Just_Chess.Movements.Contracts;
    using System;

    public class NormalPawnMovement : IMovement
    {
        private const string PawnsBackwardsErrorMessage = "Pawns cannot move backwards or stay at the same row!";
        private const string PawnInvalidMove = "Pawns cannot move this way!";
        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var currentFigurCcolor = figure.Color;
            var otherFigureColor = figure.Color == ChessColor.White ? ChessColor.Black : ChessColor.White;
            var from = move.From;
            var to = move.To;

            // Check if the move is backwards or on the same row
            if (currentFigurCcolor == ChessColor.White && move.To.Row <= move.From.Row) 
            {
                throw new InvalidOperationException(PawnsBackwardsErrorMessage);
            }

            if (currentFigurCcolor == ChessColor.Black && move.To.Row >= move.From.Row)
            {
                throw new InvalidOperationException(PawnsBackwardsErrorMessage);
            }

            // Check diagonal move
            if (currentFigurCcolor == ChessColor.White)
            {
                if (from.Row + 1 == to.Row && this.CheckDiagonalMove(from,to))
                {
                    if (this.CheckOtherFigureIfValid(board, to, currentFigurCcolor))
                    {
                        return;
                    }
                }
            }
            else if(currentFigurCcolor == ChessColor.Black)
            {
                if (from.Row - 1 == to.Row && this.CheckDiagonalMove(from, to))
                {
                    if (this.CheckOtherFigureIfValid(board, to, currentFigurCcolor))
                    {
                        return;
                    }
                }
            }

            // TODO: add these magic numbers as constants!
            // Check if pawn can make initial 2 row move
            if (from.Row == 2 && currentFigurCcolor == ChessColor.White) 
            {
                if (from.Row + 2 == to.Row && from.Col == to.Col && this.CheckOtherFigureIfValid(board,to, otherFigureColor))
                {
                    return;
                }
            }
            else if (from.Row == 7 && currentFigurCcolor == ChessColor.Black)
            {
                if (from.Row - 2 == to.Row && from.Col == to.Col && this.CheckOtherFigureIfValid(board, to, otherFigureColor))
                {
                    return;
                }
            }

            if (from.Row + 1 == to.Row && currentFigurCcolor == ChessColor.White)
            {
                if (this.CheckOtherFigureIfValid(board, to, otherFigureColor))
                {
                    return;
                }
            }
            else if (from.Row - 1 == to.Row && currentFigurCcolor == ChessColor.Black)
            {
                if (this.CheckOtherFigureIfValid(board, to, otherFigureColor))
                {
                    return;
                }
            }

            throw new InvalidOperationException(PawnInvalidMove);
            /////
        }

        private bool CheckOtherFigureIfValid(IBoard board, Position to, ChessColor cuurentFigureColor)
        {
            var otherFigure = board.GetFigureAtPosition(to);
            if (otherFigure != null && otherFigure.Color == cuurentFigureColor)
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
