namespace Just_Chess.Movements
{
    using Just_Chess.Board;
    using Just_Chess.Common;
    using Just_Chess.Figures.Contracts;
    using Just_Chess.Movements.Contracts;
    using System;

    // TODO: add pawn at last row logic
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

            // Check normal pawn move
            if (from.Row + 1 == to.Row && from.Col == to.Col && currentFigurCcolor == ChessColor.White)
            {
                if (!this.CheckIfThereIsOpponentFigureAtPostion(board, to, currentFigurCcolor))
                {
                    return;
                }
            }
            else if (from.Row - 1 == to.Row && from.Col == to.Col && currentFigurCcolor == ChessColor.Black)
            {
                if (!this.CheckIfThereIsOpponentFigureAtPostion(board, to, currentFigurCcolor))
                {
                    return;
                }
            }

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
                    if (this.CheckIfThereIsOpponentFigureAtPostion(board, to, currentFigurCcolor)) // if there is no figure this returns true
                    {
                        return;
                    }
                }
            }
            else if(currentFigurCcolor == ChessColor.Black)
            {
                if (from.Row - 1 == to.Row && this.CheckDiagonalMove(from, to))
                {
                    if (this.CheckIfThereIsOpponentFigureAtPostion(board, to, currentFigurCcolor))
                    {
                        return;
                    }
                }
            }

            // TODO: add these magic numbers as constants!
            // Check if pawn can make initial 2 row move
            if (from.Row == 2 && currentFigurCcolor == ChessColor.White) 
            {
                if (from.Row + 2 == to.Row && from.Col == to.Col && !this.CheckIfThereIsOpponentFigureAtPostion(board,to, otherFigureColor))
                {
                    return;
                }
            }
            else if (from.Row == 7 && currentFigurCcolor == ChessColor.Black)
            {
                if (from.Row - 2 == to.Row && from.Col == to.Col && !this.CheckIfThereIsOpponentFigureAtPostion(board, to, otherFigureColor))
                {
                    return;
                }
            }

            // if none of the above moves is valid, the move is invalid
            throw new InvalidOperationException(PawnInvalidMove);
        }

        private bool CheckIfThereIsOpponentFigureAtPostion(IBoard board, Position to, ChessColor cuurentFigureColor)
        {
            var otherFigure = board.GetFigureAtPosition(to);

            if (otherFigure != null && otherFigure.Color != cuurentFigureColor)
            {
                return true;
            }

            return false;
        }

        private bool CheckDiagonalMove(Position from, Position to)
        {
            return (from.Col + 1 == to.Col || from.Col - 1 == to.Col);
        }
    }
}
