namespace Just_Chess.Movements
{
    using Just_Chess.Board;
    using Just_Chess.Common;
    using Just_Chess.Figures.Contracts;
    using Just_Chess.Movements.Contracts;
    using System;

    // TODO: add pawn promotion logic
    public class NormalPawnMovement : IMovement
    {
        private const string PawnsBackwardsErrorMessage = "Pawns cannot move backwards or stay at the same row!";
        private const string PawnInvalidMove = "Pawns cannot move this way!";

        private const int WhitePawnInitialRowPosition = 2;
        private const int BlackPawnInitialRowPosition = 7;

        private const int PawnTwoStepMovement = 2;

        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var currentFigurCcolor = figure.Color;
            var otherFigureColor = figure.Color == ChessColor.White ? ChessColor.Black : ChessColor.White;
            var from = move.From;
            var to = move.To;

            // Check normal pawn move
            if (from.Row + 1 == to.Row && from.Col == to.Col && currentFigurCcolor == ChessColor.White)
            {
                if (!board.CheckIfThereIsFigureAtPosition(to))
                {
                    return;
                }
            }
            else if (from.Row - 1 == to.Row && from.Col == to.Col && currentFigurCcolor == ChessColor.Black)
            {
                if (!board.CheckIfThereIsFigureAtPosition(to))
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
                    if (board.CheckIfThereIsFigureAtPosition(to))
                    {
                        return;
                    }
                }
            }
            else if(currentFigurCcolor == ChessColor.Black)
            {
                if (from.Row - 1 == to.Row && this.CheckDiagonalMove(from, to))
                {
                    if (board.CheckIfThereIsFigureAtPosition(to))
                    {
                        return;
                    }
                }
            }

            // Check if pawn can make initial 2 row move
            if (from.Row == WhitePawnInitialRowPosition && currentFigurCcolor == ChessColor.White) 
            {
                if (from.Row + PawnTwoStepMovement == to.Row && from.Col == to.Col && !board.CheckIfThereIsFigureAtPosition(to))
                {
                    return;
                }
            }
            else if (from.Row == BlackPawnInitialRowPosition && currentFigurCcolor == ChessColor.Black)
            {
                if (from.Row - PawnTwoStepMovement == to.Row && from.Col == to.Col && !board.CheckIfThereIsFigureAtPosition(to))
                {
                    return;
                }
            }

            // if none of the above moves is valid, the move is invalid
            throw new InvalidOperationException(PawnInvalidMove);
        }
        
        private bool CheckDiagonalMove(Position from, Position to)
        {
            return (from.Col + 1 == to.Col || from.Col - 1 == to.Col);
        }
    }
}
