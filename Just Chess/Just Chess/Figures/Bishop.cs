namespace Just_Chess.Figures
{
    using System.Collections.Generic;

    using Just_Chess.Common;
    using Just_Chess.Figures.Contracts;
    using Just_Chess.Movements.Contracts;
    
    public class Bishop : BaseFigure, IFigure
    {
        public Bishop(ChessColor color) : base(color)
        {

        }

        public override ICollection<IMovement> Move(IMovementStrategy strategy)
        {
            return strategy.GetAllMovements(this.GetType().Name);
        }
    }
}
