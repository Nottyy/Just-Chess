using Just_Chess.Common;
using Just_Chess.Movements.Contracts;
using System.Collections.Generic;

namespace Just_Chess.Figures.Contracts
{
    public abstract class BaseFigure : IFigure
    {
        // TODO: remove all inheritance and use FigureType enum
        protected BaseFigure(ChessColor color)
        {
            this.Color = color;
        }

        public ChessColor Color { get; private set; }

        public abstract ICollection<IMovement> Move(IMovementStrategy strategy);
    }
}
