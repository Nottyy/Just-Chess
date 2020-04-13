namespace Just_Chess.Figures.Contracts
{
    using Just_Chess.Common;
    using Just_Chess.Movements.Contracts;
    using System.Collections.Generic;

    public interface IFigure
    {
        ChessColor Color { get; }

        ICollection<IMovement> Move();
    }
}
