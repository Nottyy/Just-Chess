namespace Just_Chess.Board
{
    using Just_Chess.Common;
    using Just_Chess.Figures.Contracts;

    public interface IBoard
    {
        int TotalRows { get; }
        int TotalCols { get; }

        void AddFigure(IFigure figure, Position position);

        void RemoveFigure(Position position);

        IFigure GetFigureAtPosition(Position position);
    }
}
