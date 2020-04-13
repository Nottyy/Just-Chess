namespace Just_Chess.Movements.Contracts
{
    using Just_Chess.Board;
    using Just_Chess.Common;
    using Just_Chess.Figures.Contracts;

    public interface IMovement
    {
        void ValidateMove(IFigure figure, IBoard board, Move move);
    }
}
