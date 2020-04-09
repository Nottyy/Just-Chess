namespace Just_Chess.Players.Contracts
{
    using Just_Chess.Common;
    using Just_Chess.Figures.Contracts;

    public interface IPlayer
    {
        string Name { get; }
        ChessColor Color { get; }

        void AddFigure(IFigure figure);
        void RemoveFigure(IFigure figure);
    }
}
