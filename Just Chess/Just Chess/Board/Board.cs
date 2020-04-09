namespace Just_Chess.Board
{
    using Just_Chess.Common;
    using Just_Chess.Figures.Contracts;
    using System;

    public class Board
    {
        private readonly IFigure[,] board;

        public Board(int rows = GlobalConstants.StandardGameTotalBoardRows, 
            int cols = GlobalConstants.StandardGameTotalBoardCols)
        {
            this.TotalRows = rows;
            this.TotalCols = cols;
            this.board = new IFigure[rows, cols];
        }

        public int TotalRows { get; private set; }
        public int TotalCols { get; private set; }

        public void AddFigure(IFigure figure, Position position)
        {
            ObjectValidator.CheckIfObjectIsNull(figure, GlobalErrorMessages.NullFigureErrorMessage);
            this.CheckIfPositionIsValid(position);

            int arrRow = this.GetArrayRow(position.Row);
            int arrCol = this.GetArrayCol(position.Col);
            this.board[arrRow, arrCol] = figure;
        }

        public void RemoveFigure(Position position)
        {
            this.CheckIfPositionIsValid(position);

            int arrRow = this.GetArrayRow(position.Row);
            int arrCol = this.GetArrayCol(position.Col);
            this.board[arrRow, arrCol] = null;
        }

        private int GetArrayRow(int chessRow)
        {
            return this.TotalRows - chessRow;
        }

        private int GetArrayCol(char chessCol)
        {
            return chessCol - 'a';
        }

        private void CheckIfPositionIsValid(Position position)
        {
            if (position.Row < GlobalConstants.MinimumRowValueOnBoards || position.Row > GlobalConstants.MaximumRowValueOnBoard)
            {
                throw new IndexOutOfRangeException("Selected row position on the board is not valid");
            }

            if (position.Row < GlobalConstants.MinimumColumnValueOnBoard || position.Row > GlobalConstants.MaximumColumnValueOnBoard)
            {
                throw new IndexOutOfRangeException("Selected column position on the board is not valid");
            }
        }
    }
}
